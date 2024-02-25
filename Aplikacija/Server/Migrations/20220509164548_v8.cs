using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tekst",
                table: "Vesti",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Tekst",
                table: "Komentari",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Knjige",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OAutoru",
                table: "Autori",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tekst",
                table: "Vesti",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "Tekst",
                table: "Komentari",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Knjige",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OAutoru",
                table: "Autori",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);
        }
    }
}
