using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService
{
    [Serializable]
    public class CommentServiceEF : CommentService
    {
        public void AddComment(Comment comment)
        {
            using (var db = new SlitherlinkDbContext())
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
        }

        public IList<Comment> GetComment()
        {
            using (var db = new SlitherlinkDbContext())
            {
                return (from s in db.Comments
                        orderby s.Author descending
                        select s).Take(4).ToList();
            }
        }
        public void DeleteComment()
        {
            using (var db = new SlitherlinkDbContext())
            {
                db.Database.ExecuteSqlRaw("TRUNCATE TABLE Comment");
            }
        }
    }
}
