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
    public class VestDao : IVestDao
    {
        private Context Context { get; set; }

        public VestDao(Context context)
        {
            Context = context;
        }

        public async Task<VestiStrane> PreuzmiVesti(int page)
        {
            try
            {
                var brojVesti = Context.Vesti.Count();

                int brojStrana = (int)Math.Ceiling((decimal)brojVesti / 10);

                return new VestiStrane()
                {
                    Vesti = await Context.Vesti
                                    .Include(v => v.Radnik)
                                    .Include(v => v.Slike)
                                    .OrderByDescending(v => v.Datum)
                                    .Skip(10 * page)
                                    .Take(10)
                                    .ToListAsync(),
                    BrojStrana = brojStrana
                };
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Vest> PreuzmiVestPoId(int vestId)
        {
            try
            {
                return await Context.Vesti
                                    .Include(v => v.Radnik)
                                    .Include(v => v.Slike)
                                    .Where(v => v.Id == vestId)
                                    .FirstOrDefaultAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Vest> DodajVest(Vest vest)
        {
            try
            {
                Context.Vesti.Add(vest);
                await Context.SaveChangesAsync();
                return vest;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Vest> SacuvajIzmeneVesti(Vest vest)
        {
            try
            {
                Context.Vesti.Update(vest);
                await Context.SaveChangesAsync();
                return vest;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> ObrisiVest(Vest vest)
        {
            try
            {
                Context.Vesti.Remove(vest);
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