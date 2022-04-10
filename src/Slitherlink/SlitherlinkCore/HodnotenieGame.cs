using Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService;
using Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore
{
    public class HodnotenieGame
    {
        private readonly CommentService commentService = new CommentServiceEF();
        private readonly HodnotenieService hodnotenieService = new HodnotenieServiceEF();
        public void Rate()
        {
            string name;
            string content;
            int rate;
            Console.WriteLine("Vaše meno : ");
            name = Console.ReadLine();
            Console.WriteLine("Vaš komentár : ");
            content = Console.ReadLine();
            Console.WriteLine("Vaše hodnotenie od 1 po 5 : ");
            rate = int.Parse(Console.ReadLine());
            commentService.AddComment(new SlitherlinkEntity.Comment { Author = name, Content = content, Time = DateTime.Now });
            hodnotenieService.Add_hodnotenie(new SlitherlinkEntity.Hodnotenie { stars = rate, Time = DateTime.Now, Meno = name });
        }
    }
}
