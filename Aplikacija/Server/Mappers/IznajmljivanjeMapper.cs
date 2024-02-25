using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class IznajmljivanjeMapper
    {
        public static IznajmljivanjePrikaz IznajmljivanjeToIznajmljivanjePrikaz(Iznajmljivanje iznajmljivanje)
        {
            if (iznajmljivanje == null) return null;

            return new IznajmljivanjePrikaz()
            {
                Id = iznajmljivanje.Id,
                KorisnikId = iznajmljivanje.Korisnik.Id,
                KorisnikIme = iznajmljivanje.Korisnik.Ime,
                RadnikDodelioId = iznajmljivanje.RadnikDodelio.Id,
                RadnikDodelioKorisnickoIme = iznajmljivanje.RadnikDodelio.KorisnickoIme,
                OgranakBibliotekeId = iznajmljivanje.OgranakBiblioteke.Id,
                OgranakBibliotekeNaziv = iznajmljivanje.OgranakBiblioteke.Naziv,
                FizickaKnjigaId = iznajmljivanje.FizickaKnjiga.Id,
                FizickaKnjigaSifra = iznajmljivanje.FizickaKnjiga.Sifra,
                KnjigaId = iznajmljivanje.FizickaKnjiga.Knjiga.Id,
                KnjigaNaslov = iznajmljivanje.FizickaKnjiga.Knjiga.Naslov,
                DatumIznajmljivanja = iznajmljivanje.DatumIznajmljivanja,
                DatumVracanja = iznajmljivanje.DatumVracanja,
                Kazna = iznajmljivanje.Kazna
            };
        }

        public static List<IznajmljivanjePrikaz> IznajmljivanjaToIznajmljivanjaPrikaz(List<Iznajmljivanje> iznajmljivanja)
        {
            List<IznajmljivanjePrikaz> ip = new List<IznajmljivanjePrikaz>();

            foreach (var i in iznajmljivanja)
            {
                ip.Add(IznajmljivanjeToIznajmljivanjePrikaz(i));
            }

            return ip;
        }
    }
}