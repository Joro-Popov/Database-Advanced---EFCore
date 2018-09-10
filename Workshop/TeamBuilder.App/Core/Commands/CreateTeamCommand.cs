namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
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

            SetArgumentValues(args, ref teamName, ref acronym, ref description);

            Checker.CheckUserIsLoggedOut();

            if (DatabaseChecker.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.TEAM_EXISTS, teamName));
            }

            Checker.CheckAcronymIsExisting(acronym);

            this.userService.CreateTeam(teamName, acronym, description);

            var message = string.Format(SuccessfullMessages.SUCCESSFULLY_CREATED_TEAM, teamName);

            return message;
        }

        private void SetArgumentValues(string[] args, ref string teamName, ref string acronym, ref string description)
        {
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
        }
    }
}