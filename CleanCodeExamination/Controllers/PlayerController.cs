using CleanCodeExamination.Data;
using CleanCodeExamination.Entities;
using CleanCodeExamination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Controllers
{
    public class PlayerController
    {
        private IUserInterface _ui;
		private Context _context;
        private PlayerService _player;

        public PlayerController(IUserInterface ui, Context context, PlayerService player)
        {
            _ui = ui;
            _context = context;
            _player = player;
        }

        private Player player;

        //public void StartGame()
        //{
        //    bool playOn = true;
        //    _ui.Output("Enter your name: ", false);
        //    player.Name = _ui.Input();
        //    _player.PlayerExist(player.Name);

        //    PlayGame(playOn);
        //}

        

        private static void SaveToDb(Player name, Player guesses)
        {
            

            //StreamWriter output = new StreamWriter("result.txt", append: true);
            //output.WriteLine(name + "#&#" + nGuess);
            //output.Close();
        }
    }
}
