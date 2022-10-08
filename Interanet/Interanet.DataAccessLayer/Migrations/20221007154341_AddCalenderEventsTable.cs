using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interanet.DataAccessLayer.Migrations
{
    public partial class AddCalenderEventsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalenderEvents");
        }
    }
}
