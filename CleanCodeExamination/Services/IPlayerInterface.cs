namespace CleanCodeExamination.Services
{
    public interface IPlayerInterface
    {
        void EnterPlayerName();

        void CreatePlayer(string playerName);
        string GetPlayer();
        void UpdatePlayerScore(string playerName, int guesses);

        void PlayersHighscore();
    }
}
