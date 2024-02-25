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
    public class CitaonicaDao : ICitaonicaDao
    {
        private Context Context { get; set; }

        public CitaonicaDao(Context context)
        {
            Context = context;
        }

        public async Task<Citaonica> DodajCitaonicu(Citaonica citaonica)
        {
            try
            {   
                Context.Citaonice.Add(citaonica);
                await Context.SaveChangesAsync();
                return citaonica;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiCitaonicu(Citaonica citaonica)
        {
            try
            {
                Context.Citaonice.Remove(citaonica);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Citaonica>> PreuzmiCitaoniceOgrankaBiblioteke(int ogranakBibliotekeId)
        {
            try
            {
                return await Context.Citaonice
                                .Include(c => c.OgranakBiblioteke)
                                .Where(c => c.OgranakBiblioteke.Id == ogranakBibliotekeId)
                                .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Citaonica> PreuzmiCitaonicuPoId(int citaonicaId)
        {
            try
            {
                return await Context.Citaonice
                                .Include(c => c.OgranakBiblioteke)
                                .Where(c => c.Id == citaonicaId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Citaonica> SacuvajIzmeneCitaonice(Citaonica citaonica)
        {
            try
            {
                Context.Citaonice.Add(citaonica);
                await Context.SaveChangesAsync();
                return citaonica;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}