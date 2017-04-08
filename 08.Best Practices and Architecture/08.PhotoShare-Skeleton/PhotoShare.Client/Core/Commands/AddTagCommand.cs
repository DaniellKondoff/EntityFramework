namespace PhotoShare.Client.Core.Commands
{
    using Client;
    using Models;
    using Service;
    using System;
    using Utilities;

    public class AddTagCommand
    {
        private TagService tagService;
        public AddTagCommand(TagService tagService)
        {
            this.tagService = tagService;
        }
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            string tag = data[0].ValidateOrTransform();

            if (this.tagService.IsTagExist(tag))
            {
                throw new ArgumentException($"Tag {tag} exists!");
            }

            this.tagService.AddTag(tag);
            return  $"Tag {tag} was added successfully!";
        }
    }
}
