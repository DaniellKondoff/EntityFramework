using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ImportTeamsCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }
            List<Team> teams;
            try
            {
                teams = this.GetTeamsFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }
            this.addTeams(teams);

            return $"You have successfully imported {teams.Count} teams!";
        }

        private void addTeams(List<Team> teams)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                context.Teams.AddRange(teams);
                context.SaveChanges();
            }
        }

        private List<Team> GetTeamsFromXml(string filePath)
        {
            XDocument xmlTeams = XDocument.Load(filePath);
            var teamsElement = xmlTeams.Root.Elements();
            List<Team> teamsList = new List<Team>();

            foreach (var team in teamsElement)
            {
                string name = team.Element("name").Value;
                string acronym = team.Element("acronym").Value;
                string description = team.Element("description").Value;
                int creatorId = int.Parse(team.Element("creator-id").Value);

                Team teamModel = new Team()
                {
                    Name = name,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                };
                teamsList.Add(teamModel);
            }

            return teamsList;
        }
    }
}
