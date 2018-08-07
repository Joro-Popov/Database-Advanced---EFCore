namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(7, args);

            var username = args[0];
            var password = args[1];
            var repeatPassword = args[2];
            var firstName = args[3];
            var lastName = args[4];
            var age = Check.CheckAge(args[5]);
            var gender = Check.CheckGender(args[6]);

            //Username check
            if (username.Length < Constraints.MinUsernameLength || username.Length > Constraints.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(ErrorMessages.UsernameNotValid, username));
            }

            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.UsernameIsTaken, username));
            }

            //Password check
            if (password.Length < Constraints.MinPasswordLength || password.Length > Constraints.MaxPasswordLength)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PasswordNotValid, password));
            }
            else if (!(password.Any(p => char.IsDigit(p)) && password.Any(p => char.IsUpper(p))))
            {
                throw new ArgumentException(string.Format(ErrorMessages.PasswordNotValid, password));
            }
            else if (password != repeatPassword)
            {
                throw new InvalidOperationException(ErrorMessages.PasswordDoesNotMatch);
            }

            Check.CheckUserIsLoggedIn();

            this.userService.RegisterUser(username, password, firstName, lastName, age, gender);

            return string.Format(InfoMessages.SuccessfullUserRegistration, username);
        }
    }
}