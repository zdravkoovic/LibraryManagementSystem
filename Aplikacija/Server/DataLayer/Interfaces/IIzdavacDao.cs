using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IIzdavacDao
    {
        public Task<List<Izdavac>> PreuzmiIzdavace(int page);
        public Task<List<Izdavac>> PretragaIzdavaca(string pretraga, int page);
        public Task<Izdavac> PreuzmiIzdavacaPoId(int izdavacId);
        public Task<Izdavac> DodajIzdavaca(Izdavac izdavac);
        public Task<Izdavac> IzmeniIzdavaca(Izdavac izdavac);
        public Task<bool> ObrisiIzdavaca(Izdavac izdavac);
    }
}