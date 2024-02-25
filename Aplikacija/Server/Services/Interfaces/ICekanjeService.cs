using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface ICekanjeService
    {
        public Task<int> PreuzmiBrojKorisnikaKojiCekajuKnjigu(int knjigaId);
        public Task<List<CekanjePrikaz>> PreuzmiCekanjaKorisnika(int korisnikId);
        public Task<bool> DodajCekanje(CekanjeParametri cekanjeParametri);
        public Task<bool> ObrisiCekanje(int cekanjeId);
    }
}