using Microsoft.AspNetCore.Mvc;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService;

namespace SlitherlinkWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly CommentService _commentService = new CommentServiceEF();
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetComment();
        }
        [HttpPost]
        public void Post([FromBody] Comment comment)
        {
            _commentService.AddComment(comment);
        }
    }
}
