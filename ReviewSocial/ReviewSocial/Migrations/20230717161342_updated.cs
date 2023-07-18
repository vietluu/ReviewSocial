using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewSocial.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "like",
                table: "posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "like",
                table: "posts",
                type: "int",
                nullable: true);
        }
    }
}
