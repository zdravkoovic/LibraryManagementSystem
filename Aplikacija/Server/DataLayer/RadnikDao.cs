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
    public class RadnikDao : IRadnikDao
    {
        private Context Context { get; set; }

        public RadnikDao(Context context)
        {
            Context = context;
        }

        public async Task<Radnik> DodajRadnika(Radnik radnik)
        {
            try
            {
                Context.Radnici.Add(radnik);
                await Context.SaveChangesAsync();
                return radnik;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> PostojiRadnikSaKorisnickimImenom(string korisnickoIme)
        {
            try
            {
                return await Context.Radnici
                                    .Where(r => r.KorisnickoIme == korisnickoIme)
                                    .CountAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Radnik> PreuzmiRadnikaPoId(int radnikId)
        {
            try
            {
                return await Context.Radnici   
                                    .FindAsync(radnikId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Radnik>> PreuzmiRadnike()
        {
            try
            {
                return await Context.Radnici.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Radnik> SacuvajIzmeneRadnika(Radnik radnik)
        {
            try
            {
                Context.Radnici.Update(radnik);
                await Context.SaveChangesAsync();
                return radnik;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Radnik> PreuzmiRadnikaPriPrijavi(string korisnickoIme, string lozinka)
        {
            try
            {
                Radnik r = await Context.Radnici
                                    .Where(r => r.KorisnickoIme == korisnickoIme)
                                    .FirstOrDefaultAsync();
                                    
                if (r == null || !BCrypt.Net.BCrypt.Verify(lozinka, r.Lozinka))
                {
                    throw new Exception("Pogrešno korisničko ime ili lozinka.");
                }

                return r;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Radnik> PreuzmiMenadzeraPoId(int menadzerId)
        {
            try
            {
                return await Context.Radnici   
                                    .Where(r => r.Id == menadzerId 
                                    && r.Menadzer == true)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Radnik>> PretraziRadnike(string pretraga)
        {
            try
            {
                return await Context.Radnici
                                    .Where(r => r.Ime.Contains(pretraga)
                                    || r.Prezime.Contains(pretraga)
                                    || r.KorisnickoIme.Contains(pretraga)
                                    || pretraga.Contains(r.Ime)
                                    || pretraga.Contains(r.Prezime)
                                    || pretraga.Contains(r.KorisnickoIme))
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> PreuzmiBrojRadnika()
        {
            try
            {
                return await Context.Radnici
                                    .CountAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}