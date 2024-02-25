using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IMestoService
    {
        public Task<List<MestoPrikaz>> PreuzmiMestaCitaonice(int citaonicaId);
        public Task<MestoPrikaz> PreuzmiMestoPoId(int mestoId);
        public Task<MestoPrikaz> DodajMesto(MestoParametri mestoParametri);
        public Task<MestoPrikaz> IzmeniMesto(int mestoId, MestoParametri mestoParametri);
        public Task<bool> ObrisiMesto(int mestoId);
    }
}