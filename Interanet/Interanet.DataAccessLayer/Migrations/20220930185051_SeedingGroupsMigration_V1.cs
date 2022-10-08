using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interanet.DataAccessLayer.Migrations
{
    public partial class SeedingGroupsMigration_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "UserGroups",
               columns: new[] { "Id", "Name" , "Description" },
               values: new object[] { 1, "Managers", "Description" }
           );

            migrationBuilder.InsertData(
              table: "UserGroups",
              columns: new[] { "Id", "Name" , "Description"},
              values: new object[] { 2, "Directors", "Description" }
             );
            migrationBuilder.InsertData(
          table: "UserGroups",
          columns: new[] { "Id", "Name", "Description" },
          values: new object[] { 3, "IT Depertment", "Description" }
         );

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 4, "HR Depertment", "Description" }
               );


            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 5, "Executive Director Office ", "Description" }
                );


            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 6, "Finance Depertment ", "Description" }
                );



         

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [UserGroups]");

        }
    }
}
