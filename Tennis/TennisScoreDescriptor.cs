using Tennis.Enums;
using Tennis.Extensions;

namespace Tennis
{
    public static class TennisScoreDescriptor
    {
        public static string CurrentScore(int playerOneScore, int playerTwoScore)
        {
            if (playerOneScore == playerTwoScore)
            {
                return DetermineDrawDescription(playerOneScore);
            }

            if (playerOneScore > 3 || playerTwoScore > 3)
            {
                var scoreDifference = playerOneScore - playerTwoScore;
                return DetermineWinnerOrAdvantageDescription(scoreDifference);
            }

            return DetermineCurrentScoreDescription(playerOneScore, playerTwoScore);
        }

        private static string DetermineDrawDescription(int score) 
            => score > 3 
            ? DrawDescriptors.Deuce.GetDescription() 
            : ((DrawDescriptors)score).GetDescription();

        private static string DetermineWinnerOrAdvantageDescription(int scoreDifference)
            => scoreDifference switch
                {
                    -1 => AdvantageScoreDescriptors.PlayerTwoAdvantage.GetDescription(),
                    1 => AdvantageScoreDescriptors.PlayerOneAdvantage.GetDescription(),
                    >= 2 => WinningScoreDescriptors.PlayerOneHasWon.GetDescription(),
                    _ => WinningScoreDescriptors.PlayerTwoHasWon.GetDescription(),
                };

        private static string DetermineCurrentScoreDescription(int playerOneScore, int playerTwoScore)
        {
            var playerOneScoreDescription = ((ScoreDescriptors)playerOneScore).GetDescription();
            var playerTwoScoreDescription = ((ScoreDescriptors)playerTwoScore).GetDescription();

            return $"{playerOneScoreDescription}-{playerTwoScoreDescription}";
        }

    }
}
