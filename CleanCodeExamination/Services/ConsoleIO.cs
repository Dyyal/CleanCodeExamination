namespace CleanCodeExamination.Services;

public class ConsoleIO : IUserInterface
{

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
