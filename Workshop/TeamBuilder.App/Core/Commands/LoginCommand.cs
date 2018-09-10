namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;

    public class LoginCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 2;

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);

            var username = args[0];
            var password = args[1];

            if (!DatabaseChecker.IsUserExisting(username) || !DatabaseChecker.ArePasswordsEqual(username, password))
            {
                throw new ArgumentException(ErrorMessages.INVALID_USERNAME_OR_PASSWORD);
            }

            if (DatabaseChecker.IsUserDeleted(username))
            {
                throw new ArgumentException(ErrorMessages.INVALID_USERNAME_OR_PASSWORD);
            }

            Checker.CheckUserIsLoggedIn();

            AuthenticationService.Login(username, password);

            var message = string.Format(SuccessfullMessages.SUCCESSFULL_LOGIN, username);

            return message;
        }
    }
}