using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService
{
    public class HodnotenieServiceEF : HodnotenieService
    {
        public void Add_hodnotenie(Hodnotenie hodnotenie)
        {
            using (var context = new SlitherlinkDbContext())
            {
                context.Hodnotenies.Add(hodnotenie);
                context.SaveChanges();
            }
        }
        public IList<Hodnotenie> Get_hodnotenie()
        {
            using (var context = new SlitherlinkDbContext())
            {
                return (from s in context.Hodnotenies orderby s.stars descending select s).ToList();
            }
        }

    }
}
