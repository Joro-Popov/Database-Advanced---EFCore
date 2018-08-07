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
        private readonly IUserService userService;

        public KickMemberCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(2, args);
            Check.CheckUserIsLoggedOut();

            var loggedInUser = AuthenticationService.GetCurrentUser();
            var teamName = args[0];
            var username = args[1];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(ErrorMessages.UserNotFound, username));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, loggedInUser.Username))
            {
                throw new ArgumentException(string.Format(ErrorMessages.NotPartOfTeam, loggedInUser.Username, teamName));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, username))
            {
                throw new ArgumentException(string.Format(ErrorMessages.NotPartOfTeam, username, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, loggedInUser))
            {
                throw new InvalidOperationException(ErrorMessages.NotAllowed);
            }

            User userToKick = null;

            using (var context = new TeamBuilderDbContext())
            {
                userToKick = context.Users.FirstOrDefault(u => u.Username == username);
            }

            if (CommandHelper.IsUserCreatorOfTeam(teamName, userToKick))
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.CommandNotAllowed, "DisbandTeam"));
            }

            this.userService.KickMember(teamName, username);

            return string.Format(InfoMessages.SuccessfullKickedUser, username, teamName);
        }
    }
}