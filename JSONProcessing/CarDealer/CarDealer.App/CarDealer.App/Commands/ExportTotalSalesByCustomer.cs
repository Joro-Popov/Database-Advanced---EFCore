namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;

    public class ExportTotalSalesByCustomer : ICommand
    {
        private readonly ICustomerService customerService;

        public ExportTotalSalesByCustomer(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public string Execute()
        {
            this.customerService.GetTotalSalesByCustomer();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "customers-total-sales.json");
        }
    }
}