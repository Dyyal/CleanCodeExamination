namespace CleanCodeExamination.Services
{
    public class PlayerService : IPlayerInterface
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

        public void GetPlayer(string playerName)
        {
            if (!_context.Players.Any(x => x.Name == playerName))
            {
                CreatePlayer(playerName);
            }

            _context.Players.Find(playerName);
        }

        public void CreatePlayer(string playerName)
        {
            Player player = PlayerFactory.CreatePlayer(playerName);
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void UpdatePlayerScore(string playerName, int guesses)
        {
            Player player = _context.Players.Where(p => p.Name == playerName).FirstOrDefault();

            if (!_context.Scores.Any(x => x.PlayerId == player.Id))
            {
                CreateScore(guesses, player);
            }
            else
            {
                UpdateScore(guesses, player);
            }
            _context.SaveChanges();
        }

        private void CreateScore(int guesses, Player player)
        {
            Score score = ScoreFactory.CreateScore(player, guesses);
            score.Average = Average(score);
            _context.Scores.Add(score);
        }

        private void UpdateScore(int guesses, Player player)
        {
            Score score = _context.Scores.FirstOrDefault(x => x.PlayerId == player.Id);
            score.RoundsPlayed++;
            score.Guesses += guesses;
            score.Average = Average(score);
            _context.Scores.Update(score);
        }

        public void PlayersHighscore()
        {
            var highscore = _context.Scores.Include(x => x.Player).OrderBy(x => x.Average);

            _ui.Output("Player   games   average");
            foreach (Score p in highscore)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Player.Name, p.RoundsPlayed, p.Average));
            }
        }

        public double Average(Score score) => Math.Round((double)score.Guesses / score.RoundsPlayed, 2);

    }
}
