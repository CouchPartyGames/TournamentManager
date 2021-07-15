
namespace CouchParty.TournamentManager.Hubs {



        // DRAW Messages
        // Server -> Client
    public partial class TournamentHub : Hub<ITournamentHub> {

        Task DrawEnrollOpponent() {

            return Clients.Others.DrawEnrollment();
        }

        // <summary>
        // Tell Clients the Tournament/Draw is Finalized
        // Meaning no more opponents can enroll in the Tournament
        // </summary>
        async Task DrawFinalized() {
            var tournamentId = 1;
            await Clients.All.DrawFinalized(tournamentId);
        }

        // <summary>
        // Tell Clients the draw has been updated
        // Send them a json copy of the full draw
        // </summary>
        async Task DrawRefresh() {
            var jsonDraw = "";

            await Clients.All.DrawRefresh(jsonDraw);
        }


        // <summary>
        // Tell Clients an Event in the Draw (Match Started, Match Completed)
        // </summary>
        async Task DrawMatchEventUpdate() {
            // Started, Updated, Completed
            var matchId = 1;
            var msgType = 1;
            var data = "";

            await Clients.All.DrawMatchUpdated(matchId, msgType, data);
        }


    }

}
