
namespace CouchParty.TournamentManager.Hubs {

        // SCHEDULE Messages
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public partial class TournamentHub : Hub<ITournamentHub> {

        // <summary>
        // Tell Clients (awaiting players) that an opponent is still in match
        // <summary>
        Task WaitMatch() {
            var data = "";
            return Clients.Group("").ScheduleMatchWaiting(data);
        }

        // <summary>
        // Tell Clients all players are ready in lobby
        // </summary>
        Task ReadyMatch() {
            var data = "";
            return Clients.Group("").ScheduleMatchReady(data);
        }


        // <summary>
        // Tell Clients that match is ready to be joined 
        // typically this means a dedicated server has completed startup
        // </summary>
        Task StartMatch() {
            string serverHost = "";
            int serverPort = 0;
            string password = "";

            //return Clients.All.SendAsync("ClientStartMatch", serverHost, serverPort, password);
            return Clients.Group("match1").ScheduleMatchStart(serverHost, serverPort, password);
        }
    }
}
