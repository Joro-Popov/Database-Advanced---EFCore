namespace ProductShop.App.Commands
{
    using ProductShop.App.Commands.Contracts;
    using ProductShop.Services.Contracts;

    public class ExportSoldProducts : ICommand
    {
        private readonly IUserService userService;

        public ExportSoldProducts(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute()
        {
            this.userService.GetUsersWithSoldProducts();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "users-sold-products.json");
        }
    }
}