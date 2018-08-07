namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return "Goodbye!";
        }
    }
}