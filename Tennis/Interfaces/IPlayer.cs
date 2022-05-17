using Tennis.Enums;

namespace Tennis.Interfaces
{
    public interface IPlayer
    {
        int CurrentScore { get; }

        PlayerNames Name { get; init; }

        void IncrementScore();

        void ResetScore();
    }
}