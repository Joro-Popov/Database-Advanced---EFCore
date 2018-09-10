namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class CreateEventCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 6;

        private readonly IUserService userService;

        public CreateEventCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);
            Checker.CheckUserIsLoggedOut();

            var eventName = args[0];
            var description = args[1];
            var inputStartDate = args[2];
            var inputStartTime = args[3];
            var inputEndDate = args[4];
            var inputEndTime = args[5];

            var startDate = Checker.CheckDateIsValid($"{inputStartDate} {inputStartTime}");
            var endDate = Checker.CheckDateIsValid($"{inputEndDate} {inputEndTime}");

            Checker.CheckStartDateIsBeforeEndDate(startDate, endDate);

            this.userService.CreateEvent(eventName, description, startDate, endDate);

            var message = string.Format(SuccessfullMessages.SUCCESSFULLY_CREATED_EVENT, eventName);

            return message;
        }
    }
}