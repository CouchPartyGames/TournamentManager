using Microsoft.AspNetCore.Mvc;

namespace CouchParty.TournamentManager.Controllers {

    [ApiController]
    [Route("v1/[controller]")]
    public class MatchController : ControllerBase {

        private readonly ILogger<MatchController> _logger;

        private readonly IHubContext<TournamentHub, ITournamentHub> _hub;

        public MatchController(ILogger<MatchController> logger, IHubContext<TournamentHub, ITournamentHub> context) {
            _logger = logger;
            _hub = context;
        }

        [HttpGet("{id:int}")]
        public string GetById(int id) {
            return "item " + id;
        }

    }
}
