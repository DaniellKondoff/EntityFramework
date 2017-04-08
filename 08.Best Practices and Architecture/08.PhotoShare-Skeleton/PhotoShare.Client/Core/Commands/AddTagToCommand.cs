namespace PhotoShare.Client.Core.Commands
{
    using Service;
    using System;
    using System.Linq;
    using Utilities;

    public class AddTagToCommand 
    {
        private TagService tagService;
        private AlbumService albumService;
        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            string albumName = data[0];
            string tagName = TagUtilities.ValidateOrTransform(data[1]);

            if (!this.tagService.IsTagExist(tagName))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }
            if (!this.albumService.isAlbumExisting(albumName))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            this.albumService.AddTagToAlbum(albumName, tagName);
            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
