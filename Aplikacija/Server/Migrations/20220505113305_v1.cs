using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Izdavaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdavaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jezici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jezici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnjizevniRodovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjizevniRodovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlacenaClanarina = table.Column<bool>(type: "bit", nullable: false),
                    Kazna = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OgranciBiblioteke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgranciBiblioteke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Menadzer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnjizevneVrste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnjizevniRodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjizevneVrste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnjizevneVrste_KnjizevniRodovi_KnjizevniRodId",
                        column: x => x.KnjizevniRodId,
                        principalTable: "KnjizevniRodovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citaonice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojVrsta = table.Column<int>(type: "int", nullable: false),
                    BrojKolona = table.Column<int>(type: "int", nullable: false),
                    OgranakBibliotekeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citaonice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citaonice_OgranciBiblioteke_OgranakBibliotekeId",
                        column: x => x.OgranakBibliotekeId,
                        principalTable: "OgranciBiblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prijave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(type: "int", nullable: false),
                    OgranakBibliotekeId = table.Column<int>(type: "int", nullable: false),
                    VremePrijavljivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeOdjavljivanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prijave_OgranciBiblioteke_OgranakBibliotekeId",
                        column: x => x.OgranakBibliotekeId,
                        principalTable: "OgranciBiblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prijave_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rasporedi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(type: "int", nullable: true),
                    OgranakBibliotekeId = table.Column<int>(type: "int", nullable: true),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rasporedi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rasporedi_OgranciBiblioteke_OgranakBibliotekeId",
                        column: x => x.OgranakBibliotekeId,
                        principalTable: "OgranciBiblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rasporedi_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(type: "int", nullable: true),
                    TekstVesti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vesti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vesti_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    CitaonicaId = table.Column<int>(type: "int", nullable: false),
                    Racunar = table.Column<bool>(type: "bit", nullable: false),
                    Zauzeto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesta_Citaonice_CitaonicaId",
                        column: x => x.CitaonicaId,
                        principalTable: "Citaonice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgranakBibliotekeId = table.Column<int>(type: "int", nullable: true),
                    VestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slike_OgranciBiblioteke_OgranakBibliotekeId",
                        column: x => x.OgranakBibliotekeId,
                        principalTable: "OgranciBiblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Slike_Vesti_VestId",
                        column: x => x.VestId,
                        principalTable: "Vesti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MestoSmrti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumSmrti = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OAutoru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlikaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autori_Slike_SlikaId",
                        column: x => x.SlikaId,
                        principalTable: "Slike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Knjige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: true),
                    KnjizevniRodId = table.Column<int>(type: "int", nullable: true),
                    KnjizevnaVrstaId = table.Column<int>(type: "int", nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knjige_Autori_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knjige_KnjizevneVrste_KnjizevnaVrstaId",
                        column: x => x.KnjizevnaVrstaId,
                        principalTable: "KnjizevneVrste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knjige_KnjizevniRodovi_KnjizevniRodId",
                        column: x => x.KnjizevniRodId,
                        principalTable: "KnjizevniRodovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cekanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cekanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cekanja_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cekanja_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FizickeKnjige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: false),
                    JezikId = table.Column<int>(type: "int", nullable: true),
                    OgranakBibliotekeId = table.Column<int>(type: "int", nullable: false),
                    IzdavacId = table.Column<int>(type: "int", nullable: true),
                    Slobodna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickeKnjige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FizickeKnjige_Izdavaci_IzdavacId",
                        column: x => x.IzdavacId,
                        principalTable: "Izdavaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FizickeKnjige_Jezici_JezikId",
                        column: x => x.JezikId,
                        principalTable: "Jezici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FizickeKnjige_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FizickeKnjige_OgranciBiblioteke_OgranakBibliotekeId",
                        column: x => x.OgranakBibliotekeId,
                        principalTable: "OgranciBiblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnjizevniZanrovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjizevniZanrovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnjizevniZanrovi_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentari_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentari_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeUzimanjaKnjige = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeVracanjaKnjige = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FizickaKnjigaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    RadnikDodelioId = table.Column<int>(type: "int", nullable: true),
                    MestoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citanja_FizickeKnjige_FizickaKnjigaId",
                        column: x => x.FizickaKnjigaId,
                        principalTable: "FizickeKnjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citanja_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citanja_Mesta_MestoId",
                        column: x => x.MestoId,
                        principalTable: "Mesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citanja_Radnici_RadnikDodelioId",
                        column: x => x.RadnikDodelioId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iznajmljivanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    RadnikDodelioId = table.Column<int>(type: "int", nullable: true),
                    FizickaKnjigaId = table.Column<int>(type: "int", nullable: false),
                    DatumIznajmljivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVracanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kazna = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iznajmljivanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanja_FizickeKnjige_FizickaKnjigaId",
                        column: x => x.FizickaKnjigaId,
                        principalTable: "FizickeKnjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanja_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanja_Radnici_RadnikDodelioId",
                        column: x => x.RadnikDodelioId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autori_SlikaId",
                table: "Autori",
                column: "SlikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cekanja_KnjigaId",
                table: "Cekanja",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cekanja_KorisnikId",
                table: "Cekanja",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Citanja_FizickaKnjigaId",
                table: "Citanja",
                column: "FizickaKnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Citanja_KorisnikId",
                table: "Citanja",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Citanja_MestoId",
                table: "Citanja",
                column: "MestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citanja_RadnikDodelioId",
                table: "Citanja",
                column: "RadnikDodelioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citaonice_OgranakBibliotekeId",
                table: "Citaonice",
                column: "OgranakBibliotekeId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickeKnjige_IzdavacId",
                table: "FizickeKnjige",
                column: "IzdavacId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickeKnjige_JezikId",
                table: "FizickeKnjige",
                column: "JezikId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickeKnjige_KnjigaId",
                table: "FizickeKnjige",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickeKnjige_OgranakBibliotekeId",
                table: "FizickeKnjige",
                column: "OgranakBibliotekeId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickeKnjige_Sifra",
                table: "FizickeKnjige",
                column: "Sifra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanja_FizickaKnjigaId",
                table: "Iznajmljivanja",
                column: "FizickaKnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanja_KorisnikId",
                table: "Iznajmljivanja",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanja_RadnikDodelioId",
                table: "Iznajmljivanja",
                column: "RadnikDodelioId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_AutorId",
                table: "Knjige",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_KnjizevnaVrstaId",
                table: "Knjige",
                column: "KnjizevnaVrstaId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_KnjizevniRodId",
                table: "Knjige",
                column: "KnjizevniRodId");

            migrationBuilder.CreateIndex(
                name: "IX_KnjizevneVrste_KnjizevniRodId",
                table: "KnjizevneVrste",
                column: "KnjizevniRodId");

            migrationBuilder.CreateIndex(
                name: "IX_KnjizevniZanrovi_KnjigaId",
                table: "KnjizevniZanrovi",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_KnjigaId",
                table: "Komentari",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_KorisnikId",
                table: "Komentari",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_JMBG",
                table: "Korisnici",
                column: "JMBG",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KorisnickoIme",
                table: "Korisnici",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mesta_CitaonicaId",
                table: "Mesta",
                column: "CitaonicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijave_OgranakBibliotekeId",
                table: "Prijave",
                column: "OgranakBibliotekeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijave_RadnikId",
                table: "Prijave",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_KorisnickoIme",
                table: "Radnici",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rasporedi_OgranakBibliotekeId",
                table: "Rasporedi",
                column: "OgranakBibliotekeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rasporedi_RadnikId",
                table: "Rasporedi",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_OgranakBibliotekeId",
                table: "Slike",
                column: "OgranakBibliotekeId");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_VestId",
                table: "Slike",
                column: "VestId");

            migrationBuilder.CreateIndex(
                name: "IX_Vesti_RadnikId",
                table: "Vesti",
                column: "RadnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cekanja");

            migrationBuilder.DropTable(
                name: "Citanja");

            migrationBuilder.DropTable(
                name: "Iznajmljivanja");

            migrationBuilder.DropTable(
                name: "KnjizevniZanrovi");

            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "Prijave");

            migrationBuilder.DropTable(
                name: "Rasporedi");

            migrationBuilder.DropTable(
                name: "Mesta");

            migrationBuilder.DropTable(
                name: "FizickeKnjige");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Citaonice");

            migrationBuilder.DropTable(
                name: "Izdavaci");

            migrationBuilder.DropTable(
                name: "Jezici");

            migrationBuilder.DropTable(
                name: "Knjige");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "KnjizevneVrste");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "KnjizevniRodovi");

            migrationBuilder.DropTable(
                name: "OgranciBiblioteke");

            migrationBuilder.DropTable(
                name: "Vesti");

            migrationBuilder.DropTable(
                name: "Radnici");
        }
    }
}
