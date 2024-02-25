using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class CitanjeMapper
    {
        public static CitanjePrikaz CitanjeToCitanjePrikaz(Citanje citanje)
        {
            if (citanje == null) return null;

            return new CitanjePrikaz()
            {
                Id = citanje.Id,
                VremeUzimanjaKnjige = citanje.VremeUzimanjaKnjige,
                VremeVracanjaKnjige = citanje.VremeVracanjaKnjige,
                FizickaKnjigaId = citanje.FizickaKnjiga.Id,
                FizickaKnjigaSifra = citanje.FizickaKnjiga.Sifra,
                KnjigaId = citanje.FizickaKnjiga.Knjiga.Id,
                KnjigaNaslov = citanje.FizickaKnjiga.Knjiga.Naslov,
                KorisnikId = citanje.Korisnik.Id,
                KorisnikIme = citanje.Korisnik.Ime,
                KorisnikPrezime = citanje.Korisnik.Prezime,
                RadnikDodelioId = citanje.RadnikDodelio.Id,
                RadnikDodelioKorisnickoIme = citanje.RadnikDodelio.KorisnickoIme,
                MestoId = citanje.Mesto.Id
            };
        }

        public static List<CitanjePrikaz> CitanjaToCitanjaPrikaz(List<Citanje> citanja)
        {
            List<CitanjePrikaz> cp = new List<CitanjePrikaz>();

            foreach (var c in citanja)
            {
                cp.Add(CitanjeToCitanjePrikaz(c));
            }

            return cp;
        }
    }
}