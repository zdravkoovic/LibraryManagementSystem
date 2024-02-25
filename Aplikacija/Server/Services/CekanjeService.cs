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
    public class CekanjeService : ICekanjeService
    {
        private IKnjigaDao KnjigaDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }
        private ICekanjeDao CekanjeDao { get; set; }

        public CekanjeService(IKnjigaDao knjigaDao, IKorisnikDao korisnikDao, ICekanjeDao cekanjeDao)
        {
            KnjigaDao = knjigaDao;
            KorisnikDao = korisnikDao;
            CekanjeDao = cekanjeDao;
        }

        public async Task<bool> DodajCekanje(CekanjeParametri cekanjeParametri)
        {
            try
            {
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(cekanjeParametri.KnjigaId);
                Console.WriteLine("KorisnikDao: " + (KorisnikDao == null));
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(cekanjeParametri.KorisnikId);
                
                if (await CekanjeDao.KorisnikCekaKnjigu(cekanjeParametri.KorisnikId, cekanjeParametri.KnjigaId))
                {
                    throw new Exception("Korisnik je već prijavljen u red čekanja.");
                }

                if (knjiga == null)
                {
                    throw new Exception("Knjiga ne postoji.");
                }

                if (korisnik == null)
                {
                    throw new Exception("Korisnik ne postoji.");
                }

                Cekanje cekanje = new Cekanje()
                {
                    Datum = DateTime.Now,
                    Knjiga = knjiga,
                    Korisnik = korisnik
                };

                bool bCekanje = await CekanjeDao.DodajCekanje(cekanje);

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiCekanje(int cekanjeId)
        {
            try
            {
                Cekanje cekanje = await CekanjeDao.PreuzmiCekanjePoId(cekanjeId);

                return await CekanjeDao.ObrisiCekanje(cekanje);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<int> PreuzmiBrojKorisnikaKojiCekajuKnjigu(int knjigaId)
        {
            try
            {
                return await CekanjeDao.PreuzmiBrojKorisnikaKojiCekajuKnjigu(knjigaId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CekanjePrikaz>> PreuzmiCekanjaKorisnika(int korisnikId)
        {
            try
            {
                var cekanja = await CekanjeDao.PreuzmiCekanjaKorisnika(korisnikId);

                return CekanjeMapper.CekanjaToCekanjaPrikaz(cekanja);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}