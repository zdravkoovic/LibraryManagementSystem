using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Mappers;
using Models;
using Services.Interfaces;

namespace Services
{
    public class FilterService : IFilterService
    {
        private IFilterDao FilterDao { get; set; }

        public FilterService(IFilterDao filterDao)
        {
            FilterDao = filterDao;
        }
        public async Task<FilteriPrikaz> PreuzmiFiltere()
        {
            try
            {
                List<KnjizevniZanr> knjizevniZanrovi = await FilterDao.PreuzmiKnjizevneZanrove();
                List<KnjizevniRod> knjizevniRodovi = await FilterDao.PreuzmiKnjizevneRodove();
                List<KnjizevnaVrsta> knjizevneVrste = await FilterDao.PreuzmiKnjizevneVrste();
                List<Jezik> jezici = await FilterDao.PreuzmiJezike();

                return FilterMapper.NapraviFilteriPrikaz(knjizevniZanrovi, knjizevniRodovi, knjizevneVrste, jezici);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<JezikPrikaz>> PreuzmiJezike()
        {
            try
            {
                List<Jezik> jezici = await FilterDao.PreuzmiJezike();

                return FilterMapper.JeziciToJeziciPrikaz(jezici);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjizevniRodPrikaz>> PreuzmiKnjizevneRodove()
        {
            try
            {
                List<KnjizevniRod> knjizevniRodovi = await FilterDao.PreuzmiKnjizevneRodove();

                return FilterMapper.RodoviToRodoviPrikaz(knjizevniRodovi);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjizevnaVrstaPrikaz>> PreuzmiKnjizevneVrste()
        {
            try
            {
                List<KnjizevnaVrsta> knjizevneVrste = await FilterDao.PreuzmiKnjizevneVrste();
                
                return FilterMapper.VrsteToVrstePrikaz(knjizevneVrste);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjizevniZanrPrikaz>> PreuzmiKnjizevneZanrove()
        {
            try
            {
                List<KnjizevniZanr> knjizevniZanrovi = await FilterDao.PreuzmiKnjizevneZanrove();

                return FilterMapper.ZanroviToZanroviPrikaz(knjizevniZanrovi);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}