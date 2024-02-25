using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IFizickaKnjigaService
    {
        public Task<List<FizickaKnjigaPrikaz>> PreuzmiFizickeKnjige(int knjigaId, int ogranakBibliotekebibliotekeId);
        public Task<FizickaKnjigaPrikaz> PreuzmiFizickuKnjiguPoId(int fizickaKnjigaId);
        public Task<FizickaKnjigaPrikaz> PreuzmiFizickuKnjiguPoSifri(string fizickaKnjigaSifra);
        public Task<List<FizickaKnjigaPrikaz>> DodajFizickeKnjige(FizickaKnjigaParametri fizickaKnjigaParametri);
        public Task<FizickaKnjigaPrikaz> IzmeniFizickuKnjigu(int fizickaKnjigaId, FizickaKnjigaParametri fizickaKnjigaParametri);
        public Task<bool> ObrisiFizickuKnjigu(int fizickaKnjigaId);
    }
}