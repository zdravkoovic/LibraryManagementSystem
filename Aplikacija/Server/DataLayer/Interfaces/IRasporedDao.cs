using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IRasporedDao
    {
        public Task<Raspored> PreuzmiRasporedRadnika(int radnikId);
        public Task<Raspored> DodajRaspored(Raspored raspored);
        public Task<Raspored> SacuvajIzmeneRasporeda(Raspored raspored);
        public Task<Raspored> PreuzmiRasporedPoId(int rasporedId);
        public Task<List<Raspored>> PreuzmiRasporede();
    }
}