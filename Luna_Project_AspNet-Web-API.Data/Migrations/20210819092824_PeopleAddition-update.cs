using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna_Project_AspNet_Web_API.Data.Migrations
{
    public partial class PeopleAdditionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "propertyCount",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "propertyCount",
                table: "People");
        }
    }
}
