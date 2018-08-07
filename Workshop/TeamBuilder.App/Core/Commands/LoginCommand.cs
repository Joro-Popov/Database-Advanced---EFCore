namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;

    public class LoginCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Check.CheckLenght(2, args);

            var username = args[0];
            var password = args[1];

            //Check username and password
            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(ErrorMessages.UserOrPasswordIsInvalid);
            }
            else if (!CommandHelper.ArePasswordsEqual(username, password))
            {
                throw new ArgumentException(ErrorMessages.UserOrPasswordIsInvalid);
            }
            else if (CommandHelper.IsUserDeleted(username))
            {
                throw new ArgumentException(ErrorMessages.UserOrPasswordIsInvalid);
            }

            Check.CheckUserIsLoggedIn();

            AuthenticationService.Login(username, password);

            return string.Format(InfoMessages.SuccessfullLogin, username);
        }
    }
}