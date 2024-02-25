using Microsoft.EntityFrameworkCore;
using Models;

namespace Models.DatabaseCommunication
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Autor> Autori { get; set; }
        public DbSet<Cekanje> Cekanja { get; set; }
        public DbSet<Citanje> Citanja { get; set; }
        public DbSet<Citaonica> Citaonice { get; set; }
        public DbSet<FizickaKnjiga> FizickeKnjige { get; set; }
        public DbSet<Izdavac> Izdavaci { get; set; }
        public DbSet<Iznajmljivanje> Iznajmljivanja { get; set; }
        public DbSet<Jezik> Jezici { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<KnjizevnaVrsta> KnjizevneVrste { get; set; }
        public DbSet<KnjizevniRod> KnjizevniRodovi { get; set; }
        public DbSet<KnjizevniZanr> KnjizevniZanrovi { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Mesto> Mesta { get; set; }
        public DbSet<OgranakBiblioteke> OgranciBiblioteke { get; set; }
        public DbSet<Prijava> Prijave { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Raspored> Rasporedi { get; set; }
        public DbSet<Slika> Slike { get; set; }
        public DbSet<Vest> Vesti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>()
                .HasIndex(k => k.Email)
                .IsUnique();

            modelBuilder.Entity<Korisnik>()
                .HasIndex(k => k.KorisnickoIme)
                .IsUnique();

            modelBuilder.Entity<Radnik>()
                .HasIndex(r => r.KorisnickoIme)
                .IsUnique();

            modelBuilder.Entity<FizickaKnjiga>()
                .HasIndex(k => k.Sifra)
                .IsUnique();       
        }
    }
}