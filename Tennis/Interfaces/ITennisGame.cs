using Tennis.Enums;

namespace Tennis.Interfaces
{
    public interface ITennisGame
    {
        string GetCurrentScore();

        void AddPointToPlayer(PlayerNames playerName);
    }
}
