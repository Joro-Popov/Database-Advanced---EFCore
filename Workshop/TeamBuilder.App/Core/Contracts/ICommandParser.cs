namespace TeamBuilder.App.Core.Contracts
{
    public interface ICommandParser
    {
        string ParseCommand(string command);
    }
}