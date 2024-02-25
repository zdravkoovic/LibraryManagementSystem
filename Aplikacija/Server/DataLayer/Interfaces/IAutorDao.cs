using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IAutorDao
    {
        public Task<Autor> PreuzmiAutoraPoId(int autorId);
        public Task<AutoriStrane> PreuzmiAutore(int page);
        public Task<AutoriStrane> PretraziAutore(string pretraga, int page);
        public Task<Autor> DodajAutora(Autor autor);
        public Task<Autor> SacuvajIzmeneAutora(Autor autor);
        public Task<bool> ObrisiAutora(Autor autor);
    }
}