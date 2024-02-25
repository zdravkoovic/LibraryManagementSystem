using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class CekanjeMapper
    {
        public static CekanjePrikaz CekanjeToCekanjePrikaz(Cekanje cekanje)
        {
            if(cekanje == null) return null;

            return new CekanjePrikaz()
            {   
                Id = cekanje.Id,
                Datum = cekanje.Datum,
                KorisnikId = cekanje.Korisnik.Id,
                KorisnikKorisnickoIme = cekanje.Korisnik.KorisnickoIme,
                KnjigaId = cekanje.Knjiga.Id,
                KnjigaNaslov = cekanje.Knjiga.Naslov,
                KnjigaSlika = cekanje.Knjiga.Slika?.Link
            };
        }

        public static List<CekanjePrikaz> CekanjaToCekanjaPrikaz(List<Cekanje> cekanja)
        {
            List<CekanjePrikaz> cekanjaPrikaz = new List<CekanjePrikaz>();

            foreach (var c in cekanja)
            {
                cekanjaPrikaz.Add(CekanjeToCekanjePrikaz(c));
            }

            return cekanjaPrikaz;
        }
    }
}