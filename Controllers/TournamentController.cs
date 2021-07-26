using Microsoft.AspNetCore.Mvc;

namespace CouchParty.TournamentManager.Controllers {

    [ApiController]
    [Route("v1/[controller]")]
    public class TournamentController : ControllerBase {

        private readonly ILogger<TournamentController> _logger;

        private readonly IHubContext<TournamentHub, ITournamentHub> _hub;

        public TournamentController(ILogger<TournamentController> logger, IHubContext<TournamentHub, ITournamentHub> context) {
            _logger = logger;
            _hub = context;
        }


        [HttpGet("{id:int}")]
        public string GetById(int id) {
            return "item " + id;
        }
    }
}
