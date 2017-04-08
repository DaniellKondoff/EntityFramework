using EntityFramework.Extensions;
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
    public class DisbandCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            AuthenticationManager.Authorize();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            User currentUser = AuthenticationManager.GetCurrentUser();
            if (!CommandHelper.IsUserCreatorOfTeam(teamName,currentUser.Username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }

            this.DisbandTeam(teamName);
            return $"{teamName} has disbanded!";
        }

        private void DisbandTeam(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                context.Teams.Remove(team);
                context.SaveChanges();
            }
        }
    }
}
