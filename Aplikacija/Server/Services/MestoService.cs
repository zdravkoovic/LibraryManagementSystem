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
    public class MestoService : IMestoService
    {
        private IMestoDao MestoDao { get; set; }
        private ICitaonicaDao CitaonicaDao { get; set; }

        public MestoService(IMestoDao mestoDao, ICitaonicaDao citaonicaDao)
        {
            MestoDao = mestoDao;
            CitaonicaDao = citaonicaDao;
        }

        public async Task<MestoPrikaz> DodajMesto(MestoParametri mestoParametri)
        {
            try
            {
                if (mestoParametri.X < 0 || mestoParametri.Y < 0)
                {
                    throw new Exception("Broj kolona i broj vrsta nije validan.");
                }

                Citaonica citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(mestoParametri.CitaonicaId);
                if (citaonica == null)
                {
                    throw new Exception("Čitaonica ne postoji.");
                }

                Mesto postojiMesto = await MestoDao.PreuzmiMestoUCitaoniciNaLokaciji(mestoParametri.CitaonicaId, mestoParametri.X, mestoParametri.Y);
                if (postojiMesto != null)
                {
                    throw new Exception("Na toj lokaciji već postoji mesto.");
                }

                Mesto mesto = new Mesto()
                {
                    X = mestoParametri.X,
                    Y = mestoParametri.Y,
                    Citaonica = citaonica,
                    Racunar = mestoParametri.Racunar,
                    Zauzeto = false
                };

                mesto = await MestoDao.DodajMesto(mesto);
                mesto = await MestoDao.PreuzmiMestoPoId(mesto.Id);
                return MestoMapper.MestoToMestoPrikaz(mesto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MestoPrikaz> IzmeniMesto(int mestoId, MestoParametri mestoParametri)
        {
            try
            {
                if (mestoParametri.X < 0 || mestoParametri.Y < 0)
                {
                    throw new Exception("Broj kolona i broj vrsta nije validan.");
                }

                Mesto mesto = await MestoDao.PreuzmiMestoPoId(mestoId);
                if (mesto == null)
                {
                    throw new Exception("Mesto ne postoji");
                }

                Mesto postojiMesto = await MestoDao.PreuzmiMestoUCitaoniciNaLokaciji(mestoParametri.CitaonicaId, mestoParametri.X, mestoParametri.Y);
                if (postojiMesto != null)
                {
                    if (mesto.Id != postojiMesto.Id)
                    {
                        throw new Exception("Na lokaciji već postoji mesto.");
                    }
                }

                mesto.X = mestoParametri.X;
                mesto.Y = mestoParametri.Y;
                mesto.Racunar = mestoParametri.Racunar;

                mesto = await MestoDao.SacuvajIzmeneMesta(mesto);
                mesto = await MestoDao.PreuzmiMestoPoId(mesto.Id);
                return MestoMapper.MestoToMestoPrikaz(mesto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiMesto(int mestoId)
        {
            try
            {
                Mesto mesto = await MestoDao.PreuzmiMestoPoId(mestoId);

                if (mesto.Zauzeto == true)
                {
                    throw new Exception("Mesto je trenutno zauzeto, pokušajte kasnije.");
                }

                await MestoDao.ObrisiMesto(mesto);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MestoPrikaz> PreuzmiMestoPoId(int mestoId)
        {
            try
            {
                Mesto mesto = await MestoDao.PreuzmiMestoPoId(mestoId);

                return MestoMapper.MestoToMestoPrikaz(mesto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<MestoPrikaz>> PreuzmiMestaCitaonice(int citaonicaId)
        {
            try
            {
                List<Mesto> mesta = await MestoDao.PreuzmiMestaCitaonice(citaonicaId);

                return MestoMapper.MestaToMestaPrikaz(mesta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}