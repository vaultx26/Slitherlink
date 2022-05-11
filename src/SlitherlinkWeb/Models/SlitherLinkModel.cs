

using Slitherlink.SlitherlinkCore;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;

namespace SlitherlinkWeb.Models
{
    public class SlitherLinkModel
    {
        public Field Field { get; set; }
        public IList<Score> Scores { get; set; }
        public IList<Comment> Comment { get; set; }
        public IList<Hodnotenie> Hodnotenies { get; set; }
    }
}
