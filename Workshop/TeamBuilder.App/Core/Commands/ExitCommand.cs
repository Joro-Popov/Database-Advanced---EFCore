namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.App.Utilities;

    public class ExitCommand : ICommand
    {
        private const int EXPRECTED_ARGUMENTS_LENGTH = 0;

        public string Execute(string[] args)
        {
            Checker.CheckArgumentsLength(EXPRECTED_ARGUMENTS_LENGTH, args.Length);

            var message = SuccessfullMessages.SUCCESSFULL_EXIT;

            return message;
        }
    }
}