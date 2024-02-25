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
    public class RasporedDao : IRasporedDao
    {
        private Context Context { get; set; }

        public RasporedDao(Context context)
        {
            Context = context;
        }

        public async Task<Raspored> PreuzmiRasporedRadnika(int radnikId)
        {
            try
            {
                return await Context.Rasporedi
                                    .Include(r => r.Radnik)
                                    .Include(r => r.OgranakBiblioteke)
                                    .Include(r => r.Menadzer)
                                    .Where(r => r.Radnik.Id == radnikId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Raspored> DodajRaspored(Raspored raspored)
        {
            try
            {
                Context.Rasporedi.Add(raspored);
                await Context.SaveChangesAsync();
                return raspored;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Raspored> SacuvajIzmeneRasporeda(Raspored raspored)
        {
            try
            {
                Context.Rasporedi.Update(raspored);
                await Context.SaveChangesAsync();
                return raspored;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Raspored> PreuzmiRasporedPoId(int rasporedId)
        {
            try
            {
                return await Context.Rasporedi
                                    .Include(r => r.Radnik)
                                    .Include(r => r.OgranakBiblioteke)
                                    .Include(r => r.Menadzer)
                                    .Where(r => r.Id == rasporedId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Raspored>> PreuzmiRasporede()
        {
            try
            {
                return await Context.Rasporedi
                                    .Include(r => r.Radnik)
                                    .Include(r => r.OgranakBiblioteke)
                                    .Include(r => r.Menadzer)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}