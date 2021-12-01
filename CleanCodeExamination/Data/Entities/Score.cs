namespace CleanCodeExamination.Data.Entities
{
    public class Score
    {
        public Guid Id { get; set; }
        public string Player { get; set; }
        public int RoundsPlayed { get; set; }
        public int Guesses { get; set; }
        public int Highscore { get; set; }
        public double Average { get; set; }

        public Score()
        {
            Average = Guesses / RoundsPlayed;
        }
    }
}
