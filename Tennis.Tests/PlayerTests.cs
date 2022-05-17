using System.ComponentModel;
using Tennis.Enums;
using Xunit;

namespace Tennis.Tests
{
    public class PlayerTests
    {
        [Fact, Description("When the players score is incremented then the score is only incremeted by one")]
        public void When_PlayerScoreIsIncremented_Then_TheScoreIsOnlyIncrementedByOne()
        {
            // Arrange
            var player = new Player(PlayerNames.PlayerOne);

            // Act
            player.IncrementScore();

            //Assert
            Assert.Equal(1, player.CurrentScore);
        }

    }
}
