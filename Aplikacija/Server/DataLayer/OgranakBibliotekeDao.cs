using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DatabaseCommunication;

namespace DataLayer
{
    public class OgranakBibliotekeDao : IOgranakBibliotekeDao
    {
        private Context Context { get; set; }

        public OgranakBibliotekeDao(Context context)
        {
            Context = context;
        }
        public async Task<OgranakBiblioteke> PreuzmiOgranakBibliotekePoId(int ogranakBibliotekeId)
        {
            try
            {
                return await Context.OgranciBiblioteke
                                    .Include(ob => ob.Slike)
                                    .Where(ob => ob.Id == ogranakBibliotekeId)
                                    .FirstOrDefaultAsync();
            
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<OgranakBiblioteke>> PreuzmiOgrankeBiblioteke()
        {
            try
            {
                return await Context.OgranciBiblioteke
                                    .Include(ob => ob.Slike)
                                    .ToListAsync();
            
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<OgranakBiblioteke>> PreuzmiOgrankeGdeSeNalaziKnjiga(int knjigaId)
        {
            try
            {
                List<int> ogranciIds = await Context.FizickeKnjige
                                                .Include(fk => fk.OgranakBiblioteke)
                                                .Include(fk => fk.Knjiga)
                                                .Where(fk => fk.Knjiga.Id == knjigaId)
                                                .Select(fk => fk.OgranakBiblioteke.Id)
                                                .Distinct()
                                                .ToListAsync();

                return await Context.OgranciBiblioteke
                                    .Include(ob => ob.Slike)
                                    .Where(ob => ogranciIds.Contains(ob.Id))
                                    .ToListAsync();
            
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<OgranakBiblioteke> DodajOgranakBiblioteke(OgranakBiblioteke ogranakBiblioteke)
        {
            try
            {
                Context.OgranciBiblioteke.Add(ogranakBiblioteke);
                await Context.SaveChangesAsync();
                return ogranakBiblioteke;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<OgranakBiblioteke> SacuvajIzmeneOgrankaBiblioteke(OgranakBiblioteke ogranakBiblioteke)
        {
            try
            {
                Context.OgranciBiblioteke.Update(ogranakBiblioteke);
                await Context.SaveChangesAsync();
                return ogranakBiblioteke;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiOgranakBiblioteke(OgranakBiblioteke ogranakBiblioteke)
        {
            try
            {
                Context.OgranciBiblioteke.Remove(ogranakBiblioteke);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}