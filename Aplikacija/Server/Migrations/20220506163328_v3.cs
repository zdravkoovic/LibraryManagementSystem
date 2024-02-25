using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VremePrijavljivanja",
                table: "Prijave",
                newName: "VremePrijave");

            migrationBuilder.RenameColumn(
                name: "VremeOdjavljivanja",
                table: "Prijave",
                newName: "VremeOdjave");

            migrationBuilder.AddColumn<string>(
                name: "Naslov",
                table: "Vesti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naslov",
                table: "Vesti");

            migrationBuilder.RenameColumn(
                name: "VremePrijave",
                table: "Prijave",
                newName: "VremePrijavljivanja");

            migrationBuilder.RenameColumn(
                name: "VremeOdjave",
                table: "Prijave",
                newName: "VremeOdjavljivanja");
        }
    }
}
