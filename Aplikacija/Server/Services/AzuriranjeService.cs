using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Models;
using Services.Interfaces;
using Helper;

namespace Services
{
    public class AzuriranjeService : IAzuriranjeService
    {
        private IIznajmljivanjeDao IznajmljivanjeDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }

        public AzuriranjeService(IIznajmljivanjeDao iznajmljivanjeDao, IKorisnikDao korisnikDao)
        {
            IznajmljivanjeDao = iznajmljivanjeDao;
            KorisnikDao = korisnikDao;
        }

        public async Task<bool> AzurirajStanje()
        {
            try
            {
                await ObavestiKorisnikeDaVrateKnjigu();
                await AzurirajIznajmljivanja();
                await AzurirajClanarine();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<bool> AzurirajIznajmljivanja()
        {
            try
            {
                List<Iznajmljivanje> iznajmljivanja = await IznajmljivanjeDao.PreuzmiDanasnjeProvere();

                foreach (var i in iznajmljivanja)
                {
                    i.Kazna += 500;
                    i.DatumProvere = DateTime.Now.AddDays(14);
                    i.Korisnik.Kazna += 500;
                    await KorisnikDao.SacuvajIzmeneKorisnika(i.Korisnik);
                    await IznajmljivanjeDao.SacuvajIzmeneIznajmljivanja(i);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<bool> AzurirajClanarine()
        {
            try
            {
                List<Korisnik> korisnici = await KorisnikDao.PreuzmiKorisnikeDatumProverePlacanjaClanarine();

                foreach (var k in korisnici)
                {
                    k.Kazna += 500;
                    k.DatumProverePlacanjaClanarine = null;
                    await KorisnikDao.SacuvajIzmeneKorisnika(k);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<bool> ObavestiKorisnikeDaVrateKnjigu()
        {
            try
            {
                List<Iznajmljivanje> iznajmljivanja = await IznajmljivanjeDao.PreuzmiIznajmljivanjaKorisnikaKojiTrebaDaSeObaveste();

                foreach (var i in iznajmljivanja)
                {
                    MailSenderHelper.PosaljiMejlOVracanjuKnjige(i);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}