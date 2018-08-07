namespace TeamBuilder.Services.Contracts
{
    using System;
    using TeamBuilder.Models;
    using TeamBuilder.Models.Enums;

    public interface IUserService
    {
        void RegisterUser(string username, string password, string firstName, string lastName, int age, Gender gender);

        void DeleteUser(string username);

        void CreateEvent(string name, string description, DateTime startDate, DateTime endDate);

        void CreateTeam(string name, string acronym, string description);

        void SentInvitation(string teamName, User receiver);

        void AcceptInvitation(string teamName);

        void DeclineInvite(string teamName);

        void KickMember(string teamName, string username);

        void Disband(string teamName);

        void AddTeamToEvent(string eventName, string teamName);

        string ShowEvent(string eventName);

        string ShowTeam(string teamName);
    }
}