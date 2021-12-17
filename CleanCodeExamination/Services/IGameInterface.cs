namespace CleanCodeExamination.Services;

public interface IGameInterface
{
    void StartGame();

    void PlayGame(bool playOn);
    void MakeGuess(string target);
    void EndOrRestartGame(string answer);
    string CreateTargetNumber();
    string CheckBullsAndCows(string target, string guess);
}
