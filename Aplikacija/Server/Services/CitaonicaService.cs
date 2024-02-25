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
    public class CitaonicaService : ICitaonicaService
    {
        private ICitaonicaDao CitaonicaDao { get; set; }
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }
        private IMestoDao MestoDao { get; set; }

        public CitaonicaService(ICitaonicaDao citaonicaDao, IOgranakBibliotekeDao ogranakBibliotekeDao, IMestoDao mestoDao)
        {
            CitaonicaDao = citaonicaDao;
            OgranakBibliotekeDao = ogranakBibliotekeDao;
            MestoDao = mestoDao;
        }

        public async Task<CitaonicaPrikaz> DodajCitaonicu(CitaonicaParametri citaonicaParametri)
        {
            try
            {
                if (citaonicaParametri.BrojVrsta < 0 || citaonicaParametri.BrojKolona < 0)
                {
                    throw new Exception("Morate uneti broj vrsta i broj kolona.");
                }

                OgranakBiblioteke ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(citaonicaParametri.OgranakBibliotekeId);
                if (ogranakBiblioteke == null)
                {
                    throw new Exception("Ogranak biblioteke ne postoji.");
                }

                Citaonica citaonica = new Citaonica()
                {
                    Naziv = citaonicaParametri.Naziv,
                    BrojVrsta = citaonicaParametri.BrojVrsta,
                    BrojKolona = citaonicaParametri.BrojKolona,
                    OgranakBiblioteke = ogranakBiblioteke
                };

                citaonica = await CitaonicaDao.DodajCitaonicu(citaonica);
                citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(citaonica.Id);
                return CitaonicaMapper.CitaonicaToCitaonicaPrikaz(citaonica);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CitaonicaPrikaz> IzmeniCitaonicu(int citaonicaId, CitaonicaParametri citaonicaParametri)
        {
            try
            {
                if (citaonicaParametri.BrojVrsta < 0 || citaonicaParametri.BrojKolona < 0)
                {
                    throw new Exception("Morate uneti broj vrsta i broj kolona.");
                }

                Citaonica citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(citaonicaId);

                citaonica.BrojVrsta = citaonicaParametri.BrojVrsta;
                citaonicaParametri.BrojKolona = citaonicaParametri.BrojKolona;

                List<Mesto> zauzetaMesta = await MestoDao.PreuzmiZauzetaMestaCitaonice(citaonicaId);

                foreach (var m in zauzetaMesta)
                {
                    if (m.X >= citaonicaParametri.BrojVrsta || m.Y >= citaonicaParametri.BrojKolona)
                    {
                        throw new Exception("Nemoguće izmeniti mesta na željeni način. Proverite koja mesta su zauzeta.");
                    }
                }


                citaonica = await CitaonicaDao.SacuvajIzmeneCitaonice(citaonica);
                citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(citaonica.Id);
                return CitaonicaMapper.CitaonicaToCitaonicaPrikaz(citaonica);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiCitaonicu(int citaonicaId)
        {
            try
            {
                Citaonica citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(citaonicaId);
                List<Mesto> zauzetaMesta = await MestoDao.PreuzmiZauzetaMestaCitaonice(citaonicaId);

                if (zauzetaMesta.Count > 0)
                {
                    throw new Exception("Čitaonica je u funkciji trenutno. Obrišite je kasnije.");
                }
                await CitaonicaDao.ObrisiCitaonicu(citaonica);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CitaonicaPrikaz> PreuzmiCitaonicuPoId(int citaonicaId)
        {
            try
            {
                Citaonica citaonica = await CitaonicaDao.PreuzmiCitaonicuPoId(citaonicaId);

                return CitaonicaMapper.CitaonicaToCitaonicaPrikaz(citaonica);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CitaonicaPrikaz>> PreuzmiCitaoniceOgrankaBiblioteke(int ogranakBibliotekeId)
        {
            try
            {
                List<Citaonica> citaonice = await CitaonicaDao.PreuzmiCitaoniceOgrankaBiblioteke(ogranakBibliotekeId);

                return CitaonicaMapper.CitaoniceToCitaonicePrikaz(citaonice);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}