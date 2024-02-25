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
    public class RadnikService : IRadnikService
    {
        private IRadnikDao RadnikDao { get; set; }
        private IRasporedDao RasporedDao { get; set; }

        public RadnikService(IRadnikDao radnikDao, IRasporedDao rasporedDao)
        {
            RadnikDao = radnikDao;
            RasporedDao = rasporedDao;
        }

        public async Task<RadnikPrikaz> DodajRadnika(RadnikParametri radnikParametri)
        {
            try
            {
                if (radnikParametri.JMBG == null || radnikParametri.JMBG.Length != 13)
                {
                    throw new Exception("JMBG radnika mora imati 13 cifara.");
                }

                if (radnikParametri.Ime == null)
                {
                    throw new Exception("Radnik mora imati ime.");
                }

                if (radnikParametri.Prezime == null)
                {
                    throw new Exception("Radnik mora imati prezime.");
                }

                if (radnikParametri.KorisnickoIme == null)
                {
                    throw new Exception("Radnik mora imati korisničko ime.");
                }

                if (radnikParametri.Lozinka == null)
                {
                    throw new Exception("Radnik mora imati lozinku.");
                }

                if (radnikParametri.Kontakt == null)
                {
                    throw new Exception("Radnik mora imati kontakt telefon.");
                }

                if (await RadnikDao.PostojiRadnikSaKorisnickimImenom(radnikParametri.KorisnickoIme))
                {
                    throw new Exception("Korisničko ime već postoji.");
                }

                Radnik radnik = new Radnik()
                {
                    JMBG = radnikParametri.JMBG,
                    Ime = radnikParametri.Ime,
                    Prezime = radnikParametri.Prezime,
                    KorisnickoIme = radnikParametri.KorisnickoIme,
                    Lozinka = BCrypt.Net.BCrypt.HashPassword(radnikParametri.Lozinka),
                    Kontakt = radnikParametri.Kontakt,
                    Menadzer = radnikParametri.Menadzer
                };

                radnik = await RadnikDao.DodajRadnika(radnik);

                Raspored raspored = new Raspored()
                {
                    Radnik = radnik
                };

                await RasporedDao.DodajRaspored(raspored);
                radnik = await RadnikDao.PreuzmiRadnikaPoId(radnik.Id);


                return RadnikMapper.RadnikToRadnikPrikaz(radnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<RadnikPrikaz> IzmeniRadnika(int radnikId, RadnikParametri radnikParametri)
        {
            try
            {
                Radnik radnik = await RadnikDao.PreuzmiRadnikaPoId(radnikId);

                if (radnikParametri.JMBG == null || radnikParametri.JMBG.Length != 13)
                {
                    throw new Exception("JMBG radnika mora imati 13 cifara.");
                }

                if (radnikParametri.Ime == null)
                {
                    throw new Exception("Radnik mora imati ime.");
                }

                if (radnikParametri.Prezime == null)
                {
                    throw new Exception("Radnik mora imati prezime.");
                }

                if (radnikParametri.KorisnickoIme == null)
                {
                    throw new Exception("Radnik mora imati korisničko ime.");
                }

                if (radnikParametri.Kontakt == null)
                {
                    throw new Exception("Radnik mora imati kontakt telefon.");
                }

                if (radnik.KorisnickoIme != radnikParametri.KorisnickoIme && await RadnikDao.PostojiRadnikSaKorisnickimImenom(radnikParametri.KorisnickoIme))
                {
                    throw new Exception("Korisničko ime već postoji.");
                }

                radnik.JMBG = radnikParametri.JMBG;
                radnik.Ime = radnikParametri.Ime;
                radnik.Prezime = radnikParametri.Prezime;
                radnik.KorisnickoIme = radnikParametri.KorisnickoIme;
                radnik.Kontakt = radnikParametri.Kontakt;
                radnik.Menadzer = radnikParametri.Menadzer;

                radnik = await RadnikDao.SacuvajIzmeneRadnika(radnik);
                radnik = await RadnikDao.PreuzmiRadnikaPoId(radnik.Id);
                return RadnikMapper.RadnikToRadnikPrikaz(radnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<RadnikPrikaz> PreuzmiRadnikaPoId(int radnikId)
        {
            try
            {
                Radnik radnik = await RadnikDao.PreuzmiRadnikaPoId(radnikId);

                return RadnikMapper.RadnikToRadnikPrikaz(radnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RadnikPrikaz>> PreuzmiRadnike()
        {
            try
            {
                List<Radnik> radnici = await RadnikDao.PreuzmiRadnike();

                return RadnikMapper.RadniciToRadniciPrikaz(radnici);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<RadnikPrikaz> IzmeniLozinkuRadnika(int radnikId, LozinkaParametri lozinkaParametri)
        {
            try
            {
                if (lozinkaParametri.NovaLozinka == null || lozinkaParametri.StaraLozinka == null)
                {
                    throw new Exception("Neispravan unos.");
                }

                Radnik radnik = await RadnikDao.PreuzmiRadnikaPoId(radnikId);

                if (!BCrypt.Net.BCrypt.Verify(lozinkaParametri.StaraLozinka, radnik.Lozinka))
                {
                    throw new Exception("Neispravna lozinka.");
                }

                radnik.Lozinka = BCrypt.Net.BCrypt.HashPassword(lozinkaParametri.NovaLozinka);

                radnik = await RadnikDao.SacuvajIzmeneRadnika(radnik);
                radnik = await RadnikDao.PreuzmiRadnikaPoId(radnik.Id);
                return RadnikMapper.RadnikToRadnikPrikaz(radnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RadnikPrikaz>> PretraziRadnike(string pretraga)
        {
            try
            {
                List<Radnik> radnici = await RadnikDao.PretraziRadnike(pretraga);

                return RadnikMapper.RadniciToRadniciPrikaz(radnici);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}