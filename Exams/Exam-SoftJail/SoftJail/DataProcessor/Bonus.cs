namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Linq;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var current = context.Prisoners
                .FirstOrDefault(p => p.Id == prisonerId);

            if (current.ReleaseDate == null)
            {
                return $"Prisoner {current.FullName} is sentenced to life";
            }
            current.ReleaseDate = DateTime.Now;
            current.CellId = null;

            return $"Prisoner {current.FullName} released";
        }
    }
}
