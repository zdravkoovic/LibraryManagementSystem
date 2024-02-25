using System.Threading.Tasks;
using DataLayer.Interfaces;
using Models;
using System;
using Models.DatabaseCommunication;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer
{
    public class IzdavacDao : IIzdavacDao
    {
        private Context Context { get; set; }

        public IzdavacDao(Context context)
        {
            Context = context;
        }

        public async Task<List<Izdavac>> PreuzmiIzdavace(int page)
        {
            try
            {
                return await Context.Izdavaci
                                    .OrderBy(i => i.Naziv)
                                    .Skip(10 * page)
                                    .Take(10)
                                    .ToListAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Izdavac>> PretragaIzdavaca(string pretraga, int page)
        {
            try
            {
                return await Context.Izdavaci
                                    .Where(i => i.Naziv.Contains(pretraga))
                                    .OrderBy(i => i.Naziv)
                                    .Skip(10 * page)
                                    .Take(10)
                                    .ToListAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Izdavac> PreuzmiIzdavacaPoId(int izdavacId)
        {
            try
            {
                return await Context.Izdavaci.FindAsync(izdavacId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Izdavac> DodajIzdavaca(Izdavac izdavac)
        {
            try
            {
                Context.Izdavaci.Add(izdavac);
                await Context.SaveChangesAsync();
                return izdavac;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Izdavac> IzmeniIzdavaca(Izdavac izdavac)
        {
            try
            {
                Context.Izdavaci.Update(izdavac);
                await Context.SaveChangesAsync();
                return izdavac;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiIzdavaca(Izdavac izdavac)
        {
            try
            {
                Context.Izdavaci.Remove(izdavac);
                await Context.SaveChangesAsync();
                return true;
            }   
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}