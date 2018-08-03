namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;

    public class ExportOrderedCustomers : ICommand
    {
        private readonly ICustomerService customerService;

        public ExportOrderedCustomers(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public string Execute()
        {
            this.customerService.GetOrderedCustomers();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "ordered-customers.json");
        }
    }
}