using Microsoft.AspNetCore.Mvc;
using Slitherlink.SlitherlinkCore;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using Slitherlink.SlitherlinkCore.SlitherlinkService;
using Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService;
using Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService;
using SlitherlinkWeb.Models;

namespace SlitherlinkWeb.Controllers
{
    public class SlitherLinkController : Controller
    {
        private const string FieldSessionKey = "field";

        private ScoreService scoreService = new ScoreServiceEF();
        private CommentService commentService = new CommentServiceEF();
        private HodnotenieService hodnotenieService = new HodnotenieServiceEF();
        private SlitherLinkModel CreateModel()
        {
            var field = (Field)HttpContext.Session.GetObjects(FieldSessionKey);
            var scores = scoreService.getScoreList();
            var comments = commentService.GetComment();
            var hodnotenia = hodnotenieService.Get_hodnotenie();
            return new SlitherLinkModel { Field = field, Scores = scores, Comment = comments, Hodnotenies = hodnotenia};
        }
        private SlitherLinkModel CreateScores()
        {
            var score = scoreService.getScoreList();
            return new SlitherLinkModel { Scores = score };
        }
        public IActionResult Index()
        {
            var field = new Field(11, 11);
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", CreateModel());
        }
        private SlitherLinkModel CreateSaveModel(string player, string Comment , int Rating)
        {
            var field = (Field)HttpContext.Session.GetObjects(FieldSessionKey);
            Hodnotenie hodnotenie = new Hodnotenie();
            Comment comment = new Comment();
            Score score = new Score();
            score.score = field.getScore();
            score.DateTime = DateTime.Now;
            score.Player = player;
            comment.Author = player;
            comment.Content = Comment;
            hodnotenie.stars = Rating;
            hodnotenie.Meno = player;
            commentService.AddComment(comment);
            scoreService.addScore(score);
            hodnotenieService.Add_hodnotenie(hodnotenie);
            return new SlitherLinkModel { Scores = scoreService.getScoreList(), Comment = commentService.GetComment(), Hodnotenies = hodnotenieService.Get_hodnotenie() };
        }
        public SlitherLinkModel CreateGameModel(string action , string type , int x , int y)
        {
            var field = (Field)HttpContext.Session.GetObjects(FieldSessionKey);
            GameSourse gameSourse = new GameSourse(field);
            gameSourse.action(action, x, y , type);
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return new SlitherLinkModel { Field = field };
        }
        public IActionResult Game(string action, string type, int x, int y)
        {
            return View("SlitherLinkGame", CreateGameModel(action, type, x, y));
        }
        public IActionResult Ending()
        {
            return View("EndGame");
        }
        public IActionResult SaveScore(string player, string Comment, int Rating)
        {
            return View("HighScores", CreateSaveModel(player, Comment, Rating));
        }
        public IActionResult SlitherLinkGame()
        {
            return View("SlitherLinkGame", CreateModel());
        }
        public IActionResult HighScores(string player, int points, string Comment, int Rating)
        {
            return View("HighScores", CreateModel());
        }
        public IActionResult PlayGame(char tile)
        {
            var field = (Field)HttpContext.Session.GetObjects(FieldSessionKey);
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", CreateModel());
        }
        public IActionResult Rules()
        {
            return View("Rules");
        }
    }
}
