namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class CreateEventCommand : ICommand
    {
        private readonly IUserService userService;

        public CreateEventCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(6, args);
            Check.CheckUserIsLoggedOut();

            var eventName = args[0];
            var description = args[1];
            var startDate = Check.CheckDateIsValid(args[2] + " " + args[3]);
            var endDate = Check.CheckDateIsValid(args[4] + " " + args[5]);

            Check.CheckStartDate(startDate, endDate);

            this.userService.CreateEvent(eventName, description, startDate, endDate);

            return string.Format(InfoMessages.SuccessfullyCreatedEvent, eventName);
        }
    }
}