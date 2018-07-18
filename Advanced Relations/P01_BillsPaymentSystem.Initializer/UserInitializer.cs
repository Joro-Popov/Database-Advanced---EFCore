namespace P01_BillsPaymentSystem.Initializer
{
    using P01_BillsPaymentSystem.Data.Models;
    using System.Collections.Generic;

    public class UserInitializer
    {
        public static List<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User{ FirstName = "Georgi", LastName = "Popov", Email = "georgi@abv.bg", Password = "OnI147"},
                new User{ FirstName = "Pesho", LastName = "Petrov", Email = "Undisputed@gmail.com", Password = "NoPassword"},
                new User{ FirstName = "Stamat", LastName = "Nikolov", Email = "SNikolov@yahoo.com", Password = "A7dFVb001"},
                new User{ FirstName = "Dimitar", LastName = "Starchev", Email = "Starchoka@gmail.com", Password = "9011Dm"},
                new User{ FirstName = "Lora", LastName = "Dimitrova", Email = "Lori77@abv.bg", Password = "C#Guru123"}
            };

            return users;
        }
    }
}