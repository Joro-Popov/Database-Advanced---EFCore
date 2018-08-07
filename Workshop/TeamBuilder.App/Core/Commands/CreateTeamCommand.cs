namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class CreateTeamCommand : ICommand
    {
        private readonly IUserService userService;

        public CreateTeamCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            string teamName = string.Empty;
            string acronym = string.Empty;
            string description = string.Empty;

            if (args.Length == 2)
            {
                teamName = args[0];
                acronym = args[1];
            }
            else
            {
                teamName = args[0];
                acronym = args[1];
                description = args[2];
            }

            Check.CheckUserIsLoggedOut();
            
            //Check if team exists
            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TeamExists, teamName));
            }

            Check.CheckAcronymIsExisting(acronym);
            
            this.userService.CreateTeam(teamName, acronym, description);

            return string.Format(InfoMessages.SuccessfullyCreatedTeam, teamName);
        }
    }
}