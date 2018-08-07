namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;

    public class LogoutCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Check.CheckLenght(0, args);
            Check.CheckUserIsLoggedOut();

            var username = AuthenticationService.GetCurrentUser().Username;

            AuthenticationService.Logout();

            return string.Format(InfoMessages.SuccessfullLogout, username);
        }
    }
}