using System.Collections.Generic;

namespace CouchParty.TournamentManager.Hubs {



        // OPPONENT Messages
    public partial class TournamentHub : Hub<ITournamentHub> {

        static Dictionary<string, string> opps = new Dictionary<string, string>();

        // <summary>
        // Tell all Clients a new Opponent has Joined
        // </summary>
        async Task OpponentJoined(string name, string platform) {
            await Clients.All.OpponentJoined($"{name} ({platform})");
        }

        // Tell Clients a New Opponent has Left
        async Task OpponentLeft(string name) {
            await Clients.All.OpponentLeft(name);
        }

        // <summary>
        // Temporary
        // </summary>
        public async Task SetCreds(string name, string platform) {
            logger.LogInformation("Opps Count: " + opps.Count);

            if (!opps.ContainsKey(Context.ConnectionId)) {
                opps.Add(Context.ConnectionId, name);
            }
            
            await OpponentJoined(name, platform);
        }
    }




}
