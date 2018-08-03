namespace ProductShop.App.Commands
{
    using ProductShop.App.Commands.Contracts;
    using ProductShop.Services.Contracts;

    public class ExportProductsInRange : ICommand
    {
        private readonly IProductService productService;

        public ExportProductsInRange(IProductService productService)
        {
            this.productService = productService;
        }

        public string Execute()
        {
            this.productService.GetProductsInRange();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "products-in-range.json");
        }
    }
}