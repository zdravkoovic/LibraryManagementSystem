using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class KomentarMapper
    {
        public static KomentarPrikaz KomentarToKomentarPrikaz(Komentar komentar)
        {
            if(komentar == null) return null;

            return new KomentarPrikaz()
            {
                Id = komentar.Id,
                Tekst = komentar.Tekst,
                Datum = komentar.Datum,
                KorisnikId = komentar.Korisnik.Id,
                KorisnikKorisnickoIme = komentar.Korisnik.KorisnickoIme,
                KnjigaId = komentar.Knjiga.Id
            };
        }

        public static List<KomentarPrikaz> KomentariToKomentariPrikaz(List<Komentar> komentari)
        {
            List<KomentarPrikaz> komentariPrikaz = new List<KomentarPrikaz>();

            foreach (var k in komentari)
            {
                komentariPrikaz.Add(KomentarToKomentarPrikaz(k));
            }

            return komentariPrikaz;
        }
    }
}