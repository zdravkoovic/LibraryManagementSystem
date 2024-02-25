using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IRadnikService
    {
        public Task<List<RadnikPrikaz>> PreuzmiRadnike();
        public Task<List<RadnikPrikaz>> PretraziRadnike(string pretraga);
        public Task<RadnikPrikaz> PreuzmiRadnikaPoId(int radnikId);
        public Task<RadnikPrikaz> DodajRadnika(RadnikParametri radnikParametri);
        public Task<RadnikPrikaz> IzmeniRadnika(int radnikId, RadnikParametri radnikParametri);
        public Task<RadnikPrikaz> IzmeniLozinkuRadnika(int radnikId, LozinkaParametri lozinkaParametri);
    }
}