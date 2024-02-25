using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Parameters;

namespace Services.Interfaces
{
    public interface IAutorService
    {
        public Task<AutorSaStranama> PreuzmiAutore(int page);
        public Task<AutorSaStranama> PretraziAutore(string pretraga, int page);
        public Task<AutorPrikaz> PreuzmiAutoraPoId(int autorId);
        public Task<AutorPrikaz> DodajAutora(AutorParametri autorParametri);
        public Task<AutorPrikaz> IzmeniAutora(int autorId, AutorParametri autorParametri);
        public Task<bool> ObrisiAutora(int autorId);
        public Task<AutorPrikaz> DodajSlikuAutoru(int autorId, SlikaParametar slika);
    }
}