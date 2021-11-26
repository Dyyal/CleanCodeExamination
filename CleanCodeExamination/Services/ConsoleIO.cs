using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Services
{
    public class ConsoleIO : IUserInterface
    {
        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string text, bool newLine = true)
        {
            if (newLine)
                Console.WriteLine(text);
            else
                Console.Write(text);
        }
    }
}
