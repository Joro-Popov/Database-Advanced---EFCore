namespace CarDealer.App.Core.Contracts
{
    public interface ICommandParser
    {
        string ParseCommand(string input);
    }
}
