using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class RadnikMapper
    {
        public static RadnikPrikaz RadnikToRadnikPrikaz(Radnik radnik)
        {
            if (radnik == null) return null;

            return new RadnikPrikaz()
            {
                Id = radnik.Id,
                KorisnickoIme = radnik.KorisnickoIme,
                Menadzer = radnik.Menadzer,
                JMBG = radnik.JMBG,
                Ime = radnik.Ime,
                Prezime = radnik.Prezime,
                Kontakt = radnik.Kontakt
            };
        }

        public static List<RadnikPrikaz> RadniciToRadniciPrikaz(List<Radnik> radnici)
        {
            List<RadnikPrikaz> radniciPrikaz = new List<RadnikPrikaz>();

            foreach (var r in radnici)
            {
                radniciPrikaz.Add(RadnikToRadnikPrikaz(r));
            }

            return radniciPrikaz;
        }
    }
}