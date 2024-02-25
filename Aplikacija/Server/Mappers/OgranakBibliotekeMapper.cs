using System.Collections.Generic;
using ClientModels.Prikaz;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Linq;

namespace Mappers
{
    public static class OgranakBibliotekMapper
    {
        public static OgranakBibliotekePrikaz OgranakBibliotekeToOgranakBibliotekePrikaz(OgranakBiblioteke ogranakBiblioteke)
        {
            if (ogranakBiblioteke == null) return null;

            return new OgranakBibliotekePrikaz()
            {
                Id = ogranakBiblioteke.Id,
                Naziv = ogranakBiblioteke.Naziv,
                Adresa = ogranakBiblioteke.Adresa,
                Kontakt = ogranakBiblioteke.Kontakt,
                Slike = ogranakBiblioteke.Slike?.Select(s => s.Link).ToList()
            };
        }

        public static List<OgranakBibliotekePrikaz> OgranciBibliotekeToOgranciBibliotekePrikaz(List<OgranakBiblioteke> ogranciBiblioteke)
        {
            List<OgranakBibliotekePrikaz> obp = new List<OgranakBibliotekePrikaz>();

            foreach (var ob in ogranciBiblioteke)
            {
                obp.Add(OgranakBibliotekeToOgranakBibliotekePrikaz(ob));
            }

            return obp;
        }
    }
}