namespace CleanCodeExamination.Services
{
    public class PlayerService : IPlayerInterface
    {
        private Context _context;
        private IUserInterface _ui;

        Player player = PlayerFactory.CreatePlayer();

        public PlayerService(Context context, IUserInterface ui)
        {
            _context = context;
            _ui = ui;
        }

        public void EnterPlayerName()
        {
            _ui.Output("Enter your name: ", false);
            player.Name = _ui.Input();
            GetPlayer();
        }

        public string GetPlayer()
        {
            if (!_context.Players.Any(x => x.Name == player.Name))
            {
                CreatePlayer(player.Name);
            }

            return player.Name;
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
                CreateScore(player, guesses);
            }
            else
            {
                UpdateScore(player, guesses);
            }
            _context.SaveChanges();
        }

        private void CreateScore(Player player, int guesses)
        {
            Score score = ScoreFactory.CreateScore(player, guesses);
            score.Average = ScoreFactory.Average(score);
            _context.Scores.Add(score);
        }

        private void UpdateScore(Player player, int guesses)
        {
            Score score = _context.Scores.FirstOrDefault(x => x.PlayerId == player.Id);
            ScoreFactory.UpdateScore(guesses, score);
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
    }
}
