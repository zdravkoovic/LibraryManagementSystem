using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IMestoDao
    {
        public Task<List<Mesto>> PreuzmiZauzetaMestaCitaonice(int citaonicaId);
        public Task<List<Mesto>> PreuzmiMestaCitaonice(int citaonicaId);
        public Task<Mesto> PreuzmiMestoPoId(int mestoId);
        public Task<Mesto> DodajMesto(Mesto mesto);
        public Task<Mesto> SacuvajIzmeneMesta(Mesto mesto);
        public Task<bool> ObrisiMesto(Mesto mesto);
        public Task<Mesto> PreuzmiMestoUCitaoniciNaLokaciji(int citaonicaId, int x, int y);
    }
}