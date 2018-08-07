namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(0, args);
            Check.CheckUserIsLoggedOut();

            var username = AuthenticationService.GetCurrentUser().Username;

            this.userService.DeleteUser(username);

            AuthenticationService.Logout();

            return string.Format(InfoMessages.SuccessfullDelete, username);
        }
    }
}