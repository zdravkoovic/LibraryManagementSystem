using System.Collections.Generic;
using System.Linq;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class MestoMapper
    {
        public static MestoPrikaz MestoToMestoPrikaz(Mesto mesto)
        {
            if (mesto == null) return null;

            return new MestoPrikaz()
            {
                Id = mesto.Id,
                X = mesto.X,
                Y = mesto.Y,
                TrenutnoCitanjeId = mesto.Citanja?.Where(c => c.VremeVracanjaKnjige == null).Select(c => c.Id).FirstOrDefault(),
                Racunar = mesto.Racunar,
                Zauzeto = mesto.Zauzeto
            };
        }

        public static List<MestoPrikaz> MestaToMestaPrikaz(List<Mesto> mesta)
        {
            List<MestoPrikaz> mestaPrikaz = new List<MestoPrikaz>();

            foreach (var m in mesta)
            {
                mestaPrikaz.Add(MestoToMestoPrikaz(m));
            }

            return mestaPrikaz;
        }
    }
}