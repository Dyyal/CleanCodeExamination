using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Services
{
    public interface IUserInterface
    {
        public string Input();
        public void Output(string text, bool newLine = true);
        public void Exit();
    }
}
