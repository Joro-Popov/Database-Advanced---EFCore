namespace P15_RemoveTowns
{
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var townName = Console.ReadLine();

            using (var context = new SoftUniContext())
            {
                var townToDelete = context.Towns.Include(t => t.Addresses)
                    .FirstOrDefault(t => t.Name == townName);

                var deletedAddressesCount = townToDelete.Addresses.Count();
                
                context.Addresses.RemoveRange(townToDelete.Addresses);
                context.Towns.Remove(townToDelete);

                if (deletedAddressesCount > 1)
                {
                    Console.WriteLine($"{deletedAddressesCount} addresses in {townToDelete.Name} were deleted");
                }
                else
                {
                    Console.WriteLine($"{deletedAddressesCount} address in {townToDelete.Name} was deleted");
                }
            }
        }
    }
}
