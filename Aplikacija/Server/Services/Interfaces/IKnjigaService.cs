using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parameters;

namespace Services.Interfaces
{
    public interface IKnjigaService
    {
        public Task<KnjigaPrikaz> PreuzmiKnjiguPoId(int knjigaId);
        public Task<KnjigaSaStranama> PreuzmiKnjige(string zanrovi, string rodovi, string vrste, string jezici, bool slobodna, int page, string pretraga);
        public Task<KnjigaSaStranama> PretraziKnjige(string pretraga, int page);
        public Task<List<KnjigaPrikaz>> PreuzmiSveKnjigeAutora(int autorId);
        public Task<List<KnjigaPrikaz>> PreuzmiKnjigeKojeCekaKorisnik(int korisnikId);
        public Task<KnjigaPrikaz> DodajKnjigu(KnjigaParametri knjigaParametri);
        public Task<KnjigaPrikaz> IzmeniKnjigu(int knjigaId, KnjigaParametri knjigaParametri);
        public Task<bool> ObrisiKnjigu(int knjigaId);
        public Task<KnjigaPrikaz> DodajSlikuKnjizi(int knjigaId, SlikaParametar slikaForm);
    }
}