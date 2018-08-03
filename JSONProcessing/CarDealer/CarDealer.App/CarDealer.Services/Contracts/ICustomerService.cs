namespace CarDealer.Services.Contracts
{
    public interface ICustomerService
    {
        void GetTotalSalesByCustomer();

        void GetOrderedCustomers();
    }
}