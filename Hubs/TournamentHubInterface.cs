

namespace CouchParty.TournamentManager.Hubs {


    public interface ITournamentHub {

            // Scheduling
        Task ScheduleMatchWaiting(string data);
        Task ScheduleMatchReady(string data);
        Task ScheduleMatchStart(string host, int port, string password);

            // Opponent
        Task OpponentJoined(string name);
        Task OpponentLeft(string name);
        Task OpponentChat(string msg);

            // Draw
        Task DrawEnrollment();
        Task DrawUnenrollment();
        Task DrawFinalized(int tournamentId);
        Task DrawRefresh(string jsonDraw);
        Task DrawMatchUpdated(int match, int messageType, string data); 
    }


    public interface ITournamentHub2 {

            // Dedicated Server Schedule
        Task ServerMatchWaiting(string data);
        Task ServerMatchReady(string data);

            // Match
        Task MatchStarted(int matchId);
        Task MatchProgress(int matchId, string data);
        Task MatchCompleted(int matchId, string data);

            // Draw
        Task DrawReady(int tId);
        Task DrawComplete(int tId);
        Task DrawResults(int tId);

            // Opponent
        Task OpponentJoined(string data);
        Task OpponentLeft(string data);
        Task OpponentChat(string msg);
    }
}


