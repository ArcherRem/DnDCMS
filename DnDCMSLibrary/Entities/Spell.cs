namespace DnDCMSLibrary.Entities
{
    [System.Serializable]
    public class Spell
    {
        public int id;
        public string name { get; set; }
        public string level { get; set; }
        public string type { get; set; }
        public bool ritual { get; set; }
        public string effect { get; set; }
        public string castingtime { get; set; }
        public string range { get; set; }
        public string components { get; set; }
        public string duration { get; set; }
    }
}
