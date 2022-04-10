using System;


namespace Slitherlink.SlitherlinkCore.SlitherlinkEntity
{
    [Serializable]
    public class Comment
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
