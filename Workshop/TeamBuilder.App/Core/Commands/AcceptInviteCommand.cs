namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class AcceptInviteCommand : ICommand
    {
        private readonly IUserService userService;

        public AcceptInviteCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(1, args);
            Check.CheckUserIsLoggedOut();

            var teamName = args[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName, AuthenticationService.GetCurrentUser()))
            {
                throw new ArgumentException(string.Format(ErrorMessages.InviteNotFound, teamName));
            }

            this.userService.AcceptInvitation(teamName);

            return string.Format(InfoMessages.SuccessfullyAcceptInvitation, AuthenticationService.GetCurrentUser().Username, teamName);
        }
    }
}