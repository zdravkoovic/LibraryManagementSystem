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
    public class KnjigaDao : IKnjigaDao
    {
        private Context Context { get; set; }

        public KnjigaDao(Context context)
        {
            Context = context;
        }
        public async Task<Knjiga> PreuzmiKnjiguPoId(int knjigaId)
        {
            try
            {
                return await Context.Knjige
                                    .Include(k => k.FizickeKnjige)
                                    .Include(k => k.Autor)
                                    .Include(k => k.KnjizevnaVrsta)
                                    .Include(k => k.KnjizevniRod)
                                    .Include(k => k.KnjizevniZanrovi)
                                    .Include(k => k.Slika)
                                    .Where(k => k.Id == knjigaId)
                                    .FirstOrDefaultAsync();
                
            }
            catch (Exception e)
            {
                throw e;             
            }
        }

        public async Task<KnjigeStrane> PreuzmiKnjige(List<int> zanroviIds, List<int> rodoviIds, List<int> vrsteIds, List<int> jeziciIds, bool slobodna, int page, string pretraga)
        {
            try
            {
                IQueryable<Knjiga> knjige = Context.Knjige
                                    .Include(k => k.FizickeKnjige)
                                                    .Include(k => k.Autor)
                                                    .Include(k => k.KnjizevnaVrsta)
                                                    .Include(k => k.KnjizevniRod)
                                                    .Include(k => k.KnjizevniZanrovi)
                                                    .Include(k => k.Slika);
                

                if (pretraga != null)
                {
                    knjige = knjige.Where(k => k.Naslov.Contains(pretraga)
                                || pretraga.Contains(k.Naslov) 
                                || k.Autor.Ime.Contains(pretraga)
                                || pretraga.Contains(k.Autor.Ime) 
                                || k.Autor.Prezime.Contains(pretraga)
                                || pretraga.Contains(k.Autor.Prezime));
                }

                if (zanroviIds != null)
                {
                    var knjizevniZanrovi = await Context.KnjizevniZanrovi.Where(kz => zanroviIds.Contains(kz.Id))
                                                                        .ToListAsync();

                    knjige = knjige.Where(k => k.KnjizevniZanrovi.Any(z => knjizevniZanrovi.Contains(z)));
                }

                if (rodoviIds != null)
                {
                    var knjizevniRodovi = await Context.KnjizevniRodovi.Where(kr => rodoviIds.Contains(kr.Id))
                                                                        .ToListAsync();

                    knjige = knjige.Where(k => knjizevniRodovi.Contains(k.KnjizevniRod));
                }

                if (vrsteIds != null)
                {
                    var knjizevneVrste = await Context.KnjizevneVrste
                                                        .Where(kv => vrsteIds.Contains(kv.Id))
                                                        .ToListAsync();

                    knjige = knjige.Where(k => knjizevneVrste.Contains(k.KnjizevnaVrsta));
                }

                if (jeziciIds != null)
                {
                    var fizickeKnjige = await Context.FizickeKnjige
                                                    .Include(fk => fk.Jezik)
                                                    .Where(fk => jeziciIds.Contains(fk.Jezik.Id))
                                                    .ToListAsync(); // vraca sve vizicke knjige napisane na datim jezicima

                    if (slobodna == true)
                    {
                        fizickeKnjige = fizickeKnjige.Where(fk => fk.Slobodna == true).ToList(); // selektuje slobodne fizicke knjige
                    } 

                    knjige = knjige.Where(k => k.FizickeKnjige.Any(fk => fizickeKnjige.Contains(fk)));

                }
                else if (slobodna == true)
                {
                    var slobodneKnjige = await Context.FizickeKnjige.Where(fk => fk.Slobodna == true).ToListAsync();

                    knjige = knjige.Where(k => k.FizickeKnjige.Any(fk => slobodneKnjige.Contains(fk)));
                }

                int brojStrana = (int)Math.Ceiling((decimal)knjige.Count() / 10);

                return new KnjigeStrane()
                {
                    Knjige = await knjige.OrderBy(k => k.Naslov)
                                    .Skip(page * 10)
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

        public async Task<KnjigeStrane> PretraziKnjige(string pretraga, int page)
        {
            try
            {
                var knjige = Context.Knjige
                                    .Include(k => k.FizickeKnjige)
                                    .Include(k => k.Autor)
                                    .Include(k => k.KnjizevnaVrsta)
                                    .Include(k => k.KnjizevniRod)
                                    .Include(k => k.KnjizevniZanrovi)
                                    .Include(k => k.Slika)
                                    .Where(k => k.Naslov.Contains(pretraga)
                                    || pretraga.Contains(k.Naslov) 
                                    || k.Autor.Ime.Contains(pretraga)
                                    || pretraga.Contains(k.Autor.Ime) 
                                    || k.Autor.Prezime.Contains(pretraga)
                                    || pretraga.Contains(k.Autor.Prezime));

                int brojStrana = (int)Math.Ceiling((decimal)knjige.Count() / 10);  

                return new KnjigeStrane()
                {
                    Knjige = await knjige.OrderBy(k => k.Naslov)
                                    .Skip(page * 10)
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

        public async Task<List<Knjiga>> PreuzmiSveKnjigeAutora(int autorId)
        {
            try
            {
                return await Context.Knjige
                                    .Include(k => k.FizickeKnjige)
                                    .Include(k => k.Autor)
                                    .Include(k => k.KnjizevnaVrsta)
                                    .Include(k => k.KnjizevniRod)
                                    .Include(k => k.KnjizevniZanrovi)
                                    .Include(k => k.Slika)
                                    .Where(k => k.Autor.Id == autorId)
                                    .ToListAsync(); 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Knjiga>> PreuzmiKnjigeKojeCekaKorisnik(int korisnikId)
        {
            try
            {
                var knjigeIds = await Context.Cekanja
                                    .Include(c => c.Knjiga)
                                    .Include(c => c.Korisnik)
                                    .Where(c => c.Korisnik.Id == korisnikId)
                                    .Select(c => c.Knjiga.Id)
                                    .ToListAsync();

                return await Context.Knjige
                                    .Include(k => k.FizickeKnjige)
                                    .Include(k => k.Autor)
                                    .Include(k => k.KnjizevnaVrsta)
                                    .Include(k => k.KnjizevniRod)
                                    .Include(k => k.KnjizevniZanrovi)
                                    .Include(k => k.Slika)
                                    .Where(k => knjigeIds.Contains(k.Id))
                                    .ToListAsync();

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Knjiga> DodajKnjigu(Knjiga knjiga)
        {
            try
            {
                Context.Knjige.Add(knjiga);
                await Context.SaveChangesAsync();
                return knjiga;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Knjiga> SacuvajIzmeneKnjige(Knjiga knjiga)
        {
            try
            {
                Context.Knjige.Update(knjiga);
                await Context.SaveChangesAsync();
                return knjiga;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiKnjigu(Knjiga knjiga)
        {
            try
            {
                Context.Knjige.Remove(knjiga);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> PreuzmiBrojKnjiga()
        {
            try
            {
                return await Context.Knjige
                                    .CountAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}