using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class vv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Korisnici_JMBG",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "Korisnici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "Korisnici",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_JMBG",
                table: "Korisnici",
                column: "JMBG",
                unique: true);
        }
    }
}
