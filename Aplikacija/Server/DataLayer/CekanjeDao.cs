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
    public class CekanjeDao : ICekanjeDao
    {
        private Context Context { get; set; }

        public CekanjeDao(Context context)
        {
            Context = context;
        }

        public async Task<int> PreuzmiBrojKorisnikaKojiCekajuKnjigu(int knjigaId)
        {
            try
            {
                return await Context.Cekanja
                            .Include(c => c.Korisnik)
                            .Include(c => c.Knjiga)
                            .ThenInclude(k => k.Slika)
                            .Where(c => c.Knjiga.Id == knjigaId)
                            .CountAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Cekanje>> PreuzmiCekanjaKorisnika(int korisnikId)
        {
            try
            {
                return await Context.Cekanja
                            .Include(c => c.Korisnik)
                            .Include(c => c.Knjiga)
                            .ThenInclude(k => k.Slika)
                            .Where(c => c.Korisnik.Id == korisnikId)
                            .ToListAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Cekanje> PreuzmiCekanjePoId(int cekanjeId)
        {
            try
            {
                return await Context.Cekanja
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.Knjiga)
                                    .ThenInclude(k => k.Slika)
                                    .Where(c => c.Id == cekanjeId)
                                    .FirstOrDefaultAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DodajCekanje(Cekanje cekanje)
        {
            try
            {
                Context.Cekanja.Add(cekanje);
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiCekanje(Cekanje cekanje)
        {
            try
            {
                Context.Cekanja.Remove(cekanje);
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> KorisnikCekaKnjigu(int korisnikId, int knjigaId)
        {
            try
            {
                return await Context.Cekanja
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.Knjiga)
                                    .Where(c => c.Korisnik.Id == korisnikId 
                                    && c.Knjiga.Id == knjigaId)
                                    .CountAsync() > 0;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Cekanje>> PreuzmiCekanjaKnjige(int knjigaId)
        {
            try
            {
                return await Context.Cekanja
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.Knjiga)
                                    .Where(c => c.Knjiga.Id == knjigaId)
                                    .ToListAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}