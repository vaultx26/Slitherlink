using Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService;

namespace Slitherlink.SlitherlinkCore
{
    public class CommentGame
    {
        private readonly CommentService commentService = new CommentServiceEF();
        public void Comment()
        {
            string name;
            string content;
            Console.WriteLine("Vaše meno : ");
            name = Console.ReadLine();
            Console.WriteLine("Vaš komentár : ");
            content = Console.ReadLine();
            commentService.AddComment(new SlitherlinkEntity.Comment { Author = name, Content = content, Time = DateTime.Now });
        }
    }
}
