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
    public class AutorDao : IAutorDao
    {
        private Context Context { get; set; }

        public AutorDao(Context context)
        {
            Context = context;
        }
        public async Task<Autor> PreuzmiAutoraPoId(int autorId)
        {
            try
            {
                return await Context.Autori
                                    .Include(a => a.Slika)
                                    .Where(a => a.Id == autorId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutoriStrane> PreuzmiAutore(int page)
        {
            try
            {
                var autori = Context.Autori
                                    .Include(a => a.Slika)
                                    .OrderBy(a => a.Prezime);
                int brojAutora = Context.Autori.Count();
                int brojStrana = (int)Math.Ceiling((decimal)brojAutora / 10);
                
                return new AutoriStrane()
                {
                    Autori = await autori
                            .OrderBy(a => a.Prezime)
                            .Skip(10 * page)
                            .Take(10)
                            .ToListAsync(),
                    BrojStrana = brojStrana
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutoriStrane> PretraziAutore(string pretraga, int page)
        {
            try
            {
                var autori = Context.Autori
                                    .Include(a => a.Slika)
                                    .Where(a => a.Ime.Contains(pretraga)
                                    || pretraga.Contains(a.Ime)
                                    || a.Prezime.Contains(pretraga)
                                    || pretraga.Contains(a.Prezime));

                int brojAutora = autori.Count();
                int brojStrana = (int)Math.Ceiling((decimal)brojAutora / 10);
                
                return new AutoriStrane()
                {
                    Autori = await autori
                            .OrderBy(a => a.Prezime)
                            .Skip(10 * page)
                            .Take(10)
                            .ToListAsync(),
                    BrojStrana = brojStrana
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Autor> DodajAutora(Autor autor)
        {
            try
            {
                Context.Autori.Add(autor);
                await Context.SaveChangesAsync();
                return autor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Autor> SacuvajIzmeneAutora(Autor autor)
        {
            try
            {
                Context.Autori.Update(autor);
                await Context.SaveChangesAsync();
                return autor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiAutora(Autor autor)
        {
            try
            {
                Context.Autori.Remove(autor);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}