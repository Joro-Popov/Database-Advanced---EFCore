namespace TeamBuilder.App.Utilities
{
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Users.Any(u => u.Username == username && u.IsDeleted == false);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive == true);
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Teams
                    .FirstOrDefault(t => t.Name == teamName)
                    .CreatorId == user.Id;
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Events
                    .FirstOrDefault(e => e.Name == eventName)
                    .CreatorId == user.Id;
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (var context = new TeamBuilderDbContext())
            {
                var userTeam = context.UserTeams.FirstOrDefault(u => u.User.Username == username && u.Team.Name == teamName);

                if (userTeam != null)
                {
                    return true;
                }
                return false;
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Events.Any(e => e.Name == eventName);
            }
        }

        public static bool ArePasswordsEqual(string username, string password)
        {
            using (var context = new TeamBuilderDbContext())
            {
                var passwordDb = context.Users.FirstOrDefault(u => u.Username == username).Password;

                return password == passwordDb;
            }
        }

        public static bool IsUserDeleted(string username)
        {
            using (var context = new TeamBuilderDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username).IsDeleted;
            }
        }

        public static bool IsTeamPartOfEvent(string eventName, string teamName)
        {
            using (var context = new TeamBuilderDbContext())
            {
                var eventTeam = context.EventTeams.FirstOrDefault(et => et.Event.Name == eventName && et.Team.Name == teamName);

                if (eventTeam != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}