using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interanet.DataAccessLayer.Migrations
{
    public partial class AddTableStorys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storys");
        }
    }
}
