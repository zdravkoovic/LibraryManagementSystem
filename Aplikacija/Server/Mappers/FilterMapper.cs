using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class FilterMapper
    {
        public static KnjizevniZanrPrikaz ZanrToZanrPrikaz(KnjizevniZanr knjizevniZanr)
        {
            if (knjizevniZanr == null) return null;

            return new KnjizevniZanrPrikaz()
            {
                Id = knjizevniZanr.Id,
                Naziv = knjizevniZanr.Naziv
            };
        }

        public static List<KnjizevniZanrPrikaz> ZanroviToZanroviPrikaz(List<KnjizevniZanr> knjizevniZanrovi)
        {
            List<KnjizevniZanrPrikaz> knjizevniZanroviPrikaz = new List<KnjizevniZanrPrikaz>();

            foreach (var kz in knjizevniZanrovi)
            {
                knjizevniZanroviPrikaz.Add(ZanrToZanrPrikaz(kz));
            }

            return knjizevniZanroviPrikaz;
        }

        public static KnjizevniRodPrikaz RodToRodPrikaz(KnjizevniRod knjizevniRod)
        {
            if (knjizevniRod == null) return null;

            return new KnjizevniRodPrikaz()
            {
                Id = knjizevniRod.Id,
                Naziv = knjizevniRod.Naziv
            };
        }

        public static List<KnjizevniRodPrikaz> RodoviToRodoviPrikaz(List<KnjizevniRod> knjizevniRodovi)
        {
            List<KnjizevniRodPrikaz> knjizevniRodoviPrikaz = new List<KnjizevniRodPrikaz>();

            foreach (var kr in knjizevniRodovi)
            {
                knjizevniRodoviPrikaz.Add(RodToRodPrikaz(kr));
            }

            return knjizevniRodoviPrikaz;
        }

        public static KnjizevnaVrstaPrikaz VrstaToVrstaPrikaz(KnjizevnaVrsta knjizevnaVrsta)
        {
            if (knjizevnaVrsta == null) return null;

            return new KnjizevnaVrstaPrikaz()
            {
                Id = knjizevnaVrsta.Id,
                Naziv = knjizevnaVrsta.Naziv,
                KnjizevniRodId = knjizevnaVrsta.KnjizevniRod.Id
            };
        }

        public static List<KnjizevnaVrstaPrikaz> VrsteToVrstePrikaz(List<KnjizevnaVrsta> knjizevneVrste)
        {
            List<KnjizevnaVrstaPrikaz> knjizevneVrstePrikaz = new List<KnjizevnaVrstaPrikaz>();

            foreach (var kv in knjizevneVrste)
            {
                knjizevneVrstePrikaz.Add(VrstaToVrstaPrikaz(kv));
            }

            return knjizevneVrstePrikaz;
        }

        public static JezikPrikaz JezikToJezikPrikaz(Jezik jezik)
        {
            if (jezik == null) return null;

            return new JezikPrikaz()
            {
                Id = jezik.Id,
                Naziv = jezik.Naziv
            };
        }

        public static List<JezikPrikaz> JeziciToJeziciPrikaz(List<Jezik> jezici)
        {
            List<JezikPrikaz> jeziciPrikaz = new List<JezikPrikaz>();

            foreach (var j in jezici)
            {
                jeziciPrikaz.Add(JezikToJezikPrikaz(j));
            };

            return jeziciPrikaz;
        }

        public static FilteriPrikaz NapraviFilteriPrikaz(List<KnjizevniZanr> knjizevniZanrovi, List<KnjizevniRod> knjizevniRodovi, List<KnjizevnaVrsta> knjizevneVrste, List<Jezik> jezici)
        {
            List<KnjizevniZanrPrikaz> zanrovi = ZanroviToZanroviPrikaz(knjizevniZanrovi);
            List<KnjizevniRodPrikaz> rodovi = RodoviToRodoviPrikaz(knjizevniRodovi);
            List<KnjizevnaVrstaPrikaz> vrste = VrsteToVrstePrikaz(knjizevneVrste);
            List<JezikPrikaz> jeziciPrikaz = JeziciToJeziciPrikaz(jezici);

            return new FilteriPrikaz()
            {
                KnjizevniZanroviPrikaz = zanrovi,
                KnjizevniRodoviPrikaz = rodovi,
                KnjizevneVrstePrikaz = vrste,
                JeziciPrikaz = jeziciPrikaz
            };
        }
    }
}