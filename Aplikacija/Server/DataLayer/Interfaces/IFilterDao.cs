using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IFilterDao
    {
        public Task<KnjizevniRod> PreuzmiKnjizevniRodPoId(int knjizevniRodId);
        public Task<KnjizevnaVrsta> PreuzmiKnjizevnuVrstuPoId(int knjizevnaVrstaId);
        public Task<List<KnjizevniZanr>> PreuzmiKnjizevneZanrovePoId(List<int> knjizevniZanroviIds);
        public Task<KnjizevniZanr> PreuzmiKnjizevniZanrPoId(int knjizevniZanrId);
        public Task<Jezik> PreuzmiJezikPoId(int jezikId);
        public Task<List<KnjizevniZanr>> PreuzmiKnjizevneZanrove();
        public Task<List<KnjizevniRod>> PreuzmiKnjizevneRodove();
        public Task<List<KnjizevnaVrsta>> PreuzmiKnjizevneVrste();
        public Task<List<Jezik>> PreuzmiJezike();
    }
}