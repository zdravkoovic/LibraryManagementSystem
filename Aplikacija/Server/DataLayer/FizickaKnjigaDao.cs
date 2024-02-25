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
    public class FizickaKnjigaDao : IFizickaKnjigaDao
    {
        private Context Context { get; set; }

        public FizickaKnjigaDao(Context context)
        {
            Context = context;
        }

        public async Task<FizickaKnjiga> DodajFizickuKnjigu(FizickaKnjiga fizickaKnjiga)
        {
            try
            {
                Context.FizickeKnjige.Add(fizickaKnjiga);
                await Context.SaveChangesAsync();
                return fizickaKnjiga;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiFizickuKnjigu(FizickaKnjiga fizickaKnjiga)
        {
            try
            {
                Context.FizickeKnjige.Remove(fizickaKnjiga);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> PreuzmiBrojFizickihKnjiga(int knjigaId)
        {
            try
            {
                return Context.FizickeKnjige
                                .Include(fk => fk.Knjiga)
                                .Where(fk => fk.Knjiga.Id == knjigaId)
                                .CountAsync();                                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> PreuzmiBrojFizickihKnjigaIzdavaca(int izdavacId)
        {
            try
            {
                return Context.FizickeKnjige
                                .Include(fk => fk.Izdavac)
                                .Where(fk => fk.Izdavac.Id == izdavacId)
                                .CountAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Task<List<FizickaKnjiga>> PreuzmiFizickeKnjigeUOgranku(int knjigaId, int ogranakBibliotekeId)
        {
            try
            {
                return Context.FizickeKnjige
                                .Include(fk => fk.Knjiga)
                                .Include(fk => fk.OgranakBiblioteke)
                                .Include(fk =>fk.Izdavac)
                                .Include(fk => fk.Jezik)
                                .Where(fk => fk.Knjiga.Id == knjigaId && fk.OgranakBiblioteke.Id == ogranakBibliotekeId)
                                .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<FizickaKnjiga> PreuzmiFizickuKnjiguPoId(int fizickaKnjigaId)
        {
            try
            {
                return Context.FizickeKnjige
                                .Include(fk => fk.Knjiga)
                                .Include(fk => fk.OgranakBiblioteke)
                                .Include(fk => fk.Izdavac)
                                .Include(fk => fk.Jezik)
                                .Where(fk => fk.Id == fizickaKnjigaId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<FizickaKnjiga> PreuzmiFizickuKnjiguPoSifri(string fizickaKnjigaSifra)
        {
            try
            {
                return Context.FizickeKnjige
                                .Include(fk => fk.Knjiga)
                                .Include(fk => fk.OgranakBiblioteke)
                                .Include(fk =>fk.Izdavac)
                                .Include(fk => fk.Jezik)
                                .Where(fk => fk.Sifra == fizickaKnjigaSifra)
                                .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FizickaKnjiga> SacuvajIzmeneFizickeKnjige(FizickaKnjiga fizickaKnjiga)
        {
            try
            {
                Context.FizickeKnjige.Update(fizickaKnjiga);
                await Context.SaveChangesAsync();
                return fizickaKnjiga;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<FizickaKnjiga>> PreuzmiZauzeteFizickeKnjige(int knjigaId)
        {
            try
            {
                return await Context.FizickeKnjige
                                .Include(fk => fk.Knjiga)
                                .Include(fk => fk.OgranakBiblioteke)
                                .Include(fk =>fk.Izdavac)
                                .Include(fk => fk.Jezik)
                                .Where(fk => fk.Knjiga.Id == knjigaId && fk.Slobodna == false)
                                .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> PreuzmiBrojFizickihKnjiga()
        {
            try
            {
                return await Context.FizickeKnjige
                                    .CountAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}