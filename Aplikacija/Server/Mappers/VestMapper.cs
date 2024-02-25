using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using ClientModels.Prikaz;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Mappers
{
    public static class VestMapper
    {
        public static VestPrikaz VestToVestPrikaz(Vest vest)
        {
            if (vest == null) return null;

            return new VestPrikaz()
            {
                Id = vest.Id,
                Datum = vest.Datum,
                Naslov = vest.Naslov,
                Tekst = vest.Tekst,
                RadnikKorisnickoIme = vest.Radnik.KorisnickoIme,
                Slike = vest.Slike?.Select(s => s.Link).ToList()
            };
        }

        public static List<VestPrikaz> VestiToVestiPrikaz(List<Vest> vesti)
        {
            List<VestPrikaz> vestiPrikaz = new List<VestPrikaz>();

            foreach (var v in vesti)
            {
                vestiPrikaz.Add(VestToVestPrikaz(v));
            }

            return vestiPrikaz;
        }
    }
}