using Microsoft.AspNetCore.Mvc;
using APTector.Services;

namespace APTector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IScoringEngine _scoringEngine;

        // Внедрение сервиса через конструктор
        public AnalysisController(IScoringEngine scoringEngine)
        {
            _scoringEngine = scoringEngine;
        }

        // GET: api/analysis/score/1
        [HttpGet("score/{groupId}")]
        public IActionResult ComputeScore(int groupId)
        {
            double score = _scoringEngine.ComputeScore(groupId);
            return Ok(new { GroupId = groupId, Score = score });
        }
    }
}