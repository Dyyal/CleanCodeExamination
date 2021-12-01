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

        public void PlayersHighscore()
        {
            //StreamReader input = new StreamReader("result.txt");
            //List<PlayerData> results = new List<PlayerData>();
            //string line;
            //while ((line = input.ReadLine()) != null)
            //{
            //    string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            //    string name = nameAndScore[0];
            //    int guesses = Convert.ToInt32(nameAndScore[1]);
            //    PlayerData pd = new PlayerData(name, guesses);
            //    int pos = results.IndexOf(pd);
            //    if (pos < 0)
            //    {
            //        results.Add(pd);
            //    }
            //    else
            //    {
            //        results[pos].Update(guesses);
            //    }


            //}

            //List<Player> results = new();

            //results.Sort((p1, p2) => p1.Score.Average.CompareTo(p2.Score.Average));

            var result = _context.Players.GroupBy(x => x.Name)
                .Select(x => x.OrderByDescending(x => x.Score.Average).First())
                .OrderByDescending(x => x.Score)
                .ThenBy(x => x.Name);

            //var result = _context.Scores.GroupBy(x => x.Player)
            //    .Select(g => new
            //    {
            //        Player = g.Key,
            //        Score = g.Max(p => p.Average)
            //    })
            //    .OrderByDescending(x => x.Score);

            _ui.Output("Player   games average");
            foreach (Player p in result)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.Score.RoundsPlayed, p.Score.Average));
            }
        }

    }
}
