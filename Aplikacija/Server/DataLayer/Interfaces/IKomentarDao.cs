using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IKomentarDao
    {
        public Task<List<Komentar>> PreuzmiKomentareZaKnjigu(int knjigaId);
        public Task<Komentar> PreuzmiKomentarPoId(int komentarId);
        public Task<Komentar> DodajKomentar(Komentar komentar);
        public Task<Komentar> IzmeniKomentar(Komentar komentar);
        public Task<bool> ObrisiKomentar(Komentar komentar);
    }
}