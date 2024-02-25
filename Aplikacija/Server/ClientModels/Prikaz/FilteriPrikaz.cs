using System.Collections.Generic;

namespace ClientModels.Prikaz
{
    public class FilteriPrikaz
    {
        public List<KnjizevniZanrPrikaz> KnjizevniZanroviPrikaz { get; set; }
        public List<KnjizevniRodPrikaz> KnjizevniRodoviPrikaz { get; set; }
        public List<KnjizevnaVrstaPrikaz> KnjizevneVrstePrikaz { get; set; }
        public List<JezikPrikaz> JeziciPrikaz { get; set; }
    }
}