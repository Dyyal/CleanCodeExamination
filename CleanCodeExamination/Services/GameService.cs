namespace CleanCodeExamination.Services
{
    public class GameService : IGameInterface
    {
        private IUserInterface _ui;
        private IPlayerInterface _IPlayer;
        int guesses;
        public static string target;
        public GameService(IUserInterface ui, IPlayerInterface IPlayer)
        {
            _ui = ui;
            _IPlayer = IPlayer;
        }

        public void StartGame()
        {
            _IPlayer.EnterPlayerName();
            PlayGame(true);
        }

        public void PlayGame(bool playOn)
        {
            if(playOn)
            {
                target = CreateTargetNumber();

                _ui.Output("New game:");
                //comment out or remove next line to play real games!
                _ui.Output($"For practice, number is: {target}");

                MakeGuess(target);

                string playerName = _IPlayer.GetPlayer();

                _IPlayer.UpdatePlayerScore(playerName, guesses);

                _IPlayer.PlayersHighscore();

                _ui.Output($"Correct, it took {guesses} guesses\nContinue? y/n");
                EndOrRestartGame(_ui.Input());
            }
        }

        public void MakeGuess(string target)
        {
            guesses = 1;
            string bullsAndCows = CheckBullsAndCows(target, _ui.Input());
            _ui.Output(bullsAndCows);

            while (bullsAndCows is not "BBBB,")
            {
                guesses++;
                bullsAndCows = CheckBullsAndCows(target, _ui.Input());
                _ui.Output(bullsAndCows);
            }
        }

        public void EndOrRestartGame(string answer)
        {
            try
            {
                Dictionary<string, Action> commands = new()
                {
                    { "n", () => PlayGame(false) },
                    { "y", () => PlayGame(true) },
                    { String.Empty, () => { _ui.Output("You've entered an empty string. Try again"); EndOrRestartGame(_ui.Input()); } }
                };

                commands[answer].Invoke();
            }
            catch (KeyNotFoundException ex)
            {
                _ui.Output($"{ex.Message} Try again");
                EndOrRestartGame(_ui.Input());
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

            while (guess.Count() is not 4)
            {
                _ui.Output("You've entered less or more than 4 digits. Try again: ");
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
