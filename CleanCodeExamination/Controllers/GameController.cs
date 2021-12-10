namespace CleanCodeExamination.Controllers
{
    public class GameController
    {
        private readonly IGameInterface _game;

        public GameController(IGameInterface game)
        {
            _game = game;
        }

        public void RunGame()
        {
            _game.StartGame();
        }
    }
}
