using CleanCodeExamination.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Entities
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public Score Score { get; set; }
    }
}
