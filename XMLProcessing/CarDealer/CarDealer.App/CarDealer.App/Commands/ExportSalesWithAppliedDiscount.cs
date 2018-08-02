namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;
    using System;

    public class ExportSalesWithAppliedDiscount : ICommand
    {
        private readonly ISaleService saleService;

        public ExportSalesWithAppliedDiscount(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        public string Execute()
        {
            this.saleService.GetSalesWithDiscount();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "sale-discounts.xml");
        }
    }
}
