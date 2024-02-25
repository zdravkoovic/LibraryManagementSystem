using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class PrijavaMapper
    {
        public static PrijavaPrikaz PrijavaToPrijavaPrikaz(Prijava prijava)
        {
            if (prijava == null) return null;

            return new PrijavaPrikaz()
            {
                Id = prijava.Id,
                RadnikId = prijava.Radnik.Id,
                RadnikKorisnickoIme = prijava.Radnik.KorisnickoIme,
                Menadzer = prijava.Radnik.Menadzer,
                OgranakBibliotekeId = prijava.OgranakBiblioteke?.Id,
                OgranakBibliotekeNaziv = prijava.OgranakBiblioteke?.Naziv,
                VremePrijave = prijava.VremePrijave,
                VremeOdjave = prijava.VremeOdjave
            };
        }

        public static List<PrijavaPrikaz> PrijaveToPrijavePrikaz(List<Prijava> prijave)
        {
            List<PrijavaPrikaz> prijavePrikaz = new List<PrijavaPrikaz>();

            foreach (var p in prijave)
            {
                prijavePrikaz.Add(PrijavaToPrijavaPrikaz(p));
            }

            return prijavePrikaz;
        }
    }
}