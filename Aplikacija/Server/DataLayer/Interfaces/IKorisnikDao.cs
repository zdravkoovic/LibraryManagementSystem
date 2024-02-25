using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DataLayer.Interfaces
{
    public interface IKorisnikDao
    {
        public Task<Korisnik> DodajKorisnika(Korisnik korisnik);
        public Task<Korisnik> SacuvajIzmeneKorisnika(Korisnik korisnik);
        public Task<bool> ObrisiKorisnika(Korisnik korisnik);
        public Task<List<Korisnik>> PretraziKorisnike(string pretraga);
        public Task<Korisnik> PreuzmiKorisnikaPoId(int korisnikId);
        public Task<bool> PostojiKorisnikSaKorisnickimImenom(string korisnickoIme);
        public Task<Korisnik> PreuzmiKorisnikaPriPrijavi(string korisnickoIme, string lozinka);
        public Task<List<Korisnik>> PreuzmiKorisnikeDatumProverePlacanjaClanarine();
        public Task<int> PreuzmiBrojKorisnika();
    }
}