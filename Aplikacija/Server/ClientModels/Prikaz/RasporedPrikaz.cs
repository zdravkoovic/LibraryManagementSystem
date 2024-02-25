using System;

namespace ClientModels.Prikaz
{
    public class RasporedPrikaz
    {
        public int Id { get; set; }
        public int RadnikId { get; set; }
        public string RadnikKorisnickoIme { get; set; }
        public int? MenadzerId { get; set; }
        public string MenadzerKorisnickoIme { get; set; }
        public int? OgranakBibliotekeId { get; set; }
        public string OgranakBibliotekeNaziv { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
    }
}