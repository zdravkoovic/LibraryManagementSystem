using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Helper;
using Mappers;
using Models;
using Parameters;
using Services.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public class VestService : IVestService
    {
        private IVestDao VestDao { get; set; }
        private IRadnikDao RadnikDao { get; set; }
        private ISlikaDao SlikaDao { get; set; }

        public VestService(IVestDao vestDao, IRadnikDao radnikDao, ISlikaDao slikaDao)
        {
            VestDao = vestDao;
            RadnikDao = radnikDao;
            SlikaDao = slikaDao;
        }

        public async Task<VestPrikaz> DodajVest(VestParametri vestParametri)
        {
            try 
            {
                if(vestParametri.Naslov == null)
                {
                    throw new Exception("Vest mora imati naslov.");
                }
                if(vestParametri.Tekst == null)
                {
                    throw new Exception("Vest mora imati tekst.");
                }
                Radnik radnik = await RadnikDao.PreuzmiRadnikaPoId(vestParametri.RadnikId);
                if(radnik == null)
                {
                    throw new Exception("Radnik ne postoji.");
                }

                List<Slika> slike = null;
                List<string> linkovi = await SlikeHelper.GenerisiSlike(vestParametri.Slike);

                if (linkovi.Count() > 0)
                {
                    slike = await SlikaDao.DodajSlike(linkovi);
                }

                Vest vest = new Vest()
                {
                    Radnik = radnik,
                    Naslov = vestParametri.Naslov,
                    Tekst = vestParametri.Tekst,
                    Datum = DateTime.Now,
                    Slike = slike
                };

                vest = await VestDao.DodajVest(vest);
                vest = await VestDao.PreuzmiVestPoId(vest.Id);

                return VestMapper.VestToVestPrikaz(vest);

            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<VestPrikaz> IzmeniVest(int vestId, VestParametri vestParametri)
        {
            try 
            {
                if(vestParametri.Naslov == null)
                {
                    throw new Exception("Vest mora imati naslov.");
                }
                if(vestParametri.Tekst == null)
                {
                    throw new Exception("Vest mora imati tekst.");
                }
                Radnik radnik = await RadnikDao.PreuzmiRadnikaPoId(vestParametri.RadnikId);
                if(radnik == null)
                {
                    throw new Exception("Radnik ne postoji.");
                }

                Vest vest = await VestDao.PreuzmiVestPoId(vestId);

                vest.Radnik = radnik;
                vest.Naslov = vestParametri.Naslov;
                vest.Tekst = vestParametri.Tekst;
                vest.Datum = DateTime.Now;

                vest = await VestDao.SacuvajIzmeneVesti(vest);
                vest = await VestDao.PreuzmiVestPoId(vestId);
                return VestMapper.VestToVestPrikaz(vest);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> ObrisiVest(int vestId)
        {
            try 
            {
                Vest vest = await VestDao.PreuzmiVestPoId(vestId);
                if (vest.Slike != null || vest.Slike.Count > 0)
                {
                    await SlikaDao.ObrisiSlike(vest.Slike);
                    SlikeHelper.ObrisiSlikeSaDiska(vest.Slike);
                }
                return await VestDao.ObrisiVest(vest);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<VestSaStranama> PreuzmiVesti(int page)
        {
            try 
            {
                var result = await VestDao.PreuzmiVesti(page);

                return new VestSaStranama()
                {
                    Vesti = VestMapper.VestiToVestiPrikaz(result.Vesti),
                    BrojStrana = result.BrojStrana
                };
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<VestPrikaz> PreuzmiVestPoId(int vestId)
        {
            try 
            {
                Vest vest = await VestDao.PreuzmiVestPoId(vestId);

                return VestMapper.VestToVestPrikaz(vest);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<VestPrikaz> DodajSlikeVesti(int vestId, List<SlikaParametar> slikeForms)
        {
            try
            {
                var vest = await VestDao.PreuzmiVestPoId(vestId);
                
                List<Slika> slike = null;
                List<string> linkovi = await SlikeHelper.GenerisiSlike(slikeForms.Select(s => s.Slika).ToList());
                
                if (linkovi.Count() == 0) return VestMapper.VestToVestPrikaz(vest);

                slike = await SlikaDao.DodajSlike(linkovi);

                vest.Slike.AddRange(slike);
                vest = await VestDao.SacuvajIzmeneVesti(vest);
                vest = await VestDao.PreuzmiVestPoId(vest.Id);
                return VestMapper.VestToVestPrikaz(vest);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}