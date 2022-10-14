using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interanet.DataAccessLayer.Migrations
{
    public partial class addRealatedSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatedSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isScheduledPublish = table.Column<bool>(type: "bit", maxLength: 450, nullable: true),
                    PublishDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedSystems_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelatedSystems_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRelatedSystems",
                columns: table => new
                {
                    RelatedSystemId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRelatedSystems", x => new { x.RelatedSystemId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRelatedSystems_RelatedSystems_RelatedSystemId",
                        column: x => x.RelatedSystemId,
                        principalTable: "RelatedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRelatedSystems_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRelatedSystems_ApplicationUserId",
                table: "ApplicationUserRelatedSystems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedSystems_InsertUserId",
                table: "RelatedSystems",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedSystems_UpdateUserId",
                table: "RelatedSystems",
                column: "UpdateUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRelatedSystems");

            migrationBuilder.DropTable(
                name: "RelatedSystems");
        }
    }
}
