namespace CleanCodeExamination.Services
{
    public interface IUserInterface
    {
        public string Input();
        public void Output(string text, bool newLine = true);
        public void Exit();
    }
}
