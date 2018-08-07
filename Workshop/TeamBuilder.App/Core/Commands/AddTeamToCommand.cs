namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class AddTeamToCommand : ICommand
    {
        private readonly IUserService userService;

        public AddTeamToCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(2, args);
            Check.CheckUserIsLoggedOut();

            var eventName = args[0];
            var teamName = args[1];
            var user = AuthenticationService.GetCurrentUser();

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.EventNotFound, eventName));
            }

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, user))
            {
                throw new InvalidOperationException(ErrorMessages.NotAllowed);
            }

            if (CommandHelper.IsTeamPartOfEvent(eventName, teamName))
            {
                throw new InvalidOperationException(ErrorMessages.CannotAddSameTeamTwice);
            }

            this.userService.AddTeamToEvent(eventName, teamName);

            return string.Format(InfoMessages.SuccessfullyAddedTeamToEvent, teamName, eventName);
        }
    }
}