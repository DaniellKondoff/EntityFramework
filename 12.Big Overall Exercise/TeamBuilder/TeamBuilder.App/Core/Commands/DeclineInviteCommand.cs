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
    public class DeclineInviteCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            AuthenticationManager.Authorize();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            if (!CommandHelper.IsTeamInviteExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }

            this.DeclineInvite(teamName);
            return $"Invite from {teamName} declined.";
        }

        private void DeclineInvite(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                var invitation = context.Invitations.FirstOrDefault(i => i.Team.Name == teamName && i.IsActive == true);
                invitation.IsActive = false;
                context.SaveChanges();
            }
        }
    }
}
