namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class ShowTeamCommand : ICommand
    {
        private readonly IUserService userService;

        public ShowTeamCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(1, args);

            var teamName = args[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamNotFound, teamName));
            }

            return this.userService.ShowTeam(teamName);
        }
    }
}