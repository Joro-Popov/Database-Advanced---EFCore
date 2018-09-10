namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class KickMemberCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 2;

        private readonly IUserService userService;

        public KickMemberCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var loggedInUser = AuthenticationService.GetCurrentUser();
            var teamName = args[0];
            var usernameToKick = args[1];

            if (!DatabaseChecker.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TEAM_NOT_FOUND, teamName));
            }

            if (!DatabaseChecker.IsUserExisting(usernameToKick))
            {
                throw new ArgumentException(string.Format(ErrorMessages.USER_NOT_FOUND, usernameToKick));
            }

            if (!DatabaseChecker.IsMemberOfTeam(teamName, loggedInUser.Username))
            {
                throw new ArgumentException(string.Format(ErrorMessages.NOT_PART_OF_TEAM, loggedInUser.Username, teamName));
            }

            if (!DatabaseChecker.IsMemberOfTeam(teamName, usernameToKick))
            {
                throw new ArgumentException(string.Format(ErrorMessages.NOT_PART_OF_TEAM, usernameToKick, teamName));
            }

            if (!DatabaseChecker.IsUserCreatorOfTeam(teamName, loggedInUser))
            {
                throw new InvalidOperationException(ErrorMessages.OPERATION_NOT_ALLOWED);
            }

            User userToKick = null;

            using (var context = new TeamBuilderDbContext())
            {
                userToKick = context.Users.FirstOrDefault(u => u.Username == usernameToKick);
            }

            if (DatabaseChecker.IsUserCreatorOfTeam(teamName, userToKick))
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.COMMAND_NOT_ALLOWED, "DisbandTeam"));
            }

            this.userService.KickMember(teamName, usernameToKick);

            var message = string.Format(SuccessfullMessages.SUCCESSFULLY_KICKED_USER, usernameToKick, teamName);

            return message;
        }
    }
}