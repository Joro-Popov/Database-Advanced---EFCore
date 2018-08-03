namespace ProductShop.App.Commands
{
    using ProductShop.App.Commands.Contracts;
    using ProductShop.Services.Contracts;

    public class ExportUsersAndProducts : ICommand
    {
        private readonly IUserService userService;

        public ExportUsersAndProducts(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute()
        {
            this.userService.GetUsersAndProducts();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "users-and-products.json");
        }
    }
}