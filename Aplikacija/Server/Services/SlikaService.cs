using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Helper;
using Models;
using Services.Interfaces;

namespace Services
{
    public class SlikaService : ISlikaService
    {
        private ISlikaDao SlikaDao { get; set; }

        public SlikaService(ISlikaDao slikaDao)
        {
            SlikaDao = slikaDao;
        }

        public async Task<bool> ObrisiSlike(List<string> linkovi)
        {
            try
            {
                List<Slika> slike = await SlikaDao.PreuzmiSlikePoImenu(linkovi);

                await SlikaDao.ObrisiSlike(slike);
                SlikeHelper.ObrisiSlikeSaDiska(slike);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiSliku(string link)
        {
            try
            {
                Slika slika = await SlikaDao.PreuzmiSlikuPoImenu(link);
                
                if (slika == null)
                {
                    return false;
                }

                await SlikaDao.ObrisiSliku(slika);
                SlikeHelper.ObrisiSlikuSaDiska(slika);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}