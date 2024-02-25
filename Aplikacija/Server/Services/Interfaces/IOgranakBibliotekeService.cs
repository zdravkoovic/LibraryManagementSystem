using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Parameters;

namespace Services.Interfaces
{
    public interface IOgranakBibliotekeService
    {
        public Task<List<OgranakBibliotekePrikaz>> PreuzmiOgrankeBiblioteke();
        public Task<List<OgranakBibliotekePrikaz>> PreuzmiOgrankeGdeSeNalaziKnjiga(int knjigaId);
        public Task<OgranakBibliotekePrikaz> PreuzmiOgranakBibliotekePoId(int ogranakBibliotekeId);
        public Task<OgranakBibliotekePrikaz> DodajOgranakBiblioteke(OgranakBibliotekeParametri ogranakBibliotekeParametri);
        public Task<OgranakBibliotekePrikaz> IzmeniOgranakBiblioteke(int ogranakBibliotekeId, OgranakBibliotekeParametri ogranakBibliotekeParametri);
        public Task<bool> ObrisiOgranakBiblioteke(int ogranakBibliotekeId);
        public Task<OgranakBibliotekePrikaz> DodajSlikeOgrankuBiblioteke(int ogranakBibliotekeId, List<SlikaParametar> slikeForms);
    }
}