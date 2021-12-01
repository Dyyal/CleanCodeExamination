namespace CleanCodeExamination.Data.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Score Score { get; set; }
    }
}
