using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Parameters;

namespace Services.Interfaces
{
    public interface IIznajmljivanjeService
    {
        public Task<List<IznajmljivanjePrikaz>> PreuzmiIznajmljivanjaKorisnika(int korisnikId);
        public Task<List<IznajmljivanjePrikaz>> PreuzmiIstorijuIznajmljivanjaKnjige(int knjigaId);
        public Task<IznajmljivanjePrikaz> DodajIznajmljivanje(IznajmljivanjeParametri iznajmljivanjeParametri);
        public Task<IznajmljivanjePrikaz> VratiIznajmljenuKnjigu(int iznajmljivanjeId);
    }
}