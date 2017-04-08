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
    public class AddTeamToCommand
    {
        public string Execute(string[] inputArgs)
        {
            string eventName = inputArgs[0];
            string teamName = inputArgs[1];

            AuthenticationManager.Authorize();

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            User currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsUserCreatorOfEvent(eventName,currentUser))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }

            this.AddTeamToEvent(eventName, teamName);
            return $"Team {teamName} added for {eventName}!";
        }

        private void AddTeamToEvent(string eventName, string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                Event ev = context.Events.OrderByDescending(e=>e.StartDate).FirstOrDefault(e => e.Name == eventName);

                if (ev.ParticipatingTeams.Any(t=>t.Name==teamName))
                {
                    throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CannotAddSameTeamTwice));
                }
                ev.ParticipatingTeams.Add(team);
                context.SaveChanges();
            }
        }
    }
}
