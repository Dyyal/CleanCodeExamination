using CleanCodeExamination.Data.Entities;
using CleanCodeExamination.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Data
{
    public class Context : DbContext
    {
        public string? DataSource { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DataSource}");


        public Context()
        {
            var folder = Environment.SpecialFolder.Desktop;
            var path = Environment.GetFolderPath(folder);
            DataSource = $"{path}{Path.DirectorySeparatorChar}MooGame.db";
        }
    }
}
