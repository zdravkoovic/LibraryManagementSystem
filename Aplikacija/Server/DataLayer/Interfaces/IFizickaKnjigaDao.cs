using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Models;
using Parameters;

namespace DataLayer.Interfaces
{
    public interface IFizickaKnjigaDao
    {
        public Task<List<FizickaKnjiga>> PreuzmiFizickeKnjigeUOgranku(int knjigaId, int ogranakBibliotekeId);
        public Task<List<FizickaKnjiga>> PreuzmiZauzeteFizickeKnjige(int knjigaId);
        public Task<FizickaKnjiga> PreuzmiFizickuKnjiguPoId(int fizickaKnjigaId);
        public Task<FizickaKnjiga> PreuzmiFizickuKnjiguPoSifri(string fizickaKnjigaSifra);
        public Task<FizickaKnjiga> DodajFizickuKnjigu(FizickaKnjiga fizickaKnjiga);
        public Task<FizickaKnjiga> SacuvajIzmeneFizickeKnjige(FizickaKnjiga fizickaKnjiga);
        public Task<bool> ObrisiFizickuKnjigu(FizickaKnjiga fizickaKnjiga);
        public Task<int> PreuzmiBrojFizickihKnjiga(int knjigaId);
        public Task<int> PreuzmiBrojFizickihKnjigaIzdavaca(int izdavacId);
        public Task<int> PreuzmiBrojFizickihKnjiga();
    }
}