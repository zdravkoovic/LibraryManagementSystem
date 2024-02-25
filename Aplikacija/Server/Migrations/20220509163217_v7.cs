using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnjizevniZanrovi_Knjige_KnjigaId",
                table: "KnjizevniZanrovi");

            migrationBuilder.DropIndex(
                name: "IX_KnjizevniZanrovi_KnjigaId",
                table: "KnjizevniZanrovi");

            migrationBuilder.DropColumn(
                name: "KnjigaId",
                table: "KnjizevniZanrovi");

            migrationBuilder.CreateTable(
                name: "KnjigaKnjizevniZanr",
                columns: table => new
                {
                    KnjigeId = table.Column<int>(type: "int", nullable: false),
                    KnjizevniZanroviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjigaKnjizevniZanr", x => new { x.KnjigeId, x.KnjizevniZanroviId });
                    table.ForeignKey(
                        name: "FK_KnjigaKnjizevniZanr_Knjige_KnjigeId",
                        column: x => x.KnjigeId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnjigaKnjizevniZanr_KnjizevniZanrovi_KnjizevniZanroviId",
                        column: x => x.KnjizevniZanroviId,
                        principalTable: "KnjizevniZanrovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnjigaKnjizevniZanr_KnjizevniZanroviId",
                table: "KnjigaKnjizevniZanr",
                column: "KnjizevniZanroviId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnjigaKnjizevniZanr");

            migrationBuilder.AddColumn<int>(
                name: "KnjigaId",
                table: "KnjizevniZanrovi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KnjizevniZanrovi_KnjigaId",
                table: "KnjizevniZanrovi",
                column: "KnjigaId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnjizevniZanrovi_Knjige_KnjigaId",
                table: "KnjizevniZanrovi",
                column: "KnjigaId",
                principalTable: "Knjige",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
