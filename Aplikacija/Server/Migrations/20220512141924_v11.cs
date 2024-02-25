using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lozinka",
                table: "Radnici",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Lozinka",
                table: "Korisnici",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lozinka",
                table: "Radnici",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "Lozinka",
                table: "Korisnici",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");
        }
    }
}
