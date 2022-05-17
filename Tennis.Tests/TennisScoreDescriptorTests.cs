using System.ComponentModel;
using Xunit;

namespace Tennis.Tests
{
    public class TennisScoreDescriptorTests
    {
        [Theory, Description("The correct score description should be returned for a variety of different scores")]
        [ClassData(typeof(TestDataGenerator))]
        public void When_WeGetCurrentScore_Then_TheCorrectScoreDescriptionMustBeReturned(
            int playerOneScore,
            int playerTwoScore,
            string expectedScoreDescription)
        {
            // Act
            var actualScoreDescription = TennisScoreDescriptor.CurrentScore(playerOneScore, playerTwoScore);

            // Assert
            Assert.Equal(expectedScoreDescription, actualScoreDescription);
        }

    }
}
