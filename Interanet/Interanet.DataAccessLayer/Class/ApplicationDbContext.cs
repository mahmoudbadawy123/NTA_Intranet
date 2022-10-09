using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Interanet.Model.Data;

namespace Interanet.DataAccessLayer.Class
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<Storys> Storys { get; set; }
        public DbSet<CalenderEvents> CalenderEvents { get; set; }
        public DbSet<MeetingTypes> MeetingTypes { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Systems> Systems { get; set; }
        public DbSet<ApplicationUserMeeting> ApplicationUserMeetings { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");


            //#########################################################################################
            builder.Entity<Meeting>() //post
                    .HasMany(p => p.ApplicationUsers)
                    .WithMany(t => t.Meetings)
                    .UsingEntity<ApplicationUserMeeting>(
               
                j=>j.HasOne(pt=>pt.ApplicationUser) //tags
                    .WithMany(t=>t.ApplicationUserMeetings)
                    .HasForeignKey(pt=>pt.ApplicationUserId),

                j => j.HasOne(pt => pt.Meeting)
                    .WithMany(t => t.ApplicationUserMeetings)
                    .HasForeignKey(pt => pt.MeetingId),
                j =>
                {
                    j.HasKey(t => new { t.MeetingId, t.ApplicationUserId });
                });

            builder.Entity<Meeting>().HasOne(A => A.ApplicationUser_InsertUser);

            builder.Entity<Meeting>().HasOne(A => A.ApplicationUser_UpdateUser);


        }
    }
}
