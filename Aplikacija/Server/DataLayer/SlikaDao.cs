using System.Threading.Tasks;
using DataLayer.Interfaces;
using Models;
using Models.DatabaseCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class SlikaDao : ISlikaDao
    {
        private Context Context { get; set; }

        public SlikaDao(Context context)
        {
            Context = context;
        }
        
        public async Task<Slika> DodajSliku(string link)
        {
            try
            {
                Slika slika = new Slika()
                {
                    Link = link
                };

                Context.Slike.Add(slika);
                await Context.SaveChangesAsync();
                
                return slika;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Slika>> DodajSlike(List<string> linkovi)
        {
            List<Slika> lista = new List<Slika>();

            try
            {

                foreach (var l in linkovi)
                {
                    Slika slika = new Slika()
                    {
                        Link = l
                    };

                    lista.Add(slika);
                }
                
                Context.Slike.AddRange(lista);
                await Context.SaveChangesAsync();
                
                return lista;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiSliku(Slika slika)
        {
            try
            {
                Context.Slike.Remove(slika);
                await Context.SaveChangesAsync();
                
                return true;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Slika> PreuzmiSlikuPoId(int slikaId)
        {
            try
            {
                return await Context.Slike.FindAsync(slikaId);                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Slika>> PreuzmiSlikePoId(List<int> slikeIds)
        {
            try
            {
                return await Context.Slike
                                    .Where(s => slikeIds.Contains(s.Id))
                                    .ToListAsync();                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiSlike(List<Slika> slike)
        {
            try
            {
                Context.Slike.RemoveRange(slike);
                await Context.SaveChangesAsync();
                
                return true;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Slika>> PreuzmiSlikePoImenu(List<string> slikeImena)
        {
            try
            {
                return await Context.Slike
                                    .Where(s => slikeImena.Contains(s.Link))
                                    .ToListAsync();                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Slika> PreuzmiSlikuPoImenu(string slikaIme)
        {
            try
            {
                return await Context.Slike
                                    .Where(s => slikaIme == s.Link)
                                    .FirstOrDefaultAsync();                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}