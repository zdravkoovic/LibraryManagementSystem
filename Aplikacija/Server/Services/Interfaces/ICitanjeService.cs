using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface ICitanjeService
    {
        public Task<List<CitanjePrikaz>> PreuzmiCitanjaKorisnika(int korisnikId);
        public Task<List<CitanjePrikaz>> PreuzmiTrenutnaCitanjaUCitaonici(int citaonicaId);
        public Task<List<CitanjePrikaz>> PreuzmiCitanjaNaMestu(int mestoId);
        public Task<CitanjePrikaz> DodajCitanje(CitanjeParametri citanjeParametri);
        public Task<CitanjePrikaz> VratiKnjigu(int citanjeId);
        public Task<CitanjePrikaz> PreuzmiCitanjePoId(int citanjeId);
    }
}