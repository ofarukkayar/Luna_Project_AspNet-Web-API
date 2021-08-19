using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna_Project_AspNet_Web_API.Data.Migrations
{
    public partial class PeopleAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[] { 1, "Peter", "Smith" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[] { 2, "Bob", "Herb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
