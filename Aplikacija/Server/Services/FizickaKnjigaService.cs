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
    public class FizickaKnjigaService : IFizickaKnjigaService
    {
        private IKnjigaDao KnjigaDao { get; set; }
        private IFizickaKnjigaDao FizickaKnjigaDao { get; set; }
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }
        private IFilterDao FilterDao { get; set; }
        private IIzdavacDao IzdavacDao { get; set; }

        public FizickaKnjigaService(IKnjigaDao knjigaDao, IFizickaKnjigaDao fizickaKnjigaDao, IOgranakBibliotekeDao ogranakBibliotekeDao, IFilterDao filterDao, IIzdavacDao izdavacDao)
        {
            KnjigaDao = knjigaDao;
            FizickaKnjigaDao = fizickaKnjigaDao;
            OgranakBibliotekeDao = ogranakBibliotekeDao;
            FilterDao = filterDao;
            IzdavacDao = izdavacDao;
        }

        public async Task<List<FizickaKnjigaPrikaz>> DodajFizickeKnjige(FizickaKnjigaParametri fizickaKnjigaParametri)
        {
            try
            {
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(fizickaKnjigaParametri.KnjigaId);
                OgranakBiblioteke ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(fizickaKnjigaParametri.OgranakBibliotekeId);
                
                if (knjiga == null)
                {
                    throw new Exception("Knjiga ne postoji.");
                }

                if (ogranakBiblioteke == null)
                {
                    throw new Exception("Ogranak biblioteke ne postoji.");
                }
                
                Jezik jezik = await FilterDao.PreuzmiJezikPoId(fizickaKnjigaParametri.JezikId);
                Izdavac izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(fizickaKnjigaParametri.IzdavacId);

                List<FizickaKnjiga> fizickeKnjige = new List<FizickaKnjiga>();
                List<int> fizickeKnjigeIds = new List<int>();

                int brojFizickihKnjiga = await FizickaKnjigaDao.PreuzmiBrojFizickihKnjiga(knjiga.Id);
                for (int i = 1; i <= fizickaKnjigaParametri.BrojFizickihKnjiga; i++) {
                    string sifra = (brojFizickihKnjiga + i) + "-" + knjiga.Id + "-" + DateTime.Now.DayOfYear + "-" + DateTime.Now.Year;
                    FizickaKnjiga fizickaKnjiga = new FizickaKnjiga()
                    {
                        Sifra = sifra,
                        Knjiga = knjiga,
                        Jezik = jezik,
                        OgranakBiblioteke = ogranakBiblioteke,
                        Izdavac = izdavac,
                        Slobodna = true
                    };
                    fizickeKnjigeIds.Add((await FizickaKnjigaDao.DodajFizickuKnjigu(fizickaKnjiga)).Id);
                }

                foreach (var id in fizickeKnjigeIds)
                {
                    fizickeKnjige.Add(await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(id));
                }

                return FizickaKnjigaMapper.FizickeKnjigeToFizickeKnjigePrikaz(fizickeKnjige);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FizickaKnjigaPrikaz> IzmeniFizickuKnjigu(int fizickaKnjigaId, FizickaKnjigaParametri fizickaKnjigaParametri)
        {
            try
            {
                FizickaKnjiga fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(fizickaKnjigaId);
                
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(fizickaKnjigaParametri.KnjigaId);
                OgranakBiblioteke ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(fizickaKnjigaParametri.OgranakBibliotekeId);
                
                if (knjiga == null)
                {
                    throw new Exception("Knjiga ne postoji.");
                }

                if (ogranakBiblioteke == null)
                {
                    throw new Exception("Ogranak biblioteke ne postoji.");
                }

                Jezik jezik = await FilterDao.PreuzmiJezikPoId(fizickaKnjigaParametri.JezikId);
                Izdavac izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(fizickaKnjigaParametri.IzdavacId);

                fizickaKnjiga.Knjiga = knjiga;
                fizickaKnjiga.Jezik = jezik;
                fizickaKnjiga.OgranakBiblioteke = ogranakBiblioteke;
                fizickaKnjiga.Izdavac = izdavac;

                fizickaKnjiga = await FizickaKnjigaDao.SacuvajIzmeneFizickeKnjige(fizickaKnjiga);
                fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(fizickaKnjiga.Id);
                return FizickaKnjigaMapper.FizickaKnjigaToFizickaKnjigaPrikaz(fizickaKnjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiFizickuKnjigu(int fizickaKnjigaId)
        {
            try
            {
                FizickaKnjiga fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(fizickaKnjigaId);
                
                if (fizickaKnjiga.Slobodna == false)
                {
                    throw new Exception("Nije moguce obrisati knjigu. Trenutno je zauzeta.");
                }

                return await FizickaKnjigaDao.ObrisiFizickuKnjigu(fizickaKnjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<FizickaKnjigaPrikaz>> PreuzmiFizickeKnjige(int knjigaId, int ogranakBibliotekeId)
        {
            try
            {
                List<FizickaKnjiga> fizickeKnjige = await FizickaKnjigaDao.PreuzmiFizickeKnjigeUOgranku(knjigaId, ogranakBibliotekeId); 
                return FizickaKnjigaMapper.FizickeKnjigeToFizickeKnjigePrikaz(fizickeKnjige);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FizickaKnjigaPrikaz> PreuzmiFizickuKnjiguPoId(int fizickaKnjigaId)
        {
            try
            {
                FizickaKnjiga fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(fizickaKnjigaId);
                return FizickaKnjigaMapper.FizickaKnjigaToFizickaKnjigaPrikaz(fizickaKnjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FizickaKnjigaPrikaz> PreuzmiFizickuKnjiguPoSifri(string fizickaKnjigaSifra)
        {
            try
            {
                FizickaKnjiga fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoSifri(fizickaKnjigaSifra);
                if (fizickaKnjiga == null)
                {
                    throw new Exception("Greška.");
                }

                return FizickaKnjigaMapper.FizickaKnjigaToFizickaKnjigaPrikaz(fizickaKnjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}