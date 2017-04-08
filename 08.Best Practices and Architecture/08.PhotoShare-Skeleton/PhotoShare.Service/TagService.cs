namespace PhotoShare.Service
{
    using PhotoShare.Client;
    using PhotoShare.Models;
    using System.Linq;
    public class TagService
    {
        public void AddTag(string tagName)
        {
            Tag tag = new Tag()
            {
                Name = tagName
            };
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public bool IsTagExist(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }

    }
}
