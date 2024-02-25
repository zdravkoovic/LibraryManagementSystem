using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IRadnikDao
    {
        public Task<Radnik> DodajRadnika(Radnik radnik);
        public Task<Radnik> SacuvajIzmeneRadnika(Radnik radnik);
        public Task<List<Radnik>> PretraziRadnike(string pretraga);
        public Task<Radnik> PreuzmiRadnikaPoId(int radnikId);
        public Task<List<Radnik>> PreuzmiRadnike();
        public Task<bool> PostojiRadnikSaKorisnickimImenom(string korisnickoIme);
        public Task<Radnik> PreuzmiRadnikaPriPrijavi(string korisnickoIme, string lozinka);
        public Task<Radnik> PreuzmiMenadzeraPoId(int menadzerId);
        public Task<int> PreuzmiBrojRadnika();
    }
}