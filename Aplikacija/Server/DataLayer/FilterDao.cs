using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Models;
using Models.DatabaseCommunication;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class FilterDao : IFilterDao
    {
        private Context Context { get; set; }

        public FilterDao(Context context)
        {
            Context = context;
        }
        public async Task<List<KnjizevniZanr>> PreuzmiKnjizevneZanrovePoId(List<int> knjizevniZanroviIds)
        {
            try
            {
                return await Context.KnjizevniZanrovi.Where(kz => knjizevniZanroviIds.Contains(kz.Id))
                                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjizevniRod> PreuzmiKnjizevniRodPoId(int knjizevniRodId)
        {
            try
            {
                return await Context.KnjizevniRodovi.FindAsync(knjizevniRodId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjizevniZanr> PreuzmiKnjizevniZanrPoId(int knjizevniZanrId)
        {
            try
            {
                return await Context.KnjizevniZanrovi.FindAsync(knjizevniZanrId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjizevnaVrsta> PreuzmiKnjizevnuVrstuPoId(int knjizevnaVrstaId)
        {
            try
            {
                return await Context.KnjizevneVrste.FindAsync(knjizevnaVrstaId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Jezik> PreuzmiJezikPoId(int jezikId)
        {
            try
            {
                return await Context.Jezici.FindAsync(jezikId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjizevniZanr>> PreuzmiKnjizevneZanrove()
        {
            try
            {
                return await Context.KnjizevniZanrovi.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjizevniRod>> PreuzmiKnjizevneRodove()
        {
            try
            {
                return await Context.KnjizevniRodovi.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjizevnaVrsta>> PreuzmiKnjizevneVrste()
        {
            try
            {
                return await Context.KnjizevneVrste
                                    .Include(kv => kv.KnjizevniRod)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Jezik>> PreuzmiJezike()
        {
            try
            {
                return await Context.Jezici.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}