using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
namespace Slitherlink.SlitherlinkCore.SlitherlinkService
{
    public class FileScore : ScoreService
    {
        private string file_name = "score.bin";
        private IList<Score> _scores = new List<Score>();
        void ScoreService.addScore(Score score)
        {
            _scores.Add(score);
            Save();
        }

        IList<Score> ScoreService.getScoreList()
        {
            Load();
            return _scores.OrderByDescending(s => s.score).Take(3).ToList();
        }
        void ScoreService.removeScore()
        {
            _scores.Clear();
            File.Delete(file_name);
        }
        private void Save()
        {
            using(var stream = File.OpenWrite(file_name))
            {
                var tmp = new BinaryFormatter();
                tmp.Serialize(stream, _scores);
            }
        }
        private void Load()
        {
            if(File.Exists(file_name))
            {
                using (var stream = File.OpenRead(file_name))
                {
                    var tmp = new BinaryFormatter();
                    _scores = (IList<Score>)tmp.Deserialize(stream);   
                }
            }
        }
    }
}
