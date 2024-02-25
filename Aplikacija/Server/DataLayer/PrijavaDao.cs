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
    public class PrijavaDao : IPrijavaDao
    {
        private Context Context { get; set; }
        
        public PrijavaDao(Context context)
        {
            Context = context;
        }

        public async Task<Prijava> DodajPrijavu(Prijava prijava)
        {
            try
            {
                Context.Prijave.Add(prijava);
                await Context.SaveChangesAsync();
                return prijava;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Prijava>> PreuzmiPrijaveRadnika(int radnikId)
        {
            try
            {
                return await Context.Prijave
                                    .Include(p => p.Radnik)
                                    .Include(p => p.OgranakBiblioteke)
                                    .Where(p => p.Radnik.Id == radnikId)
                                    .OrderByDescending(p => p.VremePrijave)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Prijava> PreuzmiPrijavuPoId(int prijavaId)
        {
            try
            {
                return await Context.Prijave
                                    .Include(p => p.Radnik)
                                    .Include(p => p.OgranakBiblioteke)
                                    .Where(p => p.Id == prijavaId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Prijava> SacuvajIzmenePrijave(Prijava prijava)
        {
            try
            {
                Context.Prijave.Update(prijava);
                await Context.SaveChangesAsync();
                return prijava;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Prijava> PreuzmiTrenutnuPrijavuRadnika(int radnikId)
        {
            try
            {
                return await Context.Prijave
                                    .Include(p => p.Radnik)
                                    .Include(p => p.OgranakBiblioteke)
                                    .Where(p => p.Radnik.Id == radnikId && p.VremeOdjave == null)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}