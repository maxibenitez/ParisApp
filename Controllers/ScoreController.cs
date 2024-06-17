using Microsoft.AspNetCore.Mvc;
using ParisApp.Entities;
using ParisApp.Services.ScoreService;

namespace ParisApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : Controller
    {
        #region Properties

        private readonly IScoreService _scoreServ;

        #endregion

        #region Builders

        public ScoreController(IScoreService scoreServ)
        {
            _scoreServ = scoreServ;
        }

        #endregion

        [HttpPost("insert-score")]
        public async Task<IActionResult> InsertScore(InsertScoreParameters parameters)
        {
            if (await _scoreServ.InsertScore(parameters))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
