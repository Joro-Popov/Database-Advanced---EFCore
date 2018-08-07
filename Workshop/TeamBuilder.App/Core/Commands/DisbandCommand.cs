namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class DisbandCommand : ICommand
    {
        private readonly IUserService userService;

        public DisbandCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(1, args);
            Check.CheckUserIsLoggedOut();

            var teamName = args[0];
            var loggedInUser = AuthenticationService.GetCurrentUser();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, loggedInUser))
            {
                throw new InvalidOperationException(ErrorMessages.NotAllowed);
            }

            this.userService.Disband(teamName);

            return string.Format(InfoMessages.SuccessfullDisband, teamName);
        }
    }
}