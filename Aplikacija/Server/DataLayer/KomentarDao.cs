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
    public class KomentarDao : IKomentarDao
    {
        private Context Context { get; set; }

        public KomentarDao(Context context)
        {
            Context = context;
        }

        public async Task<List<Komentar>> PreuzmiKomentareZaKnjigu(int knjigaId)
        {
            try
            {
                return await Context.Komentari
                                    .Include(k => k.Korisnik)
                                    .Include(k => k.Knjiga)
                                    .Where(k => k.Knjiga.Id == knjigaId)
                                    .OrderBy(k => k.Datum)
                                    .ToListAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Komentar> PreuzmiKomentarPoId(int komentarId)
        {
            try
            {
                return await Context.Komentari
                                    .Include(k => k.Korisnik)
                                    .Include(k => k.Knjiga)
                                    .Where(k => k.Id == komentarId)
                                    .FirstOrDefaultAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Komentar> DodajKomentar(Komentar komentar)
        {
            try
            {
                Context.Komentari.Add(komentar);
                await Context.SaveChangesAsync();
                return komentar;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Komentar> IzmeniKomentar(Komentar komentar)
        {
            try
            {
                Context.Komentari.Update(komentar);
                await Context.SaveChangesAsync();
                return komentar;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> ObrisiKomentar(Komentar komentar)
        {
            try
            {
                Context.Komentari.Remove(komentar);
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