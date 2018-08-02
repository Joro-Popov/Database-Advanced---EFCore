namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;
    using System;

    public class ExportLocalSuppliers : ICommand
    {
        private readonly ISupplierService supplierService;

        public ExportLocalSuppliers(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public string Execute()
        {
            this.supplierService.GetLocalSuppliers();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "local-suppliers.xml");
        }
    }
}
