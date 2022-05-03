using Microsoft.AspNetCore.Mvc;
using Slitherlink.SlitherlinkCore;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using Slitherlink.SlitherlinkCore.SlitherlinkService;
using SlitherlinkWeb.Models;

namespace SlitherlinkWeb.Controllers
{
    public class SlitherLinkController : Controller
    {
        private const string FieldSessionKey = "field";
        
        private ScoreService scoreService = new ScoreServiceEF();
        private SlitherLinkModel CreateModel()
        {
            var field = (Field)HttpContext.Session.GetObjects(FieldSessionKey);
            var scores = scoreService.getScoreList();
            return new SlitherLinkModel { Field = field, Scores = scores };
        } 
        private SlitherLinkModel CreateScores()
        {
            var score = scoreService.getScoreList();
            return new SlitherLinkModel { Scores = score };
        }
        public IActionResult Index()
        {
            var field = new Field(11,11);
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", CreateModel());
        }
        private SlitherLinkModel CreateSaveModel(string player , int points)
        {
            Score score = new Score();
            score.score = points;
            score.DateTime = DateTime.Now;
            score.Player = player;
            scoreService.addScore(score);
            return new SlitherLinkModel { Scores = scoreService.getScoreList() };
        }
        public IActionResult SaveScore(string player , int points)
        {
            return View("HighScores", CreateSaveModel(player,points));
        }
        public IActionResult SlitherLinkGame()
        {
            return View("SlitherLinkGame" , CreateModel());
        }
        public IActionResult HighScores()
        {
            return View("HighScores" , CreateScores());
        }
        public IActionResult PlayGame(char tile)
        {
            var field = (Field) HttpContext.Session.GetObjects(FieldSessionKey);
            field.initializeField();
            if(field.isSolved())
            {
                scoreService.addScore(new Score() { Player = "Okay", DateTime = DateTime.Now, score = field.getScore() });  
            }
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", CreateModel());
        }
        public IActionResult Rules()
        {
            return View("Rules");
        }
    }
}
