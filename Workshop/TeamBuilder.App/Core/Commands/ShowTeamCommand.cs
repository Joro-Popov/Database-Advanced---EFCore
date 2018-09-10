namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class ShowTeamCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 1;

        private readonly IUserService userService;

        public ShowTeamCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);

            var teamName = args[0];

            if (!DatabaseChecker.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TEAM_NOT_FOUND, teamName));
            }

            var message = this.userService.ShowTeam(teamName);

            return message;
        }
    }
}