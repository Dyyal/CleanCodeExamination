namespace CleanCodeExamination.Data.Entities;

public class Score
{
    public string ScoreId { get; set; }
    public int RoundsPlayed { get; set; }
    public int Guesses { get; set; }
    public double Average { get; set; }
    public string PlayerId { get; set; }
    public Player Player { get; set; }
}
