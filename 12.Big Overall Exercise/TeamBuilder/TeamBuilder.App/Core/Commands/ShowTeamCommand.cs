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
    public class ShowTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            string result = string.Empty;

            Team team=this.GetTeam(teamName);
            result += $"{team.Name} {team.Acronym}\nMembers:";
            foreach (var member in team.Members)
            {
                result += $"\n--{member.Username}";
            }

            return result;
        }

        private Team GetTeam(string teamName)
        {
            using (TeamBuilderContext context=new TeamBuilderContext())
            {
                return context.Teams.Include("Members").FirstOrDefault(t => t.Name == teamName);
            }
        }
    }
}
