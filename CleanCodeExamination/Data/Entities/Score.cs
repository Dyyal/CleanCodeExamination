using CleanCodeExamination.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Data.Entities
{
    public class Score
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RoundsPlayed { get; set; }
        public int Guesses { get; set; }
        public int Highscore { get; set; }
    }
}
