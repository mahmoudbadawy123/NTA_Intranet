using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interanet.DataAccessLayer.Migrations
{
    public partial class seedingGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
             table: "UserGroups",
             columns: new[] { "Id", "Name", "Description" },
             values: new object[] { 1, "All NTA Employee", "Description" }
         );

            migrationBuilder.InsertData(
               table: "UserGroups",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[] { 2, "Managers", "Description" }
           );

            migrationBuilder.InsertData(
              table: "UserGroups",
              columns: new[] { "Id", "Name", "Description" },
              values: new object[] { 3, "Directors", "Description" }
             );
            migrationBuilder.InsertData(
          table: "UserGroups",
          columns: new[] { "Id", "Name", "Description" },
          values: new object[] { 4, "IT Depertment", "Description" }
         );

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 5, "HR Depertment", "Description" }
               );


            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 6, "Executive Director Office ", "Description" }
                );


            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 7, "Finance Depertment ", "Description" }
                );





        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [UserGroups]");
        }
    }
}
