
namespace CouchParty.TournamentManager.Hubs {



        // Client -> Server
    public partial class TournamentHub : Hub<ITournamentHub> {

        ILogger<TournamentHub> logger;

        public static TournamentHub Instance { get; private set; }


        public TournamentHub(ILogger<TournamentHub> logger) {
            this.logger = logger;
            Instance = this;
        }

        public async override Task OnConnectedAsync() {
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception) {
            var name = "Player";
            var exists = opps.TryGetValue(Context.ConnectionId, out name);
            if (!exists) {
                name = "Player";
            }
                
            await OpponentLeft(name);
            await base.OnDisconnectedAsync(exception);
        }

    }

}
