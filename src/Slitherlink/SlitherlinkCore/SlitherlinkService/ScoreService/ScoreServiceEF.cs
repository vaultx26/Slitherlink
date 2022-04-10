using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Slitherlink.SlitherlinkCore.SlitherlinkService
{
    public class ScoreServiceEF : ScoreService
    {
        public void addScore(Score score)
        {
            using (var context = new SlitherlinkDbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }
        public IList<Score> getScoreList()
        {
            using (var context = new SlitherlinkDbContext())
            {
                return (from s in context.Scores orderby s.score descending select s).ToList();
            }
        }
        public void removeScore()
        {
            using (var context = new SlitherlinkDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Scores");
            }
        }

    }
}
