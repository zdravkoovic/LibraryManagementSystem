using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using DataLayer.Interfaces;
using Helper;
using Mappers;
using Microsoft.AspNetCore.Http;
using Models;
using Parameters;
using Services.Interfaces;

namespace Services
{
    public class KnjigaService : IKnjigaService
    {
        private IKnjigaDao KnjigaDao { get; set; }
        private IFilterDao FilterDao { get; set; }
        private IAutorDao AutorDao { get; set; }
        private ISlikaDao SlikaDao { get; set; }
        private IFizickaKnjigaDao FizickaKnjigaDao { get; set; }

        public KnjigaService(IKnjigaDao knjigaDao, IFilterDao filterDao, IAutorDao autorDao, ISlikaDao slikaDao, IFizickaKnjigaDao fizickaKnjigaDao)
        {
            KnjigaDao = knjigaDao;
            FilterDao = filterDao;
            AutorDao = autorDao;
            SlikaDao = slikaDao;
            FizickaKnjigaDao = fizickaKnjigaDao;
        }

        public async Task<KnjigaPrikaz> PreuzmiKnjiguPoId(int knjigaId)
        {
            try
            {
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjigaId);
            
                return KnjigaMapper.KnjigaToKnjigaPrikaz(knjiga);            
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<KnjigaSaStranama> PreuzmiKnjige(string zanrovi, string rodovi, string vrste, string jezici, bool slobodna, int page, string pretraga)
        {
            try
            {
                List<int> zanroviIds = zanrovi is null ? null : zanrovi.Split(",")
                                        .Select(z => Int32.Parse(z))
                                        .ToList();
            
                List<int> rodoviIds = rodovi is null ? null : rodovi.Split(",")
                                            .Select(z => Int32.Parse(z))
                                            .ToList();

                List<int> vrsteIds = vrste is null ? null : vrste.Split(",")
                                            .Select(z => Int32.Parse(z))
                                            .ToList();

                List<int> jeziciIds = jezici is null ? null : jezici.Split(",")
                                            .Select(z => Int32.Parse(z))
                                            .ToList();

                var result = await KnjigaDao.PreuzmiKnjige(zanroviIds, rodoviIds, vrsteIds, jeziciIds, slobodna, page, pretraga);

                return new KnjigaSaStranama()
                {
                    Knjige = KnjigaMapper.KnjigeToKnjigePrikaz(result.Knjige),
                    BrojStrana = result.BrojStrana
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjigaSaStranama> PretraziKnjige(string pretraga, int page)
        {
            try
            {
                var result = await KnjigaDao.PretraziKnjige(pretraga, page);

                return new KnjigaSaStranama()
                {
                    Knjige = KnjigaMapper.KnjigeToKnjigePrikaz(result.Knjige),
                    BrojStrana = result.BrojStrana
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjigaPrikaz>> PreuzmiSveKnjigeAutora(int autorId)
        {
            try
            {
                List<Knjiga> knjige = await KnjigaDao.PreuzmiSveKnjigeAutora(autorId);
                return KnjigaMapper.KnjigeToKnjigePrikaz(knjige);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<KnjigaPrikaz>> PreuzmiKnjigeKojeCekaKorisnik(int korisnikId)
        {
            try
            {
                List<Knjiga> knjige = await KnjigaDao.PreuzmiKnjigeKojeCekaKorisnik(korisnikId);
                return KnjigaMapper.KnjigeToKnjigePrikaz(knjige);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjigaPrikaz> DodajKnjigu(KnjigaParametri knjigaParametri)
        {
            try
            {
                if (knjigaParametri.Naslov is null)
                {
                    throw new Exception("Knjiga mora imati naslov.");
                }

                Autor autor = await AutorDao.PreuzmiAutoraPoId(knjigaParametri.AutorId);
                List<KnjizevniZanr> knjizevniZanrovi = await FilterDao.PreuzmiKnjizevneZanrovePoId(knjigaParametri.KnjizevniZanroviIds);
                KnjizevniRod knjizevniRod = await FilterDao.PreuzmiKnjizevniRodPoId(knjigaParametri.KnjizevniRodId);
                KnjizevnaVrsta knjizevnaVrsta = await FilterDao.PreuzmiKnjizevnuVrstuPoId(knjigaParametri.KnjizevnaVrstaId);

                Slika slika = null;
                string link = await SlikeHelper.GenerisiSliku(knjigaParametri.Slika);

                if (link != null)
                {
                    slika = await SlikaDao.DodajSliku(link);
                }

                Knjiga knjiga = new Knjiga()
                {
                    Naslov = knjigaParametri.Naslov,
                    Opis = knjigaParametri.Opis == "" ? null : knjigaParametri.Opis,
                    Autor = autor,
                    KnjizevniZanrovi = knjizevniZanrovi,
                    KnjizevniRod = knjizevniRod,
                    KnjizevnaVrsta = knjizevnaVrsta,
                    Slika = slika
                };

                knjiga = await KnjigaDao.DodajKnjigu(knjiga);
                knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjiga.Id);

                return KnjigaMapper.KnjigaToKnjigaPrikaz(knjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjigaPrikaz> IzmeniKnjigu(int knjigaId, KnjigaParametri knjigaParametri)
        {
            try
            {
                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjigaId);

                if (knjigaParametri.Naslov != null && knjigaParametri.Naslov != "")
                {
                    knjiga.Naslov = knjigaParametri.Naslov;
                }

                if (knjigaParametri.Opis != null && knjigaParametri.Opis != "")
                {
                    knjiga.Opis = knjigaParametri.Opis;
                }

                if (knjigaParametri.AutorId > 0)
                {
                    knjiga.Autor = await AutorDao.PreuzmiAutoraPoId(knjigaParametri.AutorId);
                }

                if (knjigaParametri.KnjizevniZanroviIds != null)
                {
                    knjiga.KnjizevniZanrovi = await FilterDao.PreuzmiKnjizevneZanrovePoId(knjigaParametri.KnjizevniZanroviIds);
                }

                if (knjigaParametri.KnjizevniRodId > 0)
                {
                    knjiga.KnjizevniRod = await FilterDao.PreuzmiKnjizevniRodPoId(knjigaParametri.KnjizevniRodId);
                }

                if (knjigaParametri.KnjizevnaVrstaId > 0)
                {
                    knjiga.KnjizevnaVrsta = await FilterDao.PreuzmiKnjizevnuVrstuPoId(knjigaParametri.KnjizevnaVrstaId);
                }

                knjiga = await KnjigaDao.SacuvajIzmeneKnjige(knjiga);
                knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjiga.Id);

                return KnjigaMapper.KnjigaToKnjigaPrikaz(knjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        public async Task<bool> ObrisiKnjigu(int knjigaId)
        {
            try
            {
                List<FizickaKnjiga> zauzeteFizickeKnjige = await FizickaKnjigaDao.PreuzmiZauzeteFizickeKnjige(knjigaId);

                if (zauzeteFizickeKnjige.Count > 0)
                {
                    throw new Exception("Knjiga se čita. Nemoguće je obrisati. Pokušajte kasnije.");
                }

                Knjiga knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjigaId);
                if (knjiga.Slika != null)
                {
                    Slika slika = await SlikaDao.PreuzmiSlikuPoId(knjiga.Slika.Id);
                    await SlikaDao.ObrisiSliku(slika);
                    SlikeHelper.ObrisiSlikuSaDiska(slika);
                }
                bool knjigaObrisana = await KnjigaDao.ObrisiKnjigu(knjiga);

                return knjigaObrisana;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<KnjigaPrikaz> DodajSlikuKnjizi(int knjigaId, SlikaParametar slikaForm)
        {
            try
            {
                var knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjigaId);
                
                Slika slika = null;
                string link = await SlikeHelper.GenerisiSliku(slikaForm.Slika);

                if (link == null) return KnjigaMapper.KnjigaToKnjigaPrikaz(knjiga);

                slika = await SlikaDao.DodajSliku(link);

                knjiga.Slika = slika;
                knjiga = await KnjigaDao.SacuvajIzmeneKnjige(knjiga);
                knjiga = await KnjigaDao.PreuzmiKnjiguPoId(knjiga.Id);
                return KnjigaMapper.KnjigaToKnjigaPrikaz(knjiga);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}