namespace ProductShop.App.Core.Contracts
{
    public interface ICommandParser
    {
        string ParseCommand(string input);
    }
}