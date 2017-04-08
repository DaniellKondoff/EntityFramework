using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class CreateEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            string eventName = inputArgs[0];
            string description = inputArgs[1];
            DateTime startDate;
            bool isStartDateValid = DateTime.TryParseExact(inputArgs[2] + " " +inputArgs[3], Constants.DateTimeFormat, CultureInfo.InvariantCulture,DateTimeStyles.None, out startDate);
            DateTime endDate;
            bool IsEndDateValid= DateTime.TryParseExact(inputArgs[4]+" "+inputArgs[5], Constants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!isStartDateValid || !IsEndDateValid)
            {
                throw new ArgumentException("Invalid DateTimeFormat");
            }

            if (startDate>endDate)
            {
                throw new ArgumentException("StartDate must be first");
            }
            AuthenticationManager.Authorize();

            User creatorUser = AuthenticationManager.GetCurrentUser();

            this.CreateEvent(eventName, description, startDate, endDate, creatorUser);
            return $"Event {eventName} was created successfully!";
        }

        private void CreateEvent(string eventName, string description, DateTime startDate, DateTime endDate, User creatorUser)
        {
            using(TeamBuilderContext context= new TeamBuilderContext())
            {
                User eventCreator=context.Users.Attach(creatorUser);
                Event eventCreat = new Event()
                {
                    Name = eventName,
                    Descriprion = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = eventCreator.Id
                };
                context.Events.Add(eventCreat);
                context.SaveChanges();
            }
        }
    }
}
