using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface ICitanjeDao
    {
        public Task<List<Citanje>> PreuzmiCitanjaKorisnika(int korisnikId);
        public Task<List<Citanje>> PreuzmiTrenutnaCitanjaKorisnika(int korisnikId);
        public Task<List<Citanje>> PreuzmiTrenutnaCitanjaUCitaonici(int citaonicaId);
        public Task<List<Citanje>> PreuzmiCitanjaNaMestu(int mestoId);
        public Task<Citanje> DodajCitanje(Citanje citanje);
        public Task<Citanje> SacuvajIzmeneCitanja(Citanje citanje);
        public Task<Citanje> PreuzmiCitanjePoId(int citanjeId);
    }
}