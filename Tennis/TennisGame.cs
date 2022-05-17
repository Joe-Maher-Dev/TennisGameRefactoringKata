using Tennis.Enums;
using Tennis.Extensions;
using Tennis.Interfaces;

namespace Tennis
{
    public class TennisGame : ITennisGame
    {
        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;

        public int GamesWonByPlayerOne;
        public int GamesWonByPlayerTwo;

        public TennisGame(IPlayer playerOne, IPlayer playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            GamesWonByPlayerOne = 0;
            GamesWonByPlayerTwo = 0;
        }

        public void AddPointToPlayer(PlayerNames playerName)
        {
            if (_playerOne.Name == playerName)
            {
                _playerOne.IncrementScore();
                return;
            }

            _playerTwo.IncrementScore();
        }

        public string GetCurrentScore()
        {
            var currentScoreDescription = 
                TennisScoreDescriptor.CurrentScore(_playerOne.CurrentScore, _playerTwo.CurrentScore);

            if (currentScoreDescription == WinningScoreDescriptors.PlayerOneHasWon.GetDescription())
            {
                GamesWonByPlayerOne++;
                ResetPlayerScores();
            }

            if (currentScoreDescription == WinningScoreDescriptors.PlayerTwoHasWon.GetDescription())
            {
                GamesWonByPlayerTwo++;
                ResetPlayerScores();
            }

            return currentScoreDescription;
        }

        private void ResetPlayerScores()
        {
            _playerOne.ResetScore();
            _playerTwo.ResetScore();
        }
    }

}

