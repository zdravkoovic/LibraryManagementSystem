using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IKnjigaDao
    {
        public Task<Knjiga> PreuzmiKnjiguPoId(int knjigaId);
        public Task<KnjigeStrane> PreuzmiKnjige(List<int> zanroviIds, List<int> rodoviIds, List<int> vrsteIds, List<int> jeziciIds, bool slobodna, int page, string pretraga);
        public Task<KnjigeStrane> PretraziKnjige(string pretraga, int page);
        public Task<List<Knjiga>> PreuzmiSveKnjigeAutora(int autorId);
        public Task<List<Knjiga>> PreuzmiKnjigeKojeCekaKorisnik(int korisnikId);
        public Task<Knjiga> DodajKnjigu(Knjiga knjiga);
        public Task<Knjiga> SacuvajIzmeneKnjige(Knjiga knjiga);
        public Task<bool> ObrisiKnjigu(Knjiga knjiga);
        public Task<int> PreuzmiBrojKnjiga();
    }
}