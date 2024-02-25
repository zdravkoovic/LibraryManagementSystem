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
    public class PrijavaService : IPrijavaService
    {
        private IPrijavaDao PrijavaDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }
        private IRasporedDao RasporedDao { get; set; }
        private IRadnikDao  RadnikDao { get; set; }
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }

        public PrijavaService(IPrijavaDao prijavaDao, IKorisnikDao korisnikDao, IRasporedDao rasporedDao, IRadnikDao radnikDao, IOgranakBibliotekeDao ogranakBibliotekeDao)
        {
            PrijavaDao = prijavaDao;
            KorisnikDao = korisnikDao;
            RasporedDao = rasporedDao;
            RadnikDao = radnikDao;
            OgranakBibliotekeDao = ogranakBibliotekeDao;
        }

        public async Task<List<PrijavaPrikaz>> PreuzmiPrijaveRadnika(int radnikId)
        {
            try
            {
                List<Prijava> prijave = await PrijavaDao.PreuzmiPrijaveRadnika(radnikId);

                return PrijavaMapper.PrijaveToPrijavePrikaz(prijave);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KorisnikPrikaz> PrijavaKorisnika(PrijavaParametri prijavaParametri)
        {
            try
            {
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPriPrijavi(prijavaParametri.KorisnickoIme, prijavaParametri.Lozinka);
                
                if (korisnik == null)
                {
                    throw new Exception("Pogrešno korisničko ime ili lozinka.");
                }
                
                return KorisnikMapper.KorisnikToKorisnikPrikaz(korisnik);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PrijavaPrikaz> PrijavaRadnika(PrijavaParametri prijavaParametri)
        {
            try
            {
                Radnik radnik = await RadnikDao.PreuzmiRadnikaPriPrijavi(prijavaParametri.KorisnickoIme, prijavaParametri.Lozinka);
                
                if (radnik == null)
                {
                    throw new Exception("Pogrešno korisničko ime ili lozinka.");
                }

                OgranakBiblioteke ogranak = null;

                if (radnik.Menadzer == false)
                {
                    Raspored rasporedRadnika = await RasporedDao.PreuzmiRasporedRadnika(radnik.Id);
                    if (rasporedRadnika.OgranakBiblioteke == null)
                    {
                        throw new Exception("Radnik nije raspoređen ni u jednom ogranku.");
                    }

                    ogranak = rasporedRadnika.OgranakBiblioteke;

                    if (!(DateTime.Now >= rasporedRadnika.DatumOd && DateTime.Now <= rasporedRadnika.DatumDo))
                    {
                        throw new Exception("Radnik nije raspoređen da radi u ovom ogranku u ovom trenutku.");
                    }
                }

                Prijava trenutnaPrijava = await PrijavaDao.PreuzmiTrenutnuPrijavuRadnika(radnik.Id);
                
                if (trenutnaPrijava != null)
                {
                    trenutnaPrijava.VremeOdjave = DateTime.Now;
                    await PrijavaDao.SacuvajIzmenePrijave(trenutnaPrijava);
                }

                Prijava prijava = new Prijava()
                {
                    Radnik = radnik,
                    OgranakBiblioteke = ogranak,
                    VremePrijave = DateTime.Now
                };

                prijava = await PrijavaDao.DodajPrijavu(prijava);
                prijava = await PrijavaDao.PreuzmiPrijavuPoId(prijava.Id);
                return PrijavaMapper.PrijavaToPrijavaPrikaz(prijava);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> OdjavaRadnika(int prijavaId)
        {
            try
            {
                Prijava prijava = await PrijavaDao.PreuzmiPrijavuPoId(prijavaId);
                prijava.VremeOdjave = DateTime.Now;
                prijava = await PrijavaDao.SacuvajIzmenePrijave(prijava);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}