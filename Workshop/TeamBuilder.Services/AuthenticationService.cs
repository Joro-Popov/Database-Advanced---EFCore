namespace TeamBuilder.Services
{
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public static class AuthenticationService
    {
        private static User user = null;
        private static readonly TeamBuilderDbContext context = new TeamBuilderDbContext();

        public static User GetCurrentUser()
        {
            return user;
        }

        public static bool IsAuthenticated()
        {
            return user != null;
        }

        public static void Login(string username, string password)
        {
            user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static void Logout()
        {
            user = null;
        }
    }
}