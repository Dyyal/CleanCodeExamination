using CleanCodeExamination.Data;
using CleanCodeExamination.Entities;

namespace CleanCodeExamination.Services
{
    public class GameService
    {
        private Context _context;
        private IUserInterface _ui;
        private PlayerService _playerService;
        private Player _player;

        public GameService(Context context, IUserInterface ui, PlayerService playerService, Player player)
        {
            _context = context;
            _ui = ui;
            _playerService = playerService;
            _player = player;
        }

        public void StartGame()
        {
            //if (startGame)
            //{
            //    _playerService.EnterPlayerName();
            //    PlayGame(true);
            //}
            //else
            //{
            //    _ui.Exit();
            //}

            _playerService.EnterPlayerName();
            PlayGame(true);
        }

        private void PlayGame(bool playOn)
        {
            while (playOn)
            {
                string goal = CreateTargetNumber();


                _ui.Output("New game:");
                //comment out or remove next line to play real games!
                _ui.Output($"For practice, number is: {goal}");
                string guess = _ui.Input();

                //int nGuess = 1;

                int guesses = 1;
                string bbcc = checkBC(goal, guess);
                Console.WriteLine(bbcc + "\n");

                while (bbcc != "BBBB,")
                {
                    guesses++;
                    //guess = Console.ReadLine();
                    _ui.Output(guess);
                    bbcc = checkBC(goal, _ui.Input());
                    _ui.Output(bbcc);
                }

                //SaveToDb(player.Name, player.Guesses);
                return;

                PlayersHighscore();

                Console.WriteLine("Correct, it took " + guesses + " guesses\nContinue?");
                string answer = _ui.Input();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public string CreateTargetNumber()
        {
            string targetNum = String.Empty;

            for (int i = 0; i < 4; i++)
            {
                var randomNum = Random.Shared.Next(10).ToString();

                while (targetNum.Contains(randomNum))
                {
                    randomNum = Random.Shared.Next(10).ToString();
                }
                targetNum = targetNum + randomNum;
            }

            return targetNum;
        }

        public string checkBC(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars

            //if (guess.Count() < 4)
            //{
            //    Console.WriteLine("You've entered less than 4 digits. Try again");
            //    PlayGame(true);
            //}

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
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

            _ui.Output("Player   games average");
            foreach (Player p in result)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.Score.RoundsPlayed, p.Score.Average));
            }
        }

    }
}
