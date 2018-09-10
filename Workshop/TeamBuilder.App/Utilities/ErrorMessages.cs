namespace TeamBuilder.App.Utilities
{
    public static class ErrorMessages
    {
        // Common error messages.
        public const string INVALID_ARGUMENTS_COUNT = "Invalid arguments count!";

        public const string SHOULD_LOGOUT_FIRST = "You should logout first!";
        public const string SHOULD_LOGIN_FIRST = "You should login first!";

        public const string TEAM_OR_USER_NOT_EXIST = "Team or user does not exist!";
        public const string INVITE_IS_ALREADY_SENT = "Invite is already sent!";

        public const string OPERATION_NOT_ALLOWED = "Not allowed!";

        public const string TEAM_NOT_FOUND = "Team {0} not found!";
        public const string USER_NOT_FOUND = "User {0} not found!";
        public const string EVENT_NOT_FOUND = "Event {0} not found!";
        public const string INVITE_NOT_FOUND = "Invite from {0} is not found!";

        public const string NOT_PART_OF_TEAM = "User {0} is not a member in {1}!";

        public const string COMMAND_NOT_ALLOWED = "Command not allowed. Use {0} instead.";
        public const string CANNOT_ADD_SAME_TEAM_TWICE = "Cannot add same team twice!";

        // User error messages.
        public const string USERNAME_NOT_VALID = "Username {0} not valid!";

        public const string PASSWORD_NOT_VALID = "Password {0} not valid!";
        public const string PASSWORD_MISMATCH = "Passwords do not match!";
        public const string AGE_NOT_VALID = "Age not valid!";
        public const string GENDER_NOT_VALID = "Gender should be either “Male” or “Female”!";
        public const string USERNAME_IS_TAKEN = "Username {0} is already taken!";
        public const string INVALID_USERNAME_OR_PASSWORD = "Invalid username or password!";

        //Event error messages.
        public const string INVALID_DATE_FORMAT = "Please insert the dates in format: [dd/MM/yyyy HH:mm]!";

        public const string INVALID_START_DATE = "Start date should be before end date!";

        // Team error messages.
        public const string INVALID_ACRONYM = "Acronym {0} not valid!";

        public const string TEAM_EXISTS = "Team {0} exists!";

        public const string INVALID_COMMAND = "Command {0} not valid!";
    }
}