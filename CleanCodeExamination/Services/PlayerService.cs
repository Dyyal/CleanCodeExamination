using CleanCodeExamination.Data;
using CleanCodeExamination.Entities;

namespace CleanCodeExamination.Services
{
    public class PlayerService
    {
        private Context _context;
        private IUserInterface _ui;
        private Player _player;

        public PlayerService(Context context, IUserInterface ui, Player player)
        {
            _context = context;
            _ui = ui;
            _player = player;
        }

        public void EnterPlayerName()
        {
            _ui.Output("Enter your name: ", false);
            _player.Name = _ui.Input();
            GetPlayer(_player.Name);
        }

        public void AddPlayer(string playerName)
        {
            Player player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = playerName
            };
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void GetPlayer(string playerName)
        {
            if (!_context.Players.Any(x => x.Name == playerName))
            {
                AddPlayer(playerName);
            }

            _context.Players.Find(playerName);
        }

        public void UpdatePlayerData(string playerName, int guesses)
        {
            Player player = _context.Players.Find(playerName);
            player.Score.Guesses = guesses;
            _context.SaveChanges();
        }

    }
}
