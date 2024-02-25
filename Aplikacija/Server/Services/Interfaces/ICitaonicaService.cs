using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface ICitaonicaService
    {
        public Task<List<CitaonicaPrikaz>> PreuzmiCitaoniceOgrankaBiblioteke(int ogranakBibliotekeId);
        public Task<CitaonicaPrikaz> PreuzmiCitaonicuPoId(int citaonicaId);
        public Task<CitaonicaPrikaz> DodajCitaonicu(CitaonicaParametri citaonicaParametri);
        public Task<CitaonicaPrikaz> IzmeniCitaonicu(int citaonicaId, CitaonicaParametri citaonicaParametri);
        public Task<bool> ObrisiCitaonicu(int citaonicaId);
    }
}