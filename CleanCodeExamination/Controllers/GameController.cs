namespace CleanCodeExamination.Controllers
{
    public class GameController
    {
        private readonly GameService _game;

        public GameController(GameService game)
        {
            _game = game;
        }

        public void RunGame()
        {
            _game.StartGame();
        }
    }
}
