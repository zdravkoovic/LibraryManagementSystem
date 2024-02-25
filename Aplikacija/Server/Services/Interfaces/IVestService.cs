using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Parameters;

namespace Services.Interfaces
{
    public interface IVestService
    {
        public Task<VestSaStranama> PreuzmiVesti(int page);
        public Task<VestPrikaz> PreuzmiVestPoId(int vestId);
        public Task<VestPrikaz> DodajVest(VestParametri vestParametri);
        public Task<VestPrikaz> IzmeniVest(int vestId, VestParametri vestParametri);
        public Task<bool> ObrisiVest(int vestId);
        public Task<VestPrikaz> DodajSlikeVesti(int vestId, List<SlikaParametar> slikeForms);
    }
}