using System.ComponentModel;
using Tennis.Enums;
using Tennis.Interfaces;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGameTests
    {
        [Theory, Description("The correct score description should be returned for a variety of different scores")]
        [ClassData(typeof(TestDataGenerator))]
        public void When_WeGetCurrentScore_Then_TheCorrectScoreDescriptionMustBeReturned(
            int playerOneScore, 
            int playerTwoScore, 
            string expectedScoreDescription)
        {
            // Arrange
            var playerOne = new Player(PlayerNames.PlayerOne);
            var playerTwo = new Player(PlayerNames.PlayerTwo);

            SetPlayerScore(playerOne, playerOneScore);
            SetPlayerScore(playerTwo, playerTwoScore);

            var game = new TennisGame(playerOne, playerTwo);

            // Act
            var actualScoreDescription = game.GetCurrentScore();

            // Assert
            Assert.Equal(expectedScoreDescription, actualScoreDescription);
        }

        [Fact, Description("When a point is added to player one then only player one's score must increment by one")]
        public void When_PointIsAddedToPlayerOne_Then_OnlyPlayerOnesScoreMustIncrementByOnePoint()
        {
            // Arrange
            var playerOne = new Player(PlayerNames.PlayerOne);
            var playerTwo = new Player(PlayerNames.PlayerTwo);

            var game = new TennisGame(playerOne, playerTwo);

            // Act
            game.AddPointToPlayer(PlayerNames.PlayerOne);

            //Assert
            Assert.Equal(1, playerOne.CurrentScore);
            Assert.Equal(0, playerTwo.CurrentScore);
        }

        [Fact, Description("When a point is added to player two then only player two's score must increment by one")]
        public void When_PointIsAddedToPlayerTwo_Then_OnlyPlayerTwosScoreMustIncrementByOnePoint()
        {
            // Arrange
            var playerOne = new Player(PlayerNames.PlayerOne);
            var playerTwo = new Player(PlayerNames.PlayerTwo);

            var game = new TennisGame(playerOne, playerTwo);

            // Act
            game.AddPointToPlayer(PlayerNames.PlayerTwo);

            //Assert
            Assert.Equal(0, playerOne.CurrentScore);
            Assert.Equal(1, playerTwo.CurrentScore);
        }

        [Fact, Description(
            @"When a game is won by player one then the count for games won by player one increases by one
            and both player scores are reset to zero")]
        public void When_GameIsWonByPlayerOne_Then_GamesWonByPlayerOneIsIncrementedByOneAndPlayerScoresAreResetToZero()
        {
            // Arrange
            var playerOne = new Player(PlayerNames.PlayerOne);
            var playerTwo = new Player(PlayerNames.PlayerTwo);

            SetPlayerScore(playerOne, 4);
            SetPlayerScore(playerTwo, 1);

            var game = new TennisGame(playerOne, playerTwo);

            // Act
            game.GetCurrentScore();

            //Assert
            Assert.Equal(1, game.GamesWonByPlayerOne);
            Assert.Equal(0, game.GamesWonByPlayerTwo);
            Assert.Equal(0, playerOne.CurrentScore);
            Assert.Equal(0, playerTwo.CurrentScore);
        }

        [Fact, Description(
            @"When a game is won by player two then the count for games won by player two increases by one
            and both player scores are reset to zero")]
        public void When_GameIsWonByPlayerTwo_Then_GamesWonByPlayerTwoIsIncrementedByOneAndPlayerScoresAreResetToZero()
        {
            // Arrange
            var playerOne = new Player(PlayerNames.PlayerOne);
            var playerTwo = new Player(PlayerNames.PlayerTwo);

            SetPlayerScore(playerOne, 1);
            SetPlayerScore(playerTwo, 4);

            var game = new TennisGame(playerOne, playerTwo);

            // Act
            game.GetCurrentScore();

            //Assert
            Assert.Equal(0, game.GamesWonByPlayerOne);
            Assert.Equal(1, game.GamesWonByPlayerTwo);
            Assert.Equal(0, playerOne.CurrentScore);
            Assert.Equal(0, playerTwo.CurrentScore);
        }

        private void SetPlayerScore(IPlayer player, int score)
        {
            player.ResetScore();

            for (int i = 0; i < score; i++)
            {
                player.IncrementScore();
            }
        }

    }
}