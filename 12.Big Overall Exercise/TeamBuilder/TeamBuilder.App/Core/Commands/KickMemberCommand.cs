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
    public class KickMemberCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];
            string userName = inputArgs[1];

            AuthenticationManager.Authorize();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            if (!CommandHelper.IsUserExisting(userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, userName));
            }
            if (!CommandHelper.IsMemberOfTeam(teamName,userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, userName,teamName));
            }

            User currentUser = AuthenticationManager.GetCurrentUser();
            if (!CommandHelper.IsUserCreatorOfTeam(teamName,currentUser.Username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }

            if (AuthenticationManager.GetCurrentUser().Username == userName) 
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "DisbandTeam"));
            }

            return $"User {userName} was kicked from {teamName}!";
        }

       
    }
}
