using Microsoft.AspNetCore.Mvc;
using CouchParty.TournamentManager.Hubs;

namespace CouchParty.TournamentManager.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        IHubContext<TournamentHub, ITournamentHub> _hub;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHubContext<TournamentHub, ITournamentHub> context)
        {
            _logger = logger;
            _hub = context;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //_hub.SendMessage("API Call");
            //await _hub.Clients.All.SendAsync("Hello");
            await _hub.Clients.All.OpponentChat("Server");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
