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

                _player.Score.Guesses = 1;
                string bbcc = checkBC(goal, guess);
                Console.WriteLine(bbcc + "\n");
                while (bbcc != "BBBB,")
                {
                    _player.Score.Guesses++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    bbcc = checkBC(goal, _ui.Input());
                    Console.WriteLine(bbcc + "\n");
                }

                //SaveToDb(player.Name, player.Guesses);
                return;

                showTopList();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
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
    }
}
