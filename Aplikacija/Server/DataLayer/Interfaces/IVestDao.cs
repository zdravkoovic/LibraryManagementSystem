using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IVestDao
    {
        public Task<VestiStrane> PreuzmiVesti(int page);
        public Task<Vest> PreuzmiVestPoId(int vestId);
        public Task<Vest> DodajVest(Vest vest);
        public Task<Vest> SacuvajIzmeneVesti(Vest vest);
        public Task<bool> ObrisiVest(Vest vest);
    }
}