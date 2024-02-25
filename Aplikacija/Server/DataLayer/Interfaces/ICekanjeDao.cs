using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface ICekanjeDao
    {
        public Task<int> PreuzmiBrojKorisnikaKojiCekajuKnjigu(int knjigaId);
        public Task<Cekanje> PreuzmiCekanjePoId(int cekanjeId);
        public Task<List<Cekanje>> PreuzmiCekanjaKorisnika(int korisnikId);
        public Task<bool> DodajCekanje(Cekanje cekanje);
        public Task<bool> ObrisiCekanje(Cekanje cekanje);
        public Task<bool> KorisnikCekaKnjigu(int korisnikId, int knjigaId);
        public Task<List<Cekanje>> PreuzmiCekanjaKnjige(int knjigaId);
    }
}