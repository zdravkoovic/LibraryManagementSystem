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
    public class CitanjeService : ICitanjeService
    {
        private IFizickaKnjigaDao FizickaKnjigaDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }
        private IRadnikDao RadnikDao { get; set; }
        private IMestoDao MestoDao { get; set; }
        private ICitanjeDao CitanjeDao { get; set; }
        private ICitaonicaDao CitaonicaDao { get; set; }
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }

        public CitanjeService(IFizickaKnjigaDao fkDao, IKorisnikDao kDao, IRadnikDao rDao, IMestoDao mDao, 
                                ICitanjeDao cDao, ICitaonicaDao citaonicaDao, IOgranakBibliotekeDao ogranakBibliotekeDao)
        {
            FizickaKnjigaDao = fkDao;
            KorisnikDao = kDao;
            RadnikDao = rDao;
            MestoDao = mDao;
            CitanjeDao = cDao;
            CitaonicaDao = citaonicaDao;
            OgranakBibliotekeDao = ogranakBibliotekeDao;
        }

        public async Task<CitanjePrikaz> DodajCitanje(CitanjeParametri citanjeParametri)
        {
            try
            {
                FizickaKnjiga fk = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoSifri(citanjeParametri.FizickaKnjigaSifra);
                if (fk == null)
                {
                    throw new Exception("Fizička knjiga ne postoji.");
                }
                if (fk.Slobodna == false)
                {
                    throw new Exception("Knjiga je zauzeta.");
                }

                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(citanjeParametri.KorisnikId);
                if (korisnik.Kazna > 0)
                {
                    throw new Exception("Korisnik ima neisplaćene dugove.");
                }

                Radnik radnikDodelio = await RadnikDao.PreuzmiRadnikaPoId(citanjeParametri.RadnikDodelioId);

                if (radnikDodelio == null)
                {
                    throw new Exception("Radnik ne postoji.");
                }

                Mesto mesto = await MestoDao.PreuzmiMestoPoId(citanjeParametri.MestoId);

                if (mesto == null)
                {
                    throw new Exception("Mesto ne postoji.");
                }

                if (mesto.Zauzeto == true)
                {
                    throw new Exception("Mesto je zauzeto.");
                }

                OgranakBiblioteke ogranak = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(fk.OgranakBiblioteke.Id);
                Citaonica citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(mesto.Citaonica.Id);

                if (citaonica.OgranakBiblioteke != ogranak)
                {
                    throw new Exception("Knjiga se ne nalazi u ovom ogranku.");
                }

                Citanje citanje = new Citanje()
                {
                    VremeUzimanjaKnjige = DateTime.Now,
                    VremeVracanjaKnjige = null,
                    FizickaKnjiga = fk,
                    Korisnik = korisnik,
                    RadnikDodelio = radnikDodelio,
                    Mesto = mesto
                };

                mesto.Zauzeto = true;
                await MestoDao.SacuvajIzmeneMesta(mesto);

                fk.Slobodna = false;
                await FizickaKnjigaDao.SacuvajIzmeneFizickeKnjige(fk);

                citanje = await CitanjeDao.DodajCitanje(citanje);
                citanje = await CitanjeDao.PreuzmiCitanjePoId(citanje.Id);
                return CitanjeMapper.CitanjeToCitanjePrikaz(citanje);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CitanjePrikaz>> PreuzmiCitanjaKorisnika(int korisnikId)
        {
            try
            {
                var citanja = await CitanjeDao.PreuzmiCitanjaKorisnika(korisnikId);

                return CitanjeMapper.CitanjaToCitanjaPrikaz(citanja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CitanjePrikaz>> PreuzmiCitanjaNaMestu(int mestoId)
        {
            try
            {
                var citanja = await CitanjeDao.PreuzmiCitanjaNaMestu(mestoId);

                return CitanjeMapper.CitanjaToCitanjaPrikaz(citanja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CitanjePrikaz>> PreuzmiTrenutnaCitanjaUCitaonici(int citaonicaId)
        {
            try
            {
                var citanja = await CitanjeDao.PreuzmiTrenutnaCitanjaUCitaonici(citaonicaId);

                return CitanjeMapper.CitanjaToCitanjaPrikaz(citanja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CitanjePrikaz> VratiKnjigu(int citanjeId)
        {
            try
            {
                Citanje citanje = await CitanjeDao.PreuzmiCitanjePoId(citanjeId);
                citanje.VremeVracanjaKnjige = DateTime.Now;
                citanje = await CitanjeDao.SacuvajIzmeneCitanja(citanje);
                citanje = await CitanjeDao.PreuzmiCitanjePoId(citanje.Id);

                var fk = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(citanje.FizickaKnjiga.Id);
                fk.Slobodna = true;
                await FizickaKnjigaDao.SacuvajIzmeneFizickeKnjige(fk);

                var mesto = await MestoDao.PreuzmiMestoPoId(citanje.Mesto.Id);
                mesto.Zauzeto = false;
                await MestoDao.SacuvajIzmeneMesta(mesto);

                citanje = await CitanjeDao.PreuzmiCitanjePoId(citanjeId);
                
                return CitanjeMapper.CitanjeToCitanjePrikaz(citanje);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CitanjePrikaz> PreuzmiCitanjePoId(int citanjeId)
        {
            try
            {
                var citanje = await CitanjeDao.PreuzmiCitanjePoId(citanjeId);

                return CitanjeMapper.CitanjeToCitanjePrikaz(citanje);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}