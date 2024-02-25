namespace ClientModels.Prikaz
{
    public class Poruka
    {
        public string Tekst { get; set; }

        public Poruka(string tekst)
        {
            Tekst = tekst;
        }
    }
}