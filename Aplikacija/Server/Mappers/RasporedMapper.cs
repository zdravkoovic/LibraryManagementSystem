using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class RasporedMapper
    {
        public static RasporedPrikaz RasporedToRasporedPrikaz(Raspored raspored)
        {
            if (raspored == null) return null;

            return new RasporedPrikaz()
            {
                Id = raspored.Id,
                RadnikId = raspored.Radnik.Id,
                RadnikKorisnickoIme = raspored.Radnik.KorisnickoIme,
                MenadzerId = raspored.Menadzer?.Id,
                MenadzerKorisnickoIme = raspored.Menadzer?.KorisnickoIme,
                OgranakBibliotekeId = raspored.OgranakBiblioteke?.Id,
                OgranakBibliotekeNaziv = raspored.OgranakBiblioteke?.Naziv,
                DatumOd = raspored.DatumOd,
                DatumDo = raspored.DatumDo
            };
        }

        public static List<RasporedPrikaz> RasporediToRasporediPrikaz(List<Raspored> rasporedi)
        {
            List<RasporedPrikaz> rasporediPrikaz = new List<RasporedPrikaz>();

            foreach (var r in rasporedi)
            {
                rasporediPrikaz.Add(RasporedToRasporedPrikaz(r));
            }

            return rasporediPrikaz;
        }
    }
}