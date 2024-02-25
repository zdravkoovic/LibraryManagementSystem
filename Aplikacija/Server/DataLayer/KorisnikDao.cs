using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DatabaseCommunication;

namespace DataLayer
{
    public class KorisnikDao : IKorisnikDao
    {
        private Context Context { get; set; }

        public KorisnikDao(Context context)
        {
            Context = context;
        }

        public async Task<Korisnik> DodajKorisnika(Korisnik korisnik)
        {
            try
            {
                Context.Korisnici.Add(korisnik);
                await Context.SaveChangesAsync();
                return korisnik;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiKorisnika(Korisnik korisnik)
        {
            try
            {
                Context.Korisnici.Remove(korisnik);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Korisnik>> PretraziKorisnike(string pretraga)
        {
            try
            {
                return await Context.Korisnici
                                    .Where(k => k.Ime.Contains(pretraga)
                                    || pretraga.Contains(k.Ime)
                                    || k.Prezime.Contains(pretraga)
                                    || pretraga.Contains(k.Prezime)
                                    || k.KorisnickoIme.Contains(pretraga)
                                    || pretraga.Contains(k.KorisnickoIme))
                                    .Distinct()
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Korisnik> PreuzmiKorisnikaPoId(int korisnikId)
        {
            try
            {
                return await Context.Korisnici
                                    .FindAsync(korisnikId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Korisnik> SacuvajIzmeneKorisnika(Korisnik korisnik)
        {
            try
            {
                Context.Korisnici.Update(korisnik);
                await Context.SaveChangesAsync();
                return korisnik;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> PostojiKorisnikSaKorisnickimImenom(string korisnickoIme)
        {
            try
            {
                return await Context.Korisnici
                                    .Where(k => k.KorisnickoIme == korisnickoIme)
                                    .CountAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Korisnik> PreuzmiKorisnikaPriPrijavi(string korisnickoIme, string lozinka)
        {
            try
            {
                Korisnik k = await Context.Korisnici
                                    .Where(k => k.KorisnickoIme == korisnickoIme)
                                    .FirstOrDefaultAsync();
                
                if (k == null || !BCrypt.Net.BCrypt.Verify(lozinka, k.Lozinka))
                {
                    throw new Exception("Pogrešno korisničko ime ili lozinka.");
                }

                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Korisnik>> PreuzmiKorisnikeDatumProverePlacanjaClanarine()
        {
            try
            {
                return await Context.Korisnici
                                    .Where(k => k.DatumProverePlacanjaClanarine == DateTime.Now.Date)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> PreuzmiBrojKorisnika()
        {
            try
            {
                return await Context.Korisnici
                                    .CountAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}