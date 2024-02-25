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
    public class IznajmljivanjeDao : IIznajmljivanjeDao
    {
        private Context Context { get; set; }

        public IznajmljivanjeDao(Context context)
        {
            Context = context;
        }

        public async Task<List<Iznajmljivanje>> PreuzmiIznajmljivanjaKorisnika(int korisnikId)
        {
            try
            {
                return await Context.Iznajmljivanja
                                    .Include(i => i.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(i => i.Korisnik)
                                    .Include(i => i.RadnikDodelio)
                                    .Include(i => i.OgranakBiblioteke)
                                    .Where(i => i.Korisnik.Id == korisnikId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Iznajmljivanje>> PreuzmiTrenutnaIznajmljivanjaKorisnika(int korisnikId)
        {
            try
            {
                return await Context.Iznajmljivanja
                                    .Include(i => i.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(i => i.Korisnik)
                                    .Include(i => i.RadnikDodelio)
                                    .Include(i => i.OgranakBiblioteke)
                                    .Where(i => i.Korisnik.Id == korisnikId && i.DatumVracanja == null)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Iznajmljivanje> PreuzmiIznajmljivanjePoId(int iznajmljivanjeId)
        {
            try
            {
                return await Context.Iznajmljivanja
                                    .Include(i => i.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(i => i.Korisnik)
                                    .Include(i => i.RadnikDodelio)
                                    .Include(i => i.OgranakBiblioteke)
                                    .Where(i => i.Id == iznajmljivanjeId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Iznajmljivanje> DodajIznajmljivanje(Iznajmljivanje iznajmljivanje)
        {
            try
            {
                Context.Iznajmljivanja.Add(iznajmljivanje);
                await Context.SaveChangesAsync();
                return iznajmljivanje;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Iznajmljivanje> SacuvajIzmeneIznajmljivanja(Iznajmljivanje iznajmljivanje)
        {
            try
            {
                Context.Iznajmljivanja.Update(iznajmljivanje);
                await Context.SaveChangesAsync();
                return iznajmljivanje;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Iznajmljivanje>> PreuzmiIstorijuIznajmljivanjaKnjige(int fizickaKnjigaId)
        {
            try
            {
                return await Context.Iznajmljivanja
                                    .Include(i => i.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(i => i.Korisnik)
                                    .Include(i => i.RadnikDodelio)
                                    .Include(i => i.OgranakBiblioteke)
                                    .Where(i => i.FizickaKnjiga.Id == fizickaKnjigaId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Iznajmljivanje>> PreuzmiDanasnjeProvere()
        {
            try
            {
                return await Context.Iznajmljivanja
                                    .Include(i => i.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(i => i.Korisnik)
                                    .Include(i => i.RadnikDodelio)
                                    .Include(i => i.OgranakBiblioteke)
                                    .Where(i => i.DatumProvere.Date == DateTime.Now.Date)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Iznajmljivanje>> PreuzmiIznajmljivanjaKorisnikaKojiTrebaDaSeObaveste()
        {
            try
            {
                return await Context.Iznajmljivanja
                                    .Include(i => i.FizickaKnjiga)
                                    .ThenInclude(fk => fk.Knjiga)
                                    .Include(i => i.Korisnik)
                                    .Include(i => i.RadnikDodelio)
                                    .Include(i => i.OgranakBiblioteke)
                                    .Where(i => i.DatumProvere.AddDays(-1) == DateTime.Now.Date)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}