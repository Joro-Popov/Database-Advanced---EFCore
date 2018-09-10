namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class DeclineInviteCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 1;

        private readonly IUserService userService;

        public DeclineInviteCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var teamName = args[0];
            var loggedInUser = AuthenticationService.GetCurrentUser();

            if (!DatabaseChecker.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TEAM_NOT_FOUND, teamName));
            }

            if (!DatabaseChecker.IsInviteExisting(teamName, loggedInUser))
            {
                throw new ArgumentException(string.Format(ErrorMessages.INVITE_NOT_FOUND, teamName));
            }

            this.userService.DeclineInvite(teamName);

            var message = string.Format(SuccessfullMessages.SUCCESSFULLY_DECLINED_INVITE, teamName);

            return message;
        }
    }
}