namespace ClientModels.Prikaz
{
    public class MestoPrikaz
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? TrenutnoCitanjeId { get; set; }
        public bool Racunar { get; set; }
        public bool Zauzeto { get; set; }
    }
}