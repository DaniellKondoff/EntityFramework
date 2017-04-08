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
    public class ShowEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            string eventName = inputArgs[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            string result = string.Empty;

            var eventt =this.GetEvent(eventName);
            result += eventt.Name + " " + eventt.StartDate + " " + eventt.EndDate + " " + eventt.Descriprion;
            result += "\n" + "Teams:";
            foreach (var e in eventt.ParticipatingTeams)
            {
                result += $"\n--{e.Name}";
            }
            return result;
        }

        private Event GetEvent(string eventName)
        {
            using (TeamBuilderContext context=new TeamBuilderContext())
            {
                return context.Events.Include("ParticipatingTeams").FirstOrDefault(e => e.Name == eventName);                      
            }
        }
    }
}
