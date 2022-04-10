using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService
{
    public interface HodnotenieService
    {
        void Add_hodnotenie(Hodnotenie hodnotenie);
        IList<Hodnotenie> Get_hodnotenie();
    }
}
