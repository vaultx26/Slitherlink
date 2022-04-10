using System;


namespace Slitherlink.SlitherlinkCore.SlitherlinkEntity
{
    [Serializable]
    public class Hodnotenie
    {
        public int ID { get; set; }
        public int stars { get; set; }
        public string Meno { get; set; }
        public DateTime Time { get; set; }
    }
}
