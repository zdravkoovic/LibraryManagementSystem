using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Models;

namespace Services.Interfaces
{
    public interface IFilterService
    {
        public Task<List<KnjizevniZanrPrikaz>> PreuzmiKnjizevneZanrove();
        public Task<List<KnjizevniRodPrikaz>> PreuzmiKnjizevneRodove();
        public Task<List<KnjizevnaVrstaPrikaz>> PreuzmiKnjizevneVrste();
        public Task<List<JezikPrikaz>> PreuzmiJezike();
        public Task<FilteriPrikaz> PreuzmiFiltere();
    }
}