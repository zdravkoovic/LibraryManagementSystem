using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class KorisnikMapper
    {
        public static KorisnikPrikaz KorisnikToKorisnikPrikaz(Korisnik korisnik)
        {
            if (korisnik == null) return null;

            return new KorisnikPrikaz()
            {
                Id = korisnik.Id,
                KorisnickoIme = korisnik.KorisnickoIme,
                DatumPlacanjaClanarine = korisnik.DatumPlacanjaClanarine,
                Kazna = korisnik.Kazna,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Kontakt = korisnik.Kontakt,
                Email = korisnik.Email
            };
        }

        public static List<KorisnikPrikaz> KorisniciToKorisniciPrikaz(List<Korisnik> korisnici)
        {
            List<KorisnikPrikaz> korisniciPrikaz = new List<KorisnikPrikaz>();

            foreach (var k in korisnici)
            {
                korisniciPrikaz.Add(KorisnikToKorisnikPrikaz(k));
            }

            return korisniciPrikaz;
        }
    }
}