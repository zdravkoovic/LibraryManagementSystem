using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Mappers;
using Microsoft.AspNetCore.SignalR;
using Models;
using Parameters;
using Services.Interfaces;
using SignalR;

namespace Services
{
    public class KomentarService : IKomentarService
    {
        private IKomentarDao KomentarDao { get; set; }
        private IKorisnikDao KorisnikDao { get; set; }
        private IKnjigaDao KnjigaDao { get; set; }

        public KomentarService(IKomentarDao komentarDao, IKorisnikDao korisnikDao, IKnjigaDao knjigaDao)
        {
            KomentarDao = komentarDao;
            KorisnikDao = korisnikDao;
            KnjigaDao = knjigaDao;
        }

        public async Task<KomentarPrikaz> DodajKomentar(KomentarParametri komentarParametri)
        {
            try
            {
                if(komentarParametri.Tekst == null)
                {
                    throw new Exception("Komentar mora imati tekst.");
                }
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(komentarParametri.KorisnikId);
                if(korisnik == null)
                {
                    throw new Exception("Korisnik ne postoji.");
                }
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(komentarParametri.KnjigaId);
                if(knjiga == null)
                {
                    throw new Exception("Knjiga ne postoji");
                }
                
                Komentar komentar = new Komentar()
                {
                    Tekst = komentarParametri.Tekst,
                    Datum = DateTime.Now,
                    Korisnik = korisnik,
                    Knjiga = knjiga
                };
                
                komentar = await KomentarDao.DodajKomentar(komentar);
                komentar = await KomentarDao.PreuzmiKomentarPoId(komentar.Id);
                return KomentarMapper.KomentarToKomentarPrikaz(komentar);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<KomentarPrikaz> IzmeniKomentar(int komentarId, KomentarParametri komentarParametri)
        {
            try
            {
                if(komentarParametri.Tekst == null)
                {
                    throw new Exception("Komentar mora imati tekst.");
                }
                Korisnik korisnik = await KorisnikDao.PreuzmiKorisnikaPoId(komentarParametri.KorisnikId);
                if (korisnik == null)
                {
                    throw new Exception("Korisnik ne postoji.");
                }
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(komentarParametri.KnjigaId);
                if (knjiga == null)
                {
                    throw new Exception("Knjiga ne postoji");
                }

                Komentar komentar = await KomentarDao.PreuzmiKomentarPoId(komentarId);

                komentar.Tekst = komentarParametri.Tekst;
                komentar.Datum = DateTime.Now;
                komentar.Korisnik = korisnik;
                komentar.Knjiga = knjiga;

                komentar = await KomentarDao.IzmeniKomentar(komentar);
                komentar = await KomentarDao.PreuzmiKomentarPoId(komentar.Id);

                return KomentarMapper.KomentarToKomentarPrikaz(komentar);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> ObrisiKomentar(int komentarId)
        {
            try
            {
                Komentar komentar = await KomentarDao.PreuzmiKomentarPoId(komentarId);
                bool result = await KomentarDao.ObrisiKomentar(komentar);

                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<KomentarPrikaz>> PreuzmiKomentareZaKnjigu(int knjigaId)
        {
            try
            {
                List<Komentar> komentari = await KomentarDao.PreuzmiKomentareZaKnjigu(knjigaId);

                return KomentarMapper.KomentariToKomentariPrikaz(komentari);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}