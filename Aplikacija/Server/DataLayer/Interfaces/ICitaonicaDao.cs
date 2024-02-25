using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface ICitaonicaDao
    {
        public Task<Citaonica> PreuzmiCitaonicuPoId(int citaonicaId);
        public Task<List<Citaonica>> PreuzmiCitaoniceOgrankaBiblioteke(int ogranakBibliotekeId);
        public Task<Citaonica> DodajCitaonicu(Citaonica citaonica);
        public Task<Citaonica> SacuvajIzmeneCitaonice(Citaonica citaonica);
        public Task<bool> ObrisiCitaonicu(Citaonica citaonica);
    }
}