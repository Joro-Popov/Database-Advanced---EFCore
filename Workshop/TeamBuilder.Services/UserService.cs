namespace TeamBuilder.Services
{
    using System;
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;
    using TeamBuilder.Models.Enums;
    using TeamBuilder.Services.Contracts;

    public class UserService : IUserService
    {
        private readonly TeamBuilderDbContext context;

        public UserService(TeamBuilderDbContext context)
        {
            this.context = context;
        }

        public void RegisterUser(string username, string password, string firstName, string lastName, int age, Gender gender)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void DeleteUser(string username)
        {
            this.context.Users.FirstOrDefault(u => u.Username == username).IsDeleted = true;
            this.context.SaveChanges();
        }

        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate)
        {
            var loggedInUser = AuthenticationService.GetCurrentUser();

            var Event = new Event
            {
                Name = name,
                Description = description,
                CreatorId = loggedInUser.Id,
                StartDate = startDate,
                EndDate = endDate,
            };

            this.context.Events.Add(Event);
            this.context.SaveChanges();
        }

        public void CreateTeam(string name, string acronym, string description)
        {
            var creator = AuthenticationService.GetCurrentUser();

            var team = new Team
            {
                Name = name,
                Acronym = acronym,
                Description = description,
                CreatorId = creator.Id
            };

            this.context.Teams.Add(team);
            this.context.SaveChanges();

            var userTeam = new UserTeam
            {
                TeamId = context.Teams.FirstOrDefault(t => t.Name == name).Id,
                UserId = creator.Id
            };

            this.context.Teams.FirstOrDefault(t => t.Name == name).UserTeams.Add(userTeam);

            this.context.SaveChanges();
        }

        public void SendInvitation(string teamName, User invitationReceiver)
        {
            var loggedInUser = AuthenticationService.GetCurrentUser();
            var team = this.context.Teams.FirstOrDefault(t => t.Name == teamName);

            var userIsCreatorOfTeam = invitationReceiver.Username == loggedInUser.Username;

            if (userIsCreatorOfTeam)
            {
                AddUserToTeam(loggedInUser, team);
            }
            else
            {
                InviteUserToTeam(invitationReceiver, team);
            }

            this.context.SaveChanges();
        }

        public void AcceptInvitation(string teamName)
        {
            var Invitation = AuthenticationService.GetCurrentUser().ReceivedInvitations
                .Where(i => i.IsActive == true)
                .FirstOrDefault(i => i.Team.Name == teamName);

            var userTeam = new UserTeam
            {
                TeamId = this.context.Teams.FirstOrDefault(t => t.Id == Invitation.TeamId).Id,
                UserId = this.context.Users.FirstOrDefault(u => u.Id == Invitation.InvitedUserId).Id
            };

            this.context.Teams.FirstOrDefault(t => t.Name == Invitation.Team.Name).UserTeams.Add(userTeam);

            this.context.Invitations.FirstOrDefault(i => i.Id == Invitation.Id).IsActive = false;

            this.context.SaveChanges();
        }

        public void DeclineInvite(string teamName)
        {
            var loggedInUser = AuthenticationService.GetCurrentUser();

            var invitation = this.context.Users
                .FirstOrDefault(u => u.Id == loggedInUser.Id)
                .ReceivedInvitations
                .FirstOrDefault(i => i.Team.Name == teamName);

            invitation.IsActive = false;

            this.context.SaveChanges();
        }

        public void KickMember(string teamName, string username)
        {
            var teamId = this.context.Teams.FirstOrDefault(t => t.Name == teamName).Id;
            var userId = this.context.Users.FirstOrDefault(u => u.Username == username).Id;

            var userTeam = this.context.UserTeams
                               .FirstOrDefault(u => u.UserId == userId && u.TeamId == teamId);

            this.context.UserTeams.Remove(userTeam);
            this.context.SaveChanges();
        }

        public void Disband(string teamName)
        {
            var team = this.context.Teams.FirstOrDefault(t => t.Name == teamName);

            this.context.Teams.Remove(team);
            this.context.SaveChanges();
        }

        public void AddTeamToEvent(string eventName, string teamName)
        {
            var eventId = this.context.Events.OrderBy(e => e.StartDate).FirstOrDefault(e => e.Name == eventName).Id;
            var teamId = this.context.Teams.FirstOrDefault(t => t.Name == teamName).Id;

            var eventTeam = new TeamEvent
            {
                EventId = eventId,
                TeamId = teamId
            };

            this.context.Events.FirstOrDefault(e => e.Name == eventName).ParticipatingEventTeams.Add(eventTeam);
            this.context.SaveChanges();
        }

        public string ShowEvent(string eventName)
        {
            return this.context.Events.FirstOrDefault(e => e.Name == eventName).ToString();
        }

        public string ShowTeam(string teamName)
        {
            return this.context.Teams.FirstOrDefault(e => e.Name == teamName).ToString();
        }

        private void AddUserToTeam(User loggedInUser, Team team)
        {
            var userTeam = new UserTeam
            {
                TeamId = team.Id,
                UserId = loggedInUser.Id
            };
            this.context.UserTeams.Add(userTeam);
        }

        private void InviteUserToTeam(User invitationReceiver, Team team)
        {
            var Invitation = new Invitation
            {
                InvitedUserId = invitationReceiver.Id,
                TeamId = team.Id
            };
            this.context.Invitations.Add(Invitation);
        }
    }
}