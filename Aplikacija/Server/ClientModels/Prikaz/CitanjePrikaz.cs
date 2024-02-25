using System;

namespace ClientModels.Prikaz
{
    public class CitanjePrikaz
    {
        public int Id { get; set; }
        public DateTime? VremeUzimanjaKnjige { get; set; }
        public DateTime? VremeVracanjaKnjige { get; set; }
        public int FizickaKnjigaId { get; set; }
        public string FizickaKnjigaSifra { get; set; }
        public int KnjigaId { get; set; }
        public string KnjigaNaslov { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }
        public int RadnikDodelioId { get; set; }
        public string RadnikDodelioKorisnickoIme { get; set; }
        public int MestoId { get; set; }
    }
}