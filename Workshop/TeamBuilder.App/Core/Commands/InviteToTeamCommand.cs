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

    public class InviteToTeamCommand : ICommand
    {
        private readonly IUserService userService;

        public InviteToTeamCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(2, args);
            Check.CheckUserIsLoggedOut();

            var teamName = args[0];
            var username = args[1];

            User receiver = null;

            using (var context = new TeamBuilderDbContext())
            {
                receiver = context.Users.FirstOrDefault(u => u.Username == username);
            }

            //Check for user and team existance
            if (!CommandHelper.IsUserExisting(username) || !CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(ErrorMessages.TeamOrUserNotExist);
            }

            //Check if invitation can be complete
            var isCreator = CommandHelper.IsUserCreatorOfTeam(teamName, AuthenticationService.GetCurrentUser());
            var isCreatorMemeber = CommandHelper.IsMemberOfTeam(teamName, AuthenticationService.GetCurrentUser().Username);
            var isInviteduserMemeber = CommandHelper.IsMemberOfTeam(teamName, username);
            var isInvited = CommandHelper.IsMemberOfTeam(teamName, username);
            var isDeleted = CommandHelper.IsUserDeleted(username);

            if (!isCreator || !isCreatorMemeber || isInvited || isDeleted || isInviteduserMemeber)
            {
                throw new InvalidOperationException(ErrorMessages.NotAllowed);
            }

            //Check if invitation exists
            if (CommandHelper.IsInviteExisting(teamName, receiver))
            {
                throw new InvalidOperationException(ErrorMessages.InviteIsAlreadySent);
            }

            this.userService.SentInvitation(teamName, receiver);

            return string.Format(InfoMessages.SuccessfullyInvited, teamName, username);
        }
    }
}