namespace CleanCodeExamination.Data.Entities
{
    public class ScoreFactory
    {
        public static Score CreateScore(Player player, int guesses)
        {
            return new Score()
            {
                ScoreId = Guid.NewGuid().ToString(),
                Guesses = guesses,
                RoundsPlayed = 1,
                PlayerId = player.Id,
            };
        }
        public static Score UpdateScore(int guesses, Score score)
        {
            score.RoundsPlayed++;
            score.Guesses += guesses;
            score.Average = Average(score);
            return score;
        }

        public static double Average(Score score) => Math.Round((double)score.Guesses / score.RoundsPlayed, 2);
    }
}
