namespace ProductShop.App.Commands
{
    using ProductShop.App.Commands.Contracts;

    public class Exit : ICommand
    {
        public string Execute()
        {
            return "Goodby";
        }
    }
}