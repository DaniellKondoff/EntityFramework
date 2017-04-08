using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class InveteToTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];
            string userName = inputArgs[1];

            //Validate if user is loggged
            AuthenticationManager.Authorize();

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, AuthenticationManager.GetCurrentUser().Username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }

            //If user or team do not exist
            if (!CommandHelper.IsUserExisting(userName)|| !CommandHelper.IsTeamExisting(teamName))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.TeamOrUserNotExist));
            }
            //if invite alreadyExist
            if (CommandHelper.IsInviteExisting(teamName,userName))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.InviteIsAlreadySent));
            }

            this.InviteToTeamCmd(teamName, userName);

            return $"Team {teamName} invited {userName}!";
        }

        private void InviteToTeamCmd(string teamName, string userName)
        {
            using (TeamBuilderContext context=new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                var user = context.Users.FirstOrDefault(u => u.Username == userName);
                Invitation invite = new Invitation()
                {
                    InvitedUserId=user.Id,
                    TeamId=team.Id,
                    IsActive=true
                };

                context.Invitations.Add(invite);
                context.SaveChanges();
            }
        }
    }
}
