using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
namespace Slitherlink.SlitherlinkCore.SlitherlinkService
{
    public interface ScoreService
    {
        void addScore(Score scoreService);
        void removeScore();
        IList<Score> getScoreList();
    }
}
