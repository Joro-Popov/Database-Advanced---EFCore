namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class AddTeamToCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 2;

        private readonly IUserService userService;

        public AddTeamToCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var eventName = args[0];
            var teamName = args[1];
            var loggedInUser = AuthenticationService.GetCurrentUser();

            if (!DatabaseChecker.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.EVENT_NOT_FOUND, eventName));
            }

            if (!DatabaseChecker.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TEAM_NOT_FOUND, teamName));
            }

            if (!DatabaseChecker.IsUserCreatorOfTeam(teamName, loggedInUser))
            {
                throw new InvalidOperationException(ErrorMessages.OPERATION_NOT_ALLOWED);
            }

            if (DatabaseChecker.IsTeamPartOfEvent(eventName, teamName))
            {
                throw new InvalidOperationException(ErrorMessages.CANNOT_ADD_SAME_TEAM_TWICE);
            }

            this.userService.AddTeamToEvent(eventName, teamName);

            var message = string.Format(SuccessfullMessages.SUCCESSFULLY_ADDED_TEAM_TO_EVENT, teamName, eventName);

            return message;
        }
    }
}