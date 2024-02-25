using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IPrijavaService
    {
        public Task<List<PrijavaPrikaz>> PreuzmiPrijaveRadnika(int radnikId);
        public Task<PrijavaPrikaz> PrijavaRadnika(PrijavaParametri prijavaParametri);
        public Task<KorisnikPrikaz> PrijavaKorisnika(PrijavaParametri prijavaParametri);
        public Task<bool> OdjavaRadnika(int prijavaId);
    }
}