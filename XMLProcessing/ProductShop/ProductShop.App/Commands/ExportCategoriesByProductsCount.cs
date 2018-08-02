namespace ProductShop.App.Commands
{
    using ProductShop.App.Commands.Contracts;
    using ProductShop.Services.Contracts;

    public class ExportCategoriesByProductsCount : ICommand
    {
        private readonly ICategoryService categoryService;

        public ExportCategoriesByProductsCount(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public string Execute()
        {
            this.categoryService.GetCategories();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "categories-by-products.xml");
        }
    }
}