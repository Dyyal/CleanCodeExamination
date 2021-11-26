using CleanCodeExamination.Data;
using CleanCodeExamination.Entities;
using CleanCodeExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void StartGame(bool startGame)
        {
            if (startGame)
            {
                _playerService.EnterPlayerName();
                PlayGame(true);
            }
            else
            {
                _ui.Exit();
            }
        }

        private void PlayGame(bool playOn)
        {
            while (playOn)
            {
                string goal = CreateGoal();


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
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public string CreateGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }
            return goal;
        }

        static string checkBC(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
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

        static void PlayersHighscore()
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

            List<Player> results = new();

            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }
    }
}
