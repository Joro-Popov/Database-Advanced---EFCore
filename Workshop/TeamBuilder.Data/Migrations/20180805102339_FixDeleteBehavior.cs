using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamBuilder.Data.Migrations
{
    public partial class FixDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTeams_Events_EventId",
                table: "EventTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTeams_Teams_TeamId",
                table: "EventTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_InvitedUserId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Teams_TeamId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeams_Events_EventId",
                table: "EventTeams",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeams_Teams_TeamId",
                table: "EventTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_InvitedUserId",
                table: "Invitations",
                column: "InvitedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Teams_TeamId",
                table: "Invitations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTeams_Events_EventId",
                table: "EventTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTeams_Teams_TeamId",
                table: "EventTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_InvitedUserId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Teams_TeamId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeams_Events_EventId",
                table: "EventTeams",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeams_Teams_TeamId",
                table: "EventTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_InvitedUserId",
                table: "Invitations",
                column: "InvitedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Teams_TeamId",
                table: "Invitations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}