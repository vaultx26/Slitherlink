using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService
{
    public interface CommentService
    {
        void AddComment(Comment comment);
        IList<Comment> GetComment();
        void DeleteComment();
    }
}
