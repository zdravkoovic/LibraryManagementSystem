using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IIzdavacService
    {
        public Task<List<IzdavacPrikaz>> PreuzmiIzdavace(int page);
        public Task<List<IzdavacPrikaz>> PretragaIzdavaca(string pretraga, int page);
        public Task<IzdavacPrikaz> PreuzmiIzdavacaPoId(int izdavacId);
        public Task<IzdavacPrikaz> DodajIzdavaca(IzdavacParametri izdavacParametri);
        public Task<IzdavacPrikaz> IzmeniIzdavaca(int izdavacId, IzdavacParametri izdavacParametri);
        public Task<bool> ObrisiIzdavaca(int izdavacId);
    }
}