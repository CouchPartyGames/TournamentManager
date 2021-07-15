using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


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
}


