using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService
{
    public class FileHodnotenie : HodnotenieService
    {
        private string fileName = "hodnotenie.bin";
        private List<Hodnotenie> hodnotenies = new List<Hodnotenie>();
        public void Add_hodnotenie(Hodnotenie hodnotenie)
        {
            hodnotenies.Add(hodnotenie);
            Save();
        }
        public IList<Hodnotenie> Get_hodnotenie()
        {
            Load();
            return (from s in hodnotenies orderby s.stars descending select s).ToList();
        }
        private void Save()
        {
            using (var fs = File.OpenWrite(fileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, hodnotenies);
            }
        }
        public void Load() 
        {
            if (File.Exists(fileName))
            {
                using (var fs = File.OpenRead(fileName))
                {
                    var bf = new BinaryFormatter();
                    hodnotenies = (List<Hodnotenie>)bf.Deserialize(fs);
                }
            }
        }
    }
}
