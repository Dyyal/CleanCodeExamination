using System;
namespace CleanCodeExamination.Data.Entities
{
    public class ScoreFactory
    {
        private readonly Context _context;

        public ScoreFactory(Context context)
        {
            _context = context;
        }

        public static Score CreateScore(Player player, int guesses)
        {
            return new Score()
            {
                ScoreId = Guid.NewGuid().ToString(),
                Guesses = guesses,
                RoundsPlayed = 1,
                PlayerId = player.Id
            };
        }

        //public static void UpdateScore(Score score, Player player)
        //{
        //    score = _context.Scores.FirstOrDefault(x => x.PlayerId == player.Id);
        //    score.RoundsPlayed++;
        //    score.Guesses += guesses;
        //    score.Average = Math.Round(Average(score), 2);
        //}
    }
}
