using System.Collections.Generic;
using System.Linq;
using ClientModels.Prikaz;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Mappers
{
    public static class KnjigaMapper
    {
        public static KnjigaPrikaz KnjigaToKnjigaPrikaz(Knjiga knjiga)
        {
            if (knjiga is null) return null;

            return new KnjigaPrikaz()
            {
                Id = knjiga.Id,
                Naslov = knjiga.Naslov,
                Slika = knjiga.Slika?.Link,
                AutorId = knjiga.Autor?.Id,
                AutorIme = knjiga.Autor?.Ime,
                AutorPrezime = knjiga.Autor?.Prezime,
                Opis = knjiga.Opis,
                KnjizevniZanrovi = knjiga.KnjizevniZanrovi?.Select(kz => kz.Naziv).ToList(),
                KnjizevniRod = knjiga.KnjizevniRod?.Naziv,
                KnjizevnaVrsta = knjiga.KnjizevnaVrsta?.Naziv,
                Slobodna = knjiga.FizickeKnjige.Where(fk => fk.Slobodna == true).Count() > 0
            };
        }

        public static List<KnjigaPrikaz> KnjigeToKnjigePrikaz(List<Knjiga> knjige)
        {
            List<KnjigaPrikaz> knjigePrikaz = new List<KnjigaPrikaz>();

            foreach (var k in knjige)
            {
                knjigePrikaz.Add(KnjigaToKnjigaPrikaz(k));
            }

            return knjigePrikaz;
        }
    }
}