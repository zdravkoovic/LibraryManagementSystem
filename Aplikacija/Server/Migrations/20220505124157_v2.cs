using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Knjige");

            migrationBuilder.RenameColumn(
                name: "TekstVesti",
                table: "Vesti",
                newName: "Tekst");

            migrationBuilder.AddColumn<int>(
                name: "MenadzerId",
                table: "Rasporedi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlikaId",
                table: "Knjige",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rasporedi_MenadzerId",
                table: "Rasporedi",
                column: "MenadzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_SlikaId",
                table: "Knjige",
                column: "SlikaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Slike_SlikaId",
                table: "Knjige",
                column: "SlikaId",
                principalTable: "Slike",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rasporedi_Radnici_MenadzerId",
                table: "Rasporedi",
                column: "MenadzerId",
                principalTable: "Radnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Slike_SlikaId",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_Rasporedi_Radnici_MenadzerId",
                table: "Rasporedi");

            migrationBuilder.DropIndex(
                name: "IX_Rasporedi_MenadzerId",
                table: "Rasporedi");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_SlikaId",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "MenadzerId",
                table: "Rasporedi");

            migrationBuilder.DropColumn(
                name: "SlikaId",
                table: "Knjige");

            migrationBuilder.RenameColumn(
                name: "Tekst",
                table: "Vesti",
                newName: "TekstVesti");

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Knjige",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
