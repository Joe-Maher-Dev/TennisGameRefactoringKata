using Tennis.Enums;
using Tennis.Interfaces;

namespace Tennis
{
    public class Player : IPlayer
    {
        public Player(PlayerNames name)
        {
            Name = name;
            CurrentScore = 0;
        }
        public PlayerNames Name { get; init; }

        public int CurrentScore { get; private set; }

        public void IncrementScore() => CurrentScore++;

        public void ResetScore() => CurrentScore = 0;
    }

}
