namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class ShowEventCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 1;

        private readonly IUserService userService;

        public ShowEventCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);

            var eventName = args[0];

            if (!DatabaseChecker.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.EVENT_NOT_FOUND, eventName));
            }

            var message = this.userService.ShowEvent(eventName);

            return message;
        }
    }
}