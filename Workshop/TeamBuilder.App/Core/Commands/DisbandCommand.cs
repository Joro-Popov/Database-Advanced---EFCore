namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class DisbandCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 1;

        private readonly IUserService userService;

        public DisbandCommand(IUserService userService)
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

            if (!DatabaseChecker.IsUserCreatorOfTeam(teamName, loggedInUser))
            {
                throw new InvalidOperationException(ErrorMessages.OPERATION_NOT_ALLOWED);
            }

            this.userService.Disband(teamName);

            var message = string.Format(SuccessfullMessages.SUCCESSFULL_DISBAND, teamName);

            return message;
        }
    }
}