using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface ISlikaDao
    {
        public Task<Slika> DodajSliku(string link);
        public Task<List<Slika>> DodajSlike(List<string> linkovi);
        public Task<bool> ObrisiSliku(Slika slika);
        public Task<bool> ObrisiSlike(List<Slika> slike);
        public Task<Slika> PreuzmiSlikuPoId(int slikaId);
        public Task<List<Slika>> PreuzmiSlikePoId(List<int> slikeIds);
        public Task<List<Slika>> PreuzmiSlikePoImenu(List<string> slikeImena);
        public Task<Slika> PreuzmiSlikuPoImenu(string slikaIme);
    }
}