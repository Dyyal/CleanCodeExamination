using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Data.Entities
{
    public class PlayerFactory
    {
        public static Player CreatePlayer(string playerName)
        {
            return new Player()
            {
                Id = Guid.NewGuid().ToString(),
                Name = playerName
            };
        }
    }
}
