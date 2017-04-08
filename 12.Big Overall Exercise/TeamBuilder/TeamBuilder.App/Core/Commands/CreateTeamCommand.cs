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
    public class CreateTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string name = inputArgs[0];
            string acronym = inputArgs[1];

            AuthenticationManager.Authorize();

            if (CommandHelper.IsTeamExisting(name))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, name));
            }
            if (acronym.Length!=3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            this.CreateTeam(name, acronym);
            return $"Team {name} successfully created!";
        }

        private void CreateTeam(string name, string acronym)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User teamCreator = context.Users.Attach(AuthenticationManager.GetCurrentUser());
                Team team = new Team()
                {
                    Name = name,
                    Acronym = acronym,
                    CreatorId = teamCreator.Id
                };
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
    }
}
