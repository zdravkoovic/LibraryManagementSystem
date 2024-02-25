using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacenaClanarina",
                table: "Korisnici");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPlacanjaClanarine",
                table: "Korisnici",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OgranakBibliotekeId",
                table: "Iznajmljivanja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanja_OgranakBibliotekeId",
                table: "Iznajmljivanja",
                column: "OgranakBibliotekeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanja_OgranciBiblioteke_OgranakBibliotekeId",
                table: "Iznajmljivanja",
                column: "OgranakBibliotekeId",
                principalTable: "OgranciBiblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanja_OgranciBiblioteke_OgranakBibliotekeId",
                table: "Iznajmljivanja");

            migrationBuilder.DropIndex(
                name: "IX_Iznajmljivanja_OgranakBibliotekeId",
                table: "Iznajmljivanja");

            migrationBuilder.DropColumn(
                name: "DatumPlacanjaClanarine",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "OgranakBibliotekeId",
                table: "Iznajmljivanja");

            migrationBuilder.AddColumn<bool>(
                name: "PlacenaClanarina",
                table: "Korisnici",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
