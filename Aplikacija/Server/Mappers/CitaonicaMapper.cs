using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class CitaonicaMapper
    {
        public static CitaonicaPrikaz CitaonicaToCitaonicaPrikaz(Citaonica citaonica)
        {
            if (citaonica == null) return null;

            return new CitaonicaPrikaz()
            {
                Id = citaonica.Id,
                Naziv = citaonica.Naziv,
                BrojVrsta = citaonica.BrojVrsta,
                BrojKolona = citaonica.BrojKolona
            };
        }

        public static List<CitaonicaPrikaz> CitaoniceToCitaonicePrikaz(List<Citaonica> citaonice)
        {
            List<CitaonicaPrikaz> citaonicaPrikaz = new List<CitaonicaPrikaz>();

            foreach (var c in citaonice)
            {
                citaonicaPrikaz.Add(CitaonicaToCitaonicaPrikaz(c));
            }

            return citaonicaPrikaz;
        }
    }
}