namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class DeclineInviteCommand : ICommand
    {
        private readonly IUserService userService;

        public DeclineInviteCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(1, args);
            Check.CheckUserIsLoggedOut();

            var teamName = args[0];
            var user = AuthenticationService.GetCurrentUser();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName, user))
            {
                throw new ArgumentException(string.Format(ErrorMessages.InviteNotFound, teamName));
            }

            this.userService.DeclineInvite(teamName);

            return string.Format(InfoMessages.SuccessfullyDeclinedInvite, teamName);
        }
    }
}