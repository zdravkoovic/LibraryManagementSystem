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
    public class CitanjeDao : ICitanjeDao
    {
        private Context Context { get; set; }

        public CitanjeDao(Context context)
        {
            Context = context;
        }
        
        public async Task<List<Citanje>> PreuzmiCitanjaKorisnika(int korisnikId)
        {
            try
            {
                return await Context.Citanja
                                    .Include(c => c.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.RadnikDodelio)
                                    .Include(c => c.Mesto)
                                    .Where(c => c.Korisnik.Id == korisnikId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Citanje>> PreuzmiTrenutnaCitanjaKorisnika(int korisnikId)
        {
            try
            {
                return await Context.Citanja
                                    .Include(c => c.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.RadnikDodelio)
                                    .Include(c => c.Mesto)
                                    .Where(c => c.Korisnik.Id == korisnikId && c.VremeVracanjaKnjige == null)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Citanje>> PreuzmiTrenutnaCitanjaUCitaonici(int citaonicaId)
        {
            try
            {
                // RIZICNO
                return await Context.Citanja
                                    .Include(c => c.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.RadnikDodelio)
                                    .Include(c => c.Mesto)
                                    .ThenInclude(m => m.Citaonica)
                                    .Where(c => c.VremeVracanjaKnjige == null
                                    &&  c.Mesto.Citaonica.Id == citaonicaId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Citanje> DodajCitanje(Citanje citanje)
        {
            try
            {
                Context.Citanja.Add(citanje);
                await Context.SaveChangesAsync();
                return citanje;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Citanje> SacuvajIzmeneCitanja(Citanje citanje)
        {
            try
            {
                Context.Citanja.Update(citanje);
                await Context.SaveChangesAsync();
                return citanje;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Citanje> PreuzmiCitanjePoId(int citanjeId)
        {
            try
            {
                return await Context.Citanja
                                    .Include(c => c.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.RadnikDodelio)
                                    .Include(c => c.Mesto)
                                    .Where(c => c.Id == citanjeId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Citanje>> PreuzmiCitanjaNaMestu(int mestoId)
        {
            try
            {
                return await Context.Citanja
                                    .Include(c => c.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(c => c.Korisnik)
                                    .Include(c => c.RadnikDodelio)
                                    .Include(c => c.Mesto)
                                    .Where(c => c.Mesto.Id == mestoId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}