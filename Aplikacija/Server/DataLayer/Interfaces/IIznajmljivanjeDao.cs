using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IIznajmljivanjeDao
    {
        public Task<List<Iznajmljivanje>> PreuzmiIznajmljivanjaKorisnika(int korisnikId);
        public Task<List<Iznajmljivanje>> PreuzmiTrenutnaIznajmljivanjaKorisnika(int korisnikId);
        public Task<Iznajmljivanje> PreuzmiIznajmljivanjePoId(int iznajmljivanjeId);
        public Task<Iznajmljivanje> DodajIznajmljivanje(Iznajmljivanje iznajmljivanje);
        public Task<Iznajmljivanje> SacuvajIzmeneIznajmljivanja(Iznajmljivanje iznajmljivanje);
        public Task<List<Iznajmljivanje>> PreuzmiIstorijuIznajmljivanjaKnjige(int fizickaKnjigaId);
        public Task<List<Iznajmljivanje>> PreuzmiDanasnjeProvere();
        public Task<List<Iznajmljivanje>> PreuzmiIznajmljivanjaKorisnikaKojiTrebaDaSeObaveste();
    }
}