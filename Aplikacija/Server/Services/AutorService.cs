using System;
using System.Collections.Generic;
using System.IO;
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
    public class AutorService : IAutorService
    {
        private IKnjigaDao KnjigaDao { get; set; }
        private IAutorDao AutorDao { get; set; }
        private ISlikaDao SlikaDao { get; set; }

        public AutorService(IKnjigaDao knjigaDao, IAutorDao autorDao, ISlikaDao slikaDao)
        {
            KnjigaDao = knjigaDao;
            AutorDao = autorDao;
            SlikaDao = slikaDao;
        }

        public async Task<AutorPrikaz> DodajAutora(AutorParametri autorParametri)
        {
            try
            {
                if (autorParametri.Ime == null || autorParametri.Prezime == null)
                {
                    throw new Exception("Autor mora imati ime i prezime.");
                }

                if (autorParametri.DatumRodjenja != null && autorParametri.DatumSmrti != null)
                {
                    if (autorParametri.DatumRodjenja > autorParametri.DatumSmrti)
                    {
                        throw new Exception("Datum rođenja autora mora biti pre njegovog datuma smrti.");
                    }
                }

                Slika slika = null;
                string link = await SlikeHelper.GenerisiSliku(autorParametri.Slika);

                if (link != null)
                {
                    slika = await SlikaDao.DodajSliku(link);
                }

                Autor autor = new Autor()
                {
                    Ime = autorParametri.Ime,
                    Prezime = autorParametri.Prezime,
                    MestoRodjenja = autorParametri.MestoRodjenja,
                    MestoSmrti = autorParametri.MestoSmrti,
                    DatumRodjenja = autorParametri.DatumRodjenja,
                    DatumSmrti = autorParametri.DatumSmrti,
                    OAutoru = autorParametri.OAutoru,
                    Slika = slika
                };

                autor = await AutorDao.DodajAutora(autor);
                autor = await AutorDao.PreuzmiAutoraPoId(autor.Id);

                return AutorMapper.AutorToAutorPrikaz(autor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutorPrikaz> IzmeniAutora(int autorId, AutorParametri autorParametri)
        {
            try
            {
                if (autorParametri.Ime == null || autorParametri.Prezime == null)
                {
                    throw new Exception("Autor mora imati ime i prezime.");
                }

                if (autorParametri.DatumRodjenja != null && autorParametri.DatumSmrti != null)
                {
                    if (autorParametri.DatumRodjenja > autorParametri.DatumSmrti)
                    {
                        throw new Exception("Datum rođenja autora mora biti pre njegovog datuma smrti.");
                    }
                }

                Autor autor = await AutorDao.PreuzmiAutoraPoId(autorId);

                autor.Ime = autorParametri.Ime;
                autor.Prezime = autorParametri.Prezime;
                autor.MestoRodjenja = autorParametri.MestoRodjenja;
                autor.MestoSmrti = autorParametri.MestoSmrti;
                autor.DatumRodjenja = autorParametri.DatumRodjenja;
                autor.DatumSmrti = autorParametri.DatumSmrti;
                autor.OAutoru = autorParametri.OAutoru;

                autor = await AutorDao.SacuvajIzmeneAutora(autor);
                autor = await AutorDao.PreuzmiAutoraPoId(autor.Id);
                return AutorMapper.AutorToAutorPrikaz(autor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiAutora(int autorId)
        {
            try
            {
                List<Knjiga> napisaneKnjigeAutora = await KnjigaDao.PreuzmiSveKnjigeAutora(autorId);
                if (napisaneKnjigeAutora.Count > 0)
                {
                    throw new Exception("Autora nije moguće obrisati. Postoje knjige koje je napisao. Pokušajte da ga izmenite.");
                }
                Autor autor = await AutorDao.PreuzmiAutoraPoId(autorId);

                return await AutorDao.ObrisiAutora(autor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutorSaStranama> PretraziAutore(string pretraga, int page)
        {
            try
            {
                var result = await AutorDao.PretraziAutore(pretraga, page);

                return new AutorSaStranama()
                {
                    Autori = AutorMapper.AutoriToAutoriPrikaz(result.Autori),
                    BrojStrana = result.BrojStrana
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutorPrikaz> PreuzmiAutoraPoId(int autorId)
        {
            try
            {
                Autor autor = await AutorDao.PreuzmiAutoraPoId(autorId);

                return AutorMapper.AutorToAutorPrikaz(autor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutorSaStranama> PreuzmiAutore(int page)
        {
            try
            {
                var result = await AutorDao.PreuzmiAutore(page);

                return new AutorSaStranama()
                {
                    Autori = AutorMapper.AutoriToAutoriPrikaz(result.Autori),
                    BrojStrana = result.BrojStrana
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AutorPrikaz> DodajSlikuAutoru(int autorId, SlikaParametar slikaFile)
        {
            try
            {
                var autor = await AutorDao.PreuzmiAutoraPoId(autorId);
                
                Slika slika = null;
                string link = await SlikeHelper.GenerisiSliku(slikaFile.Slika);

                if (link == null) return AutorMapper.AutorToAutorPrikaz(autor);

                slika = await SlikaDao.DodajSliku(link);

                autor.Slika = slika;
                autor = await AutorDao.SacuvajIzmeneAutora(autor);
                autor = await AutorDao.PreuzmiAutoraPoId(autor.Id);
                return AutorMapper.AutorToAutorPrikaz(autor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}