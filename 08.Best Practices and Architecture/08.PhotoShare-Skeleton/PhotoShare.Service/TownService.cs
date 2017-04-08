namespace PhotoShare.Service
{
    using PhotoShare.Client;
    using PhotoShare.Models;
    using System.Linq;
    public class TownService
    {
        public void AddTown(string townName, string country)
        {
            Town town = new Town
            {
                Name = townName,
                Country = country
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Towns.Add(town);
                context.SaveChanges();
            }
        }

        public bool IsTaken(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

        public Town GetByTownName(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name == townName);
            }
        }
    }
}
