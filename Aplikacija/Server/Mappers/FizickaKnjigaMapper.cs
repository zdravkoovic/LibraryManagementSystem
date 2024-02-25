using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class FizickaKnjigaMapper
    {
        public static FizickaKnjigaPrikaz FizickaKnjigaToFizickaKnjigaPrikaz(FizickaKnjiga fizickaKnjiga)
        {
            if (fizickaKnjiga is null) return null;

            return new FizickaKnjigaPrikaz()
            {
                Id = fizickaKnjiga.Id,
                Sifra = fizickaKnjiga.Sifra,
                KnjigaNaslov = fizickaKnjiga.Knjiga?.Naslov,
                JezikNaziv = fizickaKnjiga.Jezik?.Naziv,
                IzdavacId = fizickaKnjiga.Izdavac?.Id,
                IzdavacNaziv = fizickaKnjiga.Izdavac?.Naziv,
                Slobodna = fizickaKnjiga.Slobodna
            };
        }

        public static List<FizickaKnjigaPrikaz> FizickeKnjigeToFizickeKnjigePrikaz(List<FizickaKnjiga> fizickeKnjige)
        {
            List<FizickaKnjigaPrikaz> fizickeKnjigePrikaz = new List<FizickaKnjigaPrikaz>();

            foreach (FizickaKnjiga fk in fizickeKnjige)
            {
                fizickeKnjigePrikaz.Add(FizickaKnjigaToFizickaKnjigaPrikaz(fk));
            }

            return fizickeKnjigePrikaz;
        }
    }
}