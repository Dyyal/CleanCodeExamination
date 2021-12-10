namespace CleanCodeExamination.Data.Entities
{
    public class PlayerFactory
    {
        public static Player CreatePlayer(string playerName)
        {
            return new Player()
            {
                Id = Guid.NewGuid().ToString(),
                Name = playerName
            };
        }

        public static Player CreatePlayer()
        {
            return new Player();
        }
    }
}
