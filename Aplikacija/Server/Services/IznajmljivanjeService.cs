using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Helper;
using Mappers;
using Models;
using Parameters;
using Services.Interfaces;

namespace Services
{
    public class IznajmljivanjeService : IIznajmljivanjeService
    {
        private IIznajmljivanjeDao IznajmljivanjeDao { get; set; }
        private IFizickaKnjigaDao FizickaKnjigaDao { get; set; }
        private IOgranakBibliotekeDao OgranakBibliotekeDao { get; set; }
        private IRadnikDao RadnikDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }
        private ICekanjeDao CekanjeDao { get; set; }

        public IznajmljivanjeService(IIznajmljivanjeDao iznajmljivanjeDao, IFizickaKnjigaDao fizickaKnjigaDao, IOgranakBibliotekeDao ogranakBibliotekeDao, 
                IRadnikDao radnikDao, IKorisnikDao korinsikDao, ICekanjeDao cekanjeDao)
        {
            IznajmljivanjeDao = iznajmljivanjeDao;
            FizickaKnjigaDao = fizickaKnjigaDao;
            OgranakBibliotekeDao = ogranakBibliotekeDao;
            RadnikDao = radnikDao;
            KorisnikDao = korinsikDao;
            CekanjeDao = cekanjeDao;
        }

        public async Task<IznajmljivanjePrikaz> DodajIznajmljivanje(IznajmljivanjeParametri iznajmljivanjeParametri)
        {
            try
            {
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(iznajmljivanjeParametri.KorisnikId);
                if (korisnik == null)
                {
                    throw new Exception("Korisnik ne postoji.");
                }

                var trenutnaIznajmljivanja = await IznajmljivanjeDao.PreuzmiTrenutnaIznajmljivanjaKorisnika(iznajmljivanjeParametri.KorisnikId);
                if (trenutnaIznajmljivanja.Count > 3)
                {
                    throw new Exception("Korisnik ne može iznajmiti knjigu. Trenutno ima 3 iznajmljivanja.");
                }

                OgranakBiblioteke ogranakBiblioteke = await OgranakBibliotekeDao.PreuzmiOgranakBibliotekePoId(iznajmljivanjeParametri.OgranakBibliotekeId);
                Radnik radnik = await RadnikDao.PreuzmiRadnikaPoId(iznajmljivanjeParametri.RadnikDodelioId);
                FizickaKnjiga fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoSifri(iznajmljivanjeParametri.FizickaKnjigaSifra);
                if (fizickaKnjiga == null)
                {
                    throw new Exception("Pogrešna šifra knjige.");
                }

                if (fizickaKnjiga.Slobodna == false)
                {
                    throw new Exception("Knjiga je zauzeta.");
                }


                if (fizickaKnjiga.OgranakBiblioteke.Id != ogranakBiblioteke.Id)
                {
                    throw new Exception("Knjiga ne pripada ovom ogranku.");
                }

                if (korisnik.Kazna > 0)
                {
                    throw new Exception("Korisnik ima neisplaćena dugovanja.");
                }

                fizickaKnjiga.Slobodna = false;
                await FizickaKnjigaDao.SacuvajIzmeneFizickeKnjige(fizickaKnjiga);

                Iznajmljivanje iznajmljivanje = new Iznajmljivanje()
                {
                    Korisnik = korisnik,
                    RadnikDodelio = radnik,
                    OgranakBiblioteke = ogranakBiblioteke,
                    FizickaKnjiga = fizickaKnjiga,
                    DatumIznajmljivanja = DateTime.Now.Date,
                    DatumVracanja = null,
                    DatumProvere = DateTime.Now.AddDays(14).Date,
                    Kazna = 0
                };

                iznajmljivanje = await IznajmljivanjeDao.DodajIznajmljivanje(iznajmljivanje);
                iznajmljivanje = await IznajmljivanjeDao.PreuzmiIznajmljivanjePoId(iznajmljivanje.Id);

                return IznajmljivanjeMapper.IznajmljivanjeToIznajmljivanjePrikaz(iznajmljivanje);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<IznajmljivanjePrikaz>> PreuzmiIstorijuIznajmljivanjaKnjige(int knjigaId)
        {
            try
            {
                var iznajmljivanja = await IznajmljivanjeDao.PreuzmiIstorijuIznajmljivanjaKnjige(knjigaId);

                return IznajmljivanjeMapper.IznajmljivanjaToIznajmljivanjaPrikaz(iznajmljivanja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<IznajmljivanjePrikaz>> PreuzmiIznajmljivanjaKorisnika(int korisnikId)
        {
            try
            {
                var iznajmljivanja = await IznajmljivanjeDao.PreuzmiIznajmljivanjaKorisnika(korisnikId);

                return IznajmljivanjeMapper.IznajmljivanjaToIznajmljivanjaPrikaz(iznajmljivanja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IznajmljivanjePrikaz> VratiIznajmljenuKnjigu(int iznajmljivanjeId)
        {
            try
            {
                Iznajmljivanje iznajmljivanje = await IznajmljivanjeDao.PreuzmiIznajmljivanjePoId(iznajmljivanjeId);
                if (iznajmljivanje == null)
                {
                    throw new Exception("Iznajmljivanje ne postoji.");
                }
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(iznajmljivanje.Korisnik.Id);
                korisnik.Kazna -= iznajmljivanje.Kazna;
                await KorisnikDao.SacuvajIzmeneKorisnika(korisnik);

                FizickaKnjiga fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(iznajmljivanje.FizickaKnjiga.Id);
                fizickaKnjiga.Slobodna = true;
                fizickaKnjiga = await FizickaKnjigaDao.SacuvajIzmeneFizickeKnjige(fizickaKnjiga);
                fizickaKnjiga = await FizickaKnjigaDao.PreuzmiFizickuKnjiguPoId(fizickaKnjiga.Id);

                iznajmljivanje.DatumVracanja = DateTime.Now;

                iznajmljivanje = await IznajmljivanjeDao.SacuvajIzmeneIznajmljivanja(iznajmljivanje);
                iznajmljivanje = await IznajmljivanjeDao.PreuzmiIznajmljivanjePoId(iznajmljivanje.Id);

                List<Cekanje> cekanja = await CekanjeDao.PreuzmiCekanjaKnjige(fizickaKnjiga.Knjiga.Id);
                MailSenderHelper.ObavestiKorisnikeODosutpnostiKnjigeUOgranku(cekanja, iznajmljivanje.OgranakBiblioteke.Naziv);

                return IznajmljivanjeMapper.IznajmljivanjeToIznajmljivanjePrikaz(iznajmljivanje);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}