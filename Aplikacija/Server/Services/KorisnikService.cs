using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Mappers;
using Models;
using Parameters;
using Services.Interfaces;

namespace Services
{
    public class KorisnikService : IKorisnikService
    {
        private IKorisnikDao KorisnikDao { get; set; }
        private IIznajmljivanjeDao IznajmljivanjeDao { get; set; }
        private ICitanjeDao CitanjeDao { get; set; }

        public KorisnikService(IKorisnikDao korisnikDao, IIznajmljivanjeDao iznajmljivanjeDao, ICitanjeDao citanjeDao)
        {
            KorisnikDao = korisnikDao;
            IznajmljivanjeDao = iznajmljivanjeDao;
            CitanjeDao = citanjeDao;
        }

        public async Task<List<KorisnikPrikaz>> PretraziKorisnike(string pretraga)
        {
            try
            {
                List<Korisnik> korisnici = await KorisnikDao.PretraziKorisnike(pretraga);

                return KorisnikMapper.KorisniciToKorisniciPrikaz(korisnici);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> PreuzmiKorisnikaPoId(int korisnikId)
        {
            try
            {
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnikId);

                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> DodajKorisnika(KorisnikParametri korisnikParametri)
        {
            try
            {
                if (await KorisnikDao.PostojiKorisnikSaKorisnickimImenom(korisnikParametri.KorisnickoIme))
                {
                    throw new Exception("Korisničko ime već postoji.");
                }
                BCrypt.Net.BCrypt.GenerateSalt(12);

                Korisnik korisnik = new Korisnik()
                {
                    Ime = korisnikParametri.Ime,
                    Prezime = korisnikParametri.Prezime,
                    KorisnickoIme = korisnikParametri.KorisnickoIme,
                    Lozinka = BCrypt.Net.BCrypt.HashPassword(korisnikParametri.Lozinka),
                    Kontakt = korisnikParametri.Kontakt,
                    Email = korisnikParametri.Email,
                    DatumPlacanjaClanarine = null,
                    DatumProverePlacanjaClanarine = null,
                    Kazna = 500
                };

                korisnik = await KorisnikDao.DodajKorisnika(korisnik);
                korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnik.Id);

                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> IzmeniKorisnika(int korisnikId, KorisnikParametri korisnikParametri)
        {
            try
            {
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnikId);

                if (korisnik.KorisnickoIme != korisnikParametri.KorisnickoIme && await KorisnikDao.PostojiKorisnikSaKorisnickimImenom(korisnikParametri.KorisnickoIme))
                {
                    throw new Exception("Korisničko ime već postoji.");
                }

                korisnik.KorisnickoIme = korisnikParametri.KorisnickoIme;
                korisnik.Kontakt = korisnikParametri.Kontakt;
                korisnik.Email = korisnikParametri.Email;

                korisnik = await KorisnikDao.SacuvajIzmeneKorisnika(korisnik);
                korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnik.Id);

                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiKorisnika(int korisnikId)
        {
            try
            {
                List<Iznajmljivanje> iznajmljivanja = await IznajmljivanjeDao.PreuzmiTrenutnaIznajmljivanjaKorisnika(korisnikId);
                Console.WriteLine(iznajmljivanja.Count);
                if (iznajmljivanja.Count > 0)
                {
                    throw new Exception("Nije moguće obrisati korisnika, ima iznajmljene knjige.");
                }

                List<Citanje> citanja = await CitanjeDao.PreuzmiTrenutnaCitanjaKorisnika(korisnikId);
                if (citanja.Count > 0)
                {
                    throw new Exception("Nije moguće obrisati korisnika, trenutno čita knjigu.");
                }

                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnikId);
                

                await KorisnikDao.ObrisiKorisnika(korisnik);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> IzmeniLozinkuKorisnika(int korisnikId, LozinkaParametri lozinkaParametri)
        {
            try
            {
                if (lozinkaParametri.NovaLozinka == null || lozinkaParametri.StaraLozinka == null)
                {
                    throw new Exception("Neispravan unos.");
                }

                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnikId);

                if (!BCrypt.Net.BCrypt.Verify(lozinkaParametri.StaraLozinka, korisnik.Lozinka))
                {
                    throw new Exception("Neispravna lozinka.");
                }

                korisnik.Lozinka = BCrypt.Net.BCrypt.HashPassword(lozinkaParametri.NovaLozinka);

                korisnik = await KorisnikDao.SacuvajIzmeneKorisnika(korisnik);

                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> PlatiClanarinuKorisnika(int korisnikId)
        {
            try
            {
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnikId);

                if (korisnik.DatumPlacanjaClanarine == null || korisnik.DatumProverePlacanjaClanarine == null)
                {
                    korisnik.Kazna -= 500;
                }


                korisnik.DatumPlacanjaClanarine = DateTime.Now.Date;
                korisnik.DatumProverePlacanjaClanarine = DateTime.Now.AddYears(1);
                

                korisnik = await KorisnikDao.SacuvajIzmeneKorisnika(korisnik);
                korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnik.Id);

                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> IzmiriDugovanjaKorisnika(int korisnikId)
        {
            try
            {
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnikId);
                korisnik.Kazna = 0;

                if (korisnik.DatumPlacanjaClanarine == null || korisnik.DatumProverePlacanjaClanarine == null)
                {
                    korisnik.Kazna += 500;
                }
                

                korisnik = await KorisnikDao.SacuvajIzmeneKorisnika(korisnik);
                korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(korisnik.Id);

                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}