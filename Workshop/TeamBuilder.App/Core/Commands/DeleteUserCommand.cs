namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class DeleteUserCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 0;

        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var loggedInUsername = AuthenticationService.GetCurrentUser().Username;

            this.userService.DeleteUser(loggedInUsername);

            AuthenticationService.Logout();

            var message = string.Format(SuccessfullMessages.SUCCESSFULL_DELETE, loggedInUsername);

            return message;
        }
    }
}