namespace ClientModels.Prikaz
{
    public class FizickaKnjigaPrikaz
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string KnjigaNaslov { get; set; }
        public string JezikNaziv { get; set; }
        public int? IzdavacId { get; set; }
        public string IzdavacNaziv { get; set; }
        public bool? Slobodna { get; set; }
    }
}