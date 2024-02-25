using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IOgranakBibliotekeDao
    {
        public Task<OgranakBiblioteke> PreuzmiOgranakBibliotekePoId(int ogranakBibliotekeId);
        public Task<List<OgranakBiblioteke>> PreuzmiOgrankeBiblioteke();
        public Task<List<OgranakBiblioteke>> PreuzmiOgrankeGdeSeNalaziKnjiga(int knjigaId);
        public Task<OgranakBiblioteke> DodajOgranakBiblioteke(OgranakBiblioteke ogranakBiblioteke);
        public Task<OgranakBiblioteke> SacuvajIzmeneOgrankaBiblioteke(OgranakBiblioteke ogranakBiblioteke);
        public Task<bool> ObrisiOgranakBiblioteke(OgranakBiblioteke ogranakBiblioteke);
    }
}