using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Services
{
    public interface IPlayerInterface
    {
        void EnterPlayerName();

        void CreatePlayer(string playerName);
        void GetPlayer(string playerName);

        void UpdatePlayerScore(string playerName, int guesses);

        void PlayersHighscore();

        double Average(Score score);
    }
}
