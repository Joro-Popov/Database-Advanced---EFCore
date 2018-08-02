namespace ProductShop.Services.Contracts
{
    public interface IUserService
    {
        void GetUsersWithSoldProducts();

        void GetUsersAndProducts();
    }
}