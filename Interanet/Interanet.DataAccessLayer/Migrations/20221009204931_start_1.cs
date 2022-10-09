using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interanet.DataAccessLayer.Migrations
{
    public partial class start_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "MeetingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    IsFirstlogin = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    isScheduledPublish = table.Column<bool>(type: "bit", nullable: true),
                    PublishDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcements_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcements_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalenderEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalenderEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalenderEvents_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalenderEvents_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalenderEvents_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MeatingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeatingLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeatingLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeatingTypeId = table.Column<int>(type: "int", nullable: true),
                    isScheduledPublish = table.Column<bool>(type: "bit", nullable: true),
                    PublishDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_MeetingTypes_MeatingTypeId",
                        column: x => x.MeatingTypeId,
                        principalTable: "MeetingTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meetings_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meetings_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    isScheduledPublish = table.Column<bool>(type: "bit", nullable: true),
                    PublishDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storys_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Storys_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Storys_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    isScheduledPublish = table.Column<bool>(type: "bit", nullable: true),
                    PublishDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systems_Users_EmployeeUserId",
                        column: x => x.EmployeeUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Systems_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Systems_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserMeetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMeetings", x => new { x.MeetingId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMeetings_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMeetings_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_GroupId",
                table: "Announcements",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_InsertUserId",
                table: "Announcements",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UpdateUserId",
                table: "Announcements",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMeetings_ApplicationUserId",
                table: "ApplicationUserMeetings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderEvents_GroupId",
                table: "CalenderEvents",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderEvents_InsertUserId",
                table: "CalenderEvents",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderEvents_UpdateUserId",
                table: "CalenderEvents",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_InsertUserId",
                table: "Meetings",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeatingTypeId",
                table: "Meetings",
                column: "MeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_UpdateUserId",
                table: "Meetings",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "security",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "security",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Storys_GroupId",
                table: "Storys",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Storys_InsertUserId",
                table: "Storys",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Storys_UpdateUserId",
                table: "Storys",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_EmployeeUserId",
                table: "Systems",
                column: "EmployeeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_InsertUserId",
                table: "Systems",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_UpdateUserId",
                table: "Systems",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "security",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "security",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "security",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "security",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                schema: "security",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "security",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "ApplicationUserMeetings");

            migrationBuilder.DropTable(
                name: "CalenderEvents");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Storys");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "security");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "security");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "MeetingTypes");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "security");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
