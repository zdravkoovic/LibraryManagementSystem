using System;

namespace ClientModels.Prikaz
{
    public class IznajmljivanjePrikaz
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }
        public int RadnikDodelioId { get; set; }
        public string RadnikDodelioKorisnickoIme { get; set; }
        public int OgranakBibliotekeId { get; set; }
        public string OgranakBibliotekeNaziv { get; set; }
        public int FizickaKnjigaId { get; set; }
        public string FizickaKnjigaSifra { get; set; }
        public int KnjigaId { get; set; }
        public string KnjigaNaslov { get; set; }
        public DateTime? DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public float Kazna { get; set; }
    }
}