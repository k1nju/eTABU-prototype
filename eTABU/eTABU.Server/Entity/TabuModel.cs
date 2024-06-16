namespace eTABU.Server.Entity
{
    public class TabuModel
    {
        public int Id { get; set; }
        public string Words { get; set; }
        public List<string> NotAllowed { get; set; }
    }
}
