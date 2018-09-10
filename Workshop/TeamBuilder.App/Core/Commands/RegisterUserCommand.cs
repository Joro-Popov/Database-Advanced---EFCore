namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 7;

        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);

            var username = args[0];
            var password = args[1];
            var repeatPassword = args[2];
            var firstName = args[3];
            var lastName = args[4];
            var age = Checker.CheckAgeIsValid(args[5]);
            var gender = Checker.CheckGenderIsValid(args[6]);

            CheckForInvalidUsername(username);
            CheckForInvalidPassword(password, repeatPassword);
            Checker.CheckUserIsLoggedIn();

            this.userService.RegisterUser(username, password, firstName, lastName, age, gender);

            var message = string.Format(SuccessfullMessages.SUCCESSFULL_REGISTRATION, username);

            return message;
        }

        private static void CheckForInvalidUsername(string username)
        {
            var usernameLengthIsInvalid = username.Length < Constraints.USERNAME_MIN_LENGTH || username.Length > Constraints.USERNAME_MAX_LENGTH;

            if (usernameLengthIsInvalid)
            {
                throw new ArgumentException(string.Format(ErrorMessages.USERNAME_NOT_VALID, username));
            }

            if (DatabaseChecker.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.USERNAME_IS_TAKEN, username));
            }
        }

        private static void CheckForInvalidPassword(string password, string repeatPassword)
        {
            var passwordContentIsInvalid = !(password.Any(p => char.IsDigit(p)) && password.Any(p => char.IsUpper(p)));
            var passwordLengthIsInvalid = password.Length < Constraints.PASSWORD_MIN_LENGTH || password.Length > Constraints.PASSWORD_MAX_LENGTH;

            if (passwordLengthIsInvalid)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PASSWORD_NOT_VALID, password));
            }
            else if (passwordContentIsInvalid)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PASSWORD_NOT_VALID, password));
            }
            else if (password != repeatPassword)
            {
                throw new InvalidOperationException(ErrorMessages.PASSWORD_MISMATCH);
            }
        }
    }
}