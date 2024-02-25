using System;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class StatistikaService : IStatistikaService
    {
        private IFizickaKnjigaDao FizickaKnjigaDao { get; set; }
        private IKnjigaDao KnjigaDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }
        private IRadnikDao RadnikDao { get; set; }

        public StatistikaService(IFizickaKnjigaDao fizicikaKnjigaDao, IKnjigaDao knjigaDao, IKorisnikDao korisnikDao, IRadnikDao radnikDao)
        {
            FizickaKnjigaDao = fizicikaKnjigaDao;
            KnjigaDao = knjigaDao;
            KorisnikDao = korisnikDao;
            RadnikDao = radnikDao;
        }

        public async Task<StatistikaPrikaz> PreuzmiStatistiku()
        {
            try
            {
                return new StatistikaPrikaz()
                {
                    BrojFizickihKnjiga = await FizickaKnjigaDao.PreuzmiBrojFizickihKnjiga(),
                    BrojLogickihKnjiga = await KnjigaDao.PreuzmiBrojKnjiga(),
                    BrojKorisnika = await KorisnikDao.PreuzmiBrojKorisnika(),
                    BrojRadnika = await RadnikDao.PreuzmiBrojRadnika()
                };
            }   
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}