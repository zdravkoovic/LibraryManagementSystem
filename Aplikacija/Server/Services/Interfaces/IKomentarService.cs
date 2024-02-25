using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IKomentarService
    {
        public Task<List<KomentarPrikaz>> PreuzmiKomentareZaKnjigu(int knjigaId);
        public Task<KomentarPrikaz> DodajKomentar(KomentarParametri komentarParametri);
        public Task<KomentarPrikaz> IzmeniKomentar(int komentarId, KomentarParametri komentarParametri);
        public Task<bool> ObrisiKomentar(int komentarId);
    }
}