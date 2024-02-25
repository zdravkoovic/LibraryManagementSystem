using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IKorisnikService
    {
        public Task<List<KorisnikPrikaz>> PretraziKorisnike(string pretraga);
        public Task<KorisnikPrikaz> PreuzmiKorisnikaPoId(int korisnikId);
        public Task<KorisnikPrikaz> DodajKorisnika(KorisnikParametri korisnikParametri);
        public Task<KorisnikPrikaz> IzmeniKorisnika(int korisnikId, KorisnikParametri korisnikParametri);
        public Task<bool> ObrisiKorisnika(int korisnikId);
        public Task<KorisnikPrikaz> IzmeniLozinkuKorisnika(int korisnikId, LozinkaParametri lozinkaParametri);
        public Task<KorisnikPrikaz> PlatiClanarinuKorisnika(int korisnikId);
        public Task<KorisnikPrikaz> IzmiriDugovanjaKorisnika(int korisnikId);
    }
}