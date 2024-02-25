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
    public class RasporedService : IRasporedService
    {
        private IRasporedDao RasporedDao { get; set; }
        private IRadnikDao RadnikDao { get; set; }
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }

        public RasporedService(IRasporedDao rasporedDao, IRadnikDao radnikDao, IOgranakBibliotekeDao ogranakBibliotekeDao)
        {
            RasporedDao = rasporedDao;
            RadnikDao = radnikDao;
            OgranakBibliotekeDao = ogranakBibliotekeDao;
        }

        public async Task<RasporedPrikaz> IzmeniRaspored(int rasporedId, RasporedParametri rasporedParametri)
        {
            try
            {
                Raspored raspored = await RasporedDao.PreuzmiRasporedPoId(rasporedId);
                Radnik menadzer = await RadnikDao.PreuzmiMenadzeraPoId(rasporedParametri.MenadzerId);

                if (menadzer == null)
                {
                    throw new Exception("Morate biti menadžer biblioteke da biste promenili raspored radnika.");
                }

                OgranakBiblioteke ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(rasporedParametri.OgranakBibliotekeId);
                if (ogranakBiblioteke == null)
                {
                    throw new Exception("Ogranak biblioteke ne postoji.");
                }

                if (rasporedParametri.DatumOd?.Date == null || rasporedParametri.DatumDo?.Date == null || rasporedParametri.DatumOd?.Date > rasporedParametri.DatumDo?.Date)
                {
                    throw new Exception("Morate uneti validne datume.");
                }

                raspored.Menadzer = menadzer;
                raspored.OgranakBiblioteke = ogranakBiblioteke;
                raspored.DatumOd = rasporedParametri.DatumOd?.Date;
                raspored.DatumDo = rasporedParametri.DatumDo?.Date;

                raspored = await RasporedDao.SacuvajIzmeneRasporeda(raspored);
                raspored = await RasporedDao.PreuzmiRasporedPoId(raspored.Id);
                return RasporedMapper.RasporedToRasporedPrikaz(raspored);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // public async Task<RasporedPrikaz> PreuzmiRasporedPoId(int rasporedId)
        // {
        //     try
        //     {
        //         Raspored raspored = await RasporedDao.PreuzmiRasporedPoId(rasporedId);

        //         return RasporedMapper.RasporedToRasporedPrikaz(raspored);
        //     }
        //     catch (Exception e)
        //     {
        //         throw e;
        //     }
        // }

        public async Task<RasporedPrikaz> PreuzmiRasporedRadnika(int radnikId)
        {
            try
            {   
                Raspored raspored = await RasporedDao.PreuzmiRasporedRadnika(radnikId);

                return RasporedMapper.RasporedToRasporedPrikaz(raspored);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RasporedPrikaz>> PreuzmiRasporede()
        {
            try
            {   
                List<Raspored> rasporedi = await RasporedDao.PreuzmiRasporede();

                return RasporedMapper.RasporediToRasporediPrikaz(rasporedi);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}