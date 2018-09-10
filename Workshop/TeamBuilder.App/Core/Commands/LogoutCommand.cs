namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;

    public class LogoutCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 0;

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var loggedInUsername = AuthenticationService.GetCurrentUser().Username;

            AuthenticationService.Logout();

            var message = string.Format(SuccessfullMessages.SUCCESSFULL_LOGOUT, loggedInUsername);

            return message;
        }
    }
}