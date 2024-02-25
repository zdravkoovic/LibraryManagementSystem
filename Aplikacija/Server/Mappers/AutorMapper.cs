using System.Collections.Generic;
using System.IO;
using ClientModels.Prikaz;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Mappers
{
    public static class AutorMapper
    {
        public static AutorPrikaz AutorToAutorPrikaz(Autor autor)
        {
            if (autor == null) return null;

            return new AutorPrikaz()
            {
                Id = autor.Id,
                Ime = autor.Ime,
                Prezime = autor.Prezime,
                Slika = autor.Slika?.Link,
                MestoRodjenja = autor.MestoRodjenja,
                MestoSmrti = autor.MestoSmrti,
                DatumRodjenja = autor.DatumRodjenja,
                DatumSmrti = autor.DatumSmrti,
                OAutoru = autor.OAutoru
            };
        }

        public static List<AutorPrikaz> AutoriToAutoriPrikaz(List<Autor> autori)
        {
            List<AutorPrikaz> autoriPrikaz = new List<AutorPrikaz>();

            foreach (var a in autori)
            {
                autoriPrikaz.Add(AutorToAutorPrikaz(a));
            }

            return autoriPrikaz;
        }
    }
}