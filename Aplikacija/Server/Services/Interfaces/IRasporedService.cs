using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IRasporedService
    {
        public Task<RasporedPrikaz> PreuzmiRasporedRadnika(int radnikId);
        public Task<List<RasporedPrikaz>> PreuzmiRasporede();
        //public Task<RasporedPrikaz> PreuzmiRasporedPoId(int rasporedId);
        public Task<RasporedPrikaz> IzmeniRaspored(int rasporedId, RasporedParametri rasporedParametri);
    }
}