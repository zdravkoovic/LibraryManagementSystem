using System.Collections.Generic;

namespace ClientModels.Prikaz
{
    public class KnjigaSaStranama
    {
        public List<KnjigaPrikaz> Knjige { get; set; }
        public int BrojStrana { get; set; }
    }
}