namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Service;

    public class AddTownCommand
    {
        private readonly TownService service;
        public AddTownCommand(TownService service)
        {
            this.service = service;
        }
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            string townName = data[0];
            string country = data[1];

            if (this.service.IsTaken(townName))
            {
                throw new ArgumentException($"Town {townName} already added!");
            }

            this.service.AddTown(townName, country);

            return "Town " +townName + " was added successfully!";
        }
    }
}
