

using Slitherlink.SlitherlinkCore;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;

namespace SlitherlinkWeb.Models
{
    public class SlitherLinkModel
    {
        public Field Field { get; set; }
        public string Message { get; set; }
        public IList<Score> Scores { get; set; }
    }
}
