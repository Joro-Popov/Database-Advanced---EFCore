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
        private const int EXPRECTED_ARGUMENTS_LENGTH = 2;

        private readonly IUserService userService;

        public InviteToTeamCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var teamName = args[0];
            var username = args[1];

            User inviteReciever = null;
            var loggedInUser = AuthenticationService.GetCurrentUser();

            using (var context = new TeamBuilderDbContext())
            {
                inviteReciever = context.Users.FirstOrDefault(u => u.Username == username);
            }

            if (!DatabaseChecker.IsUserExisting(username) || !DatabaseChecker.IsTeamExisting(teamName))
            {
                throw new ArgumentException(ErrorMessages.TEAM_OR_USER_NOT_EXIST);
            }

            var isUserCreator = DatabaseChecker.IsUserCreatorOfTeam(teamName, loggedInUser);
            var isCreatorPartOfTheTeam = DatabaseChecker.IsMemberOfTeam(teamName, loggedInUser.Username);
            var isInvitedUserPartOfTheTeam = DatabaseChecker.IsMemberOfTeam(teamName, username);
            var isUserInvited = DatabaseChecker.IsMemberOfTeam(teamName, username);
            var isUserDeleted = DatabaseChecker.IsUserDeleted(username);

            if (!isUserCreator || !isCreatorPartOfTheTeam || isUserInvited || isUserDeleted || isInvitedUserPartOfTheTeam)
            {
                throw new InvalidOperationException(ErrorMessages.OPERATION_NOT_ALLOWED);
            }

            if (DatabaseChecker.IsInviteExisting(teamName, inviteReciever))
            {
                throw new InvalidOperationException(ErrorMessages.INVITE_IS_ALREADY_SENT);
            }

            this.userService.SendInvitation(teamName, inviteReciever);

            var message = string.Format(SuccessfullMessages.SUCCESSFULLY_MADE_INVITATION, teamName, username);

            return message;
        }
    }
}