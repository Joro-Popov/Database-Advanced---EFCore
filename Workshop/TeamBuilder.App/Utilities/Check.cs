namespace TeamBuilder.App.Utilities
{
    using System;
    using System.Globalization;
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models.Enums;
    using TeamBuilder.Services;

    public static class Check
    {
        public static Gender CheckGender(string genderAsString)
        {
            var isValidEnum = Enum.TryParse(genderAsString, out Gender gender);

            if (!isValidEnum)
            {
                throw new ArgumentException(ErrorMessages.GenderNotValid);
            }

            return gender;
        }

        public static int CheckAge(string age)
        {
            if (!age.All(c => char.IsDigit(c)) || int.Parse(age) <= 0)
            {
                throw new ArgumentException(ErrorMessages.AgeNotValid);
            }

            return int.Parse(age);
        }

        public static void CheckUserIsLoggedIn()
        {
            if (AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException(ErrorMessages.LogoutFirst);
            }
        }

        public static void CheckUserIsLoggedOut()
        {
            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException(ErrorMessages.LoginFirst);
            }
        }

        public static void CheckLenght(int expectedlength, string[] array)
        {
            using (var context = new TeamBuilderDbContext())
            {
                if (expectedlength != array.Length)
                {
                    throw new FormatException(ErrorMessages.InvalidArgumentsCount);
                }
            }
        }

        public static DateTime CheckDateIsValid(string date)
        {
            var validFormat = "dd/MM/yyyy HH:mm";

            var dateIsValid = DateTime.TryParseExact(date, validFormat, null, DateTimeStyles.None, out DateTime parsedDate);

            if (!dateIsValid)
            {
                throw new ArgumentException(ErrorMessages.InvalidDateFormat);
            }

            return parsedDate;
        }

        public static void CheckStartDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(ErrorMessages.InvalidStartDate);
            }
        }

        public static void CheckAcronymIsExisting(string acronym)
        {
            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidAcronym, acronym));
            }
        }
    }
}