using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using Slitherlink.SlitherlinkCore.SlitherlinkService;

namespace SlitherlinkWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : Controller
    {
        private ScoreService _scoreService = new ScoreServiceEF();
        [HttpGet]
        public IEnumerable<Score> GetScores()
        {
            return _scoreService.getScoreList();
        }
        [HttpPost]
        public void PostScore([FromBody] Score score)
        {
            score.DateTime = DateTime.Now;
            _scoreService.addScore(score);
        }
    }
}
