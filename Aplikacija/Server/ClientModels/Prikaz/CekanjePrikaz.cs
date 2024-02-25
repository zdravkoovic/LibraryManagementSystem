using System;

namespace ClientModels.Prikaz
{
    public class CekanjePrikaz
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public int KnjigaId { get; set; }
        public string KnjigaNaslov { get; set; }
        public string KnjigaSlika { get; set; }
    }
}