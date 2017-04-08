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
    public class AcceptInviteCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            AuthenticationManager.Authorize();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound,teamName));
            }
            if (!CommandHelper.IsTeamInviteExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound,teamName));
            }


            this.AcceptInvite(teamName);
            var user = AuthenticationManager.GetCurrentUser();
            return $"User {user.Username} joined team {teamName}!";
        }

        private void AcceptInvite(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                var invitation = context.Invitations.FirstOrDefault(i => i.Team.Name == teamName && i.IsActive == true);
                User user = invitation.InvitedUser;
                Team team = invitation.Team;
                var userAcc =context.Users.Attach(user);
                var teamAcc =context.Teams.Attach(team);
                teamAcc.Members.Add(userAcc);
                context.SaveChanges();            
            }
        }

    }
}
