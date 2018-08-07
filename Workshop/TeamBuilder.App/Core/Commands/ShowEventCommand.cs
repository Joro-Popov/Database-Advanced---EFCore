namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Services.Contracts;

    public class ShowEventCommand : ICommand
    {
        private readonly IUserService userService;

        public ShowEventCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Check.CheckLenght(1, args);

            var eventName = args[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.EventNotFound, eventName));
            }

            return this.userService.ShowEvent(eventName);
        }
    }
}