using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class vv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prijave_OgranciBiblioteke_OgranakBibliotekeId",
                table: "Prijave");

            migrationBuilder.AlterColumn<int>(
                name: "OgranakBibliotekeId",
                table: "Prijave",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prijave_OgranciBiblioteke_OgranakBibliotekeId",
                table: "Prijave",
                column: "OgranakBibliotekeId",
                principalTable: "OgranciBiblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prijave_OgranciBiblioteke_OgranakBibliotekeId",
                table: "Prijave");

            migrationBuilder.AlterColumn<int>(
                name: "OgranakBibliotekeId",
                table: "Prijave",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prijave_OgranciBiblioteke_OgranakBibliotekeId",
                table: "Prijave",
                column: "OgranakBibliotekeId",
                principalTable: "OgranciBiblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
