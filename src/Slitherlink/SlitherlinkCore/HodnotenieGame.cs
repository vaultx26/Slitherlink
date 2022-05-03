using Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService;
using Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore
{
    [Serializable]
    public class HodnotenieGame
    {
        
        private readonly HodnotenieService hodnotenieService = new HodnotenieServiceEF();
        public void Rate()
        {
            string name;
            string content;
            int rate;
            Console.WriteLine("Vaše meno : ");
            name = Console.ReadLine();
            Console.WriteLine("Vaše hodnotenie od 1 po 5 : ");
            rate = int.Parse(Console.ReadLine());
            hodnotenieService.Add_hodnotenie(new SlitherlinkEntity.Hodnotenie { stars = rate, Time = DateTime.Now, Meno = name });
        }
    }
}
