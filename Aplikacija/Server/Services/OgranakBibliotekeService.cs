using System;
using System.Collections.Generic;
using System.IO;
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
    public class OgranakBibliotekeService : IOgranakBibliotekeService
    {
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }

        private ISlikaDao SlikaDao { get; set; }

        public OgranakBibliotekeService(IOgranakBibliotekeDao ogranakBibliotekeDao, ISlikaDao slikaDao)
        {
            OgranakBibliotekeDao = ogranakBibliotekeDao;
            SlikaDao = slikaDao;
        }

        public async Task<OgranakBibliotekePrikaz> DodajOgranakBiblioteke(OgranakBibliotekeParametri ogranakBibliotekeParametri)
        {
            try
            {

                List<Slika> slike = null;
                List<string> linkovi = await SlikeHelper.GenerisiSlike(ogranakBibliotekeParametri.Slike);
                
                if (linkovi.Count() > 0)
                {
                    Console.WriteLine("Ima te ovde");
                    slike = await SlikaDao.DodajSlike(linkovi);
                }

                OgranakBiblioteke ob = new OgranakBiblioteke()
                {
                    Naziv = ogranakBibliotekeParametri.Naziv,
                    Adresa = ogranakBibliotekeParametri.Adresa,
                    Kontakt = ogranakBibliotekeParametri.Kontakt,
                    Slike = slike
                };

                ob = await OgranakBibliotekeDao.DodajOgranakBiblioteke(ob);
                ob = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ob.Id);
                return OgranakBibliotekMapper.OgranakBibliotekeToOgranakBibliotekePrikaz(ob);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<OgranakBibliotekePrikaz> IzmeniOgranakBiblioteke(int ogranakBibliotekeId, OgranakBibliotekeParametri ogranakBibliotekeParametri)
        {
            try
            {
                OgranakBiblioteke ob = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ogranakBibliotekeId);
                if (ob == null)
                {
                    throw new Exception("Ogranak biblioteke ne postoji.");
                }
                
                ob.Naziv = ogranakBibliotekeParametri.Naziv;
                ob.Adresa = ogranakBibliotekeParametri.Adresa;
                ob.Kontakt = ogranakBibliotekeParametri.Kontakt;

                ob = await OgranakBibliotekeDao.SacuvajIzmeneOgrankaBiblioteke(ob);
                ob = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ob.Id);
                return OgranakBibliotekMapper.OgranakBibliotekeToOgranakBibliotekePrikaz(ob);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiOgranakBiblioteke(int ogranakBibliotekeId)
        {
            try
            {
                OgranakBiblioteke ob = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ogranakBibliotekeId);
                if (ob == null)
                {
                    throw new Exception("Ogranak biblioteke ne postoji.");
                }

                await OgranakBibliotekeDao.ObrisiOgranakBiblioteke(ob);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<OgranakBibliotekePrikaz> PreuzmiOgranakBibliotekePoId(int ogranakBibliotekeId)
        {
            try
            {
                OgranakBiblioteke ob = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ogranakBibliotekeId);

                return OgranakBibliotekMapper.OgranakBibliotekeToOgranakBibliotekePrikaz(ob);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<OgranakBibliotekePrikaz>> PreuzmiOgrankeBiblioteke()
        {
            try
            {
                List<OgranakBiblioteke> ob = await OgranakBibliotekeDao.PreuzmiOgrankeBiblioteke();

                return OgranakBibliotekMapper.OgranciBibliotekeToOgranciBibliotekePrikaz(ob);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<OgranakBibliotekePrikaz>> PreuzmiOgrankeGdeSeNalaziKnjiga(int knjigaId)
        {
            try
            {
                List<OgranakBiblioteke> ob = await OgranakBibliotekeDao.PreuzmiOgrankeGdeSeNalaziKnjiga(knjigaId);

                return OgranakBibliotekMapper.OgranciBibliotekeToOgranciBibliotekePrikaz(ob);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<OgranakBibliotekePrikaz> DodajSlikeOgrankuBiblioteke(int ogranakBibliotekeId, List<SlikaParametar> slikeForms)
        {
            try
            {
                var ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ogranakBibliotekeId);
                
                List<Slika> slike = null;
                List<string> linkovi = await SlikeHelper.GenerisiSlike(slikeForms.Select(s => s.Slika).ToList());
                
                if (linkovi.Count() == 0) return OgranakBibliotekMapper.OgranakBibliotekeToOgranakBibliotekePrikaz(ogranakBiblioteke);

                slike = await SlikaDao.DodajSlike(linkovi);

                ogranakBiblioteke.Slike.AddRange(slike);
                ogranakBiblioteke = await OgranakBibliotekeDao.SacuvajIzmeneOgrankaBiblioteke(ogranakBiblioteke);
                ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(ogranakBiblioteke.Id);
                return OgranakBibliotekMapper.OgranakBibliotekeToOgranakBibliotekePrikaz(ogranakBiblioteke);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}