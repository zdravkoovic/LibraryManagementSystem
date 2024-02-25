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
    public class IzdavacService : IIzdavacService
    {
        private IIzdavacDao IzdavacDao { get; set; }
        private IFizickaKnjigaDao FizickaKnjigaDao { get; set; }

        public IzdavacService(IIzdavacDao izdavacDao, IFizickaKnjigaDao fizickaKnjigaDao)
        {
            IzdavacDao = izdavacDao;
            FizickaKnjigaDao = fizickaKnjigaDao;
        }

        public async Task<IzdavacPrikaz> DodajIzdavaca(IzdavacParametri izdavacParametri)
        {
            try
            {
                if(izdavacParametri.Naziv == null)
                {
                    throw new Exception("Izdavač mora imati naziv.");
                }

                Izdavac izdavac = new Izdavac()
                {
                    Naziv = izdavacParametri.Naziv
                };

                izdavac = await IzdavacDao.DodajIzdavaca(izdavac);
                izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(izdavac.Id);

                return IzdavacMapper.IzdavacToIzdavacPrikaz(izdavac);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IzdavacPrikaz> IzmeniIzdavaca(int izdavacId, IzdavacParametri izdavacParametri)
        {
            try
            {
                if(izdavacParametri.Naziv == null)
                {
                    throw new Exception("Izdavač mora imati naziv.");
                }

                Izdavac izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(izdavacId);

                izdavac.Naziv = izdavacParametri.Naziv;

                izdavac = await IzdavacDao.IzmeniIzdavaca(izdavac);
                izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(izdavac.Id);

                return IzdavacMapper.IzdavacToIzdavacPrikaz(izdavac);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiIzdavaca(int izdavacId)
        {
           int brojIzdatihKnjigeIzdavaca = await FizickaKnjigaDao.PreuzmiBrojFizickihKnjigaIzdavaca(izdavacId);
           if(brojIzdatihKnjigeIzdavaca > 0)
           {
               throw new Exception("Izdavača nije moguće obrisati. Postoje izdate knjige. Pokušajte da ga izmenite.");
           }
           Izdavac izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(izdavacId);

           return await IzdavacDao.ObrisiIzdavaca(izdavac);
        }

        public async Task<List<IzdavacPrikaz>> PreuzmiIzdavace(int page)
        {
            try
            {
                List<Izdavac> izdavaci = await IzdavacDao.PreuzmiIzdavace(page);

                return IzdavacMapper.IzdavaciToIzdavaciPrikaz(izdavaci);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<IzdavacPrikaz>> PretragaIzdavaca(string pretraga, int page)
        {
            try
            {
                List<Izdavac> izdavaci = await IzdavacDao.PretragaIzdavaca(pretraga, page);

                return IzdavacMapper.IzdavaciToIzdavaciPrikaz(izdavaci);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IzdavacPrikaz> PreuzmiIzdavacaPoId(int izdavacId)
        {
            try
            {
                Izdavac izdavac = await IzdavacDao.PreuzmiIzdavacaPoId(izdavacId);

                return IzdavacMapper.IzdavacToIzdavacPrikaz(izdavac);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}