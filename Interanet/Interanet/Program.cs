using Interanet.Business.Classes;
using Interanet.Business.Interfaces;
using Interanet.Business.Interfaces.Services;
using Interanet.DataAccessLayer.Class;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");
var JWTConf = builder.Configuration.GetSection("JWT");

builder.Services.AddCors();
builder.Services.Configure<JWT>(JWTConf);

//https://dev.to/moe23/add-automapper-to-net-6-3fdn
var startUp = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddAutoMapper(startUp);


//Solving Problem of  navigation-property Return Null Value instead of Data 
// But There is Some Warnning With Using LazyLoading So  I will Use Eager Loading in App 
//https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy
//https://www.koskila.net/ef-core-returns-null-for-a-navigation-property/?fbclid=IwAR2V0GtNMtozwcgUKJ01wXur1_8UtQVqJHEeZr2CZVBZwb10dIgKc4jC7Ik
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(connectionString));

//services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// start  add Business Services here
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserGroupsService, UserGroupsService>();
builder.Services.AddScoped<IAnnouncementsService, AnnouncementsService>();
builder.Services.AddScoped<IStorysService, StorysService>();
builder.Services.AddScoped<ICalenderEventsService, CalenderEventsService>();

// End  add Business Services here
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                    };
                });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//https://www.infoworld.com/article/3650668/implement-authorization-for-swagger-in-aspnet-core-6.html
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
