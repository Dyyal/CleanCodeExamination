namespace CleanCodeExamination.Services
{
    public class GameService
    {
        private IUserInterface _ui;
        private PlayerService _playerService;
        private Player _player;

        public GameService(IUserInterface ui, PlayerService playerService, Player player)
        {
            _ui = ui;
            _playerService = playerService;
            _player = player;
        }

        public GameService()
        {

        }

        public void StartGame()
        {
            _playerService.EnterPlayerName();
            PlayGame(true);
        }

        private void PlayGame(bool playOn)
        {
            while (playOn)
            {
                string target = CreateTargetNumber();


                _ui.Output("New game:");
                //comment out or remove next line to play real games!
                _ui.Output($"For practice, number is: {target}");
                string guess = _ui.Input();

                _player.Score.Guesses = 1;
                string bbcc = CheckBullsAndCows(target, guess);
                Console.WriteLine(bbcc + "\n");

                while (bbcc != "BBBB,")
                {
                    _player.Score.Guesses++;
                    guess = _ui.Input();
                    bbcc = CheckBullsAndCows(target, _ui.Input());
                    _ui.Output(bbcc);
                }

                _playerService.UpdatePlayerData(_player.Name, _player.Score.Guesses);
                
                _playerService.PlayersHighscore();

                _ui.Output($"Correct, it took {_player.Score.Guesses} guesses\nContinue? y/n");
                string answer = _ui.Input();
                if (answer.Substring(0, 1) is "n")
                {
                    playOn = false;
                    _ui.Exit();
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

        public string CheckBullsAndCows(string target, string guess)
        {
            int cows = 0, bulls = 0;

            while (guess.Count() < 4)
            {
                _ui.Output("You've entered less than 4 digits. Try again: ");
                guess = _ui.Input();
            }

            for (int targetIndex = 0; targetIndex < 4; targetIndex++)
            {
                for (int guessIndex = 0; guessIndex < 4; guessIndex++)
                {
                    if (target[targetIndex] == guess[guessIndex])
                    {
                        if (targetIndex == guessIndex)
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
            return $"{"BBBB".Substring(0, bulls)},{"CCCC".Substring(0, cows)}";
        }
    }
}
