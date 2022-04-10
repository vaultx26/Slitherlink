using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore.SlitherlinkEntity
{
    [Serializable]
    public class Score
    {
        public string Player { get; set; }
        public int score { get; set; }
        public DateTime DateTime { get; set; }
        public int ID { get; set; }

    }
}
