namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Service;
    using System;
    using System.Linq;
    using Utilities;

    public class CreateAlbumCommand
    {
        private UserService userService;
        private TagService tagService;
        private AlbumService albumService;
        public CreateAlbumCommand(UserService userService, TagService tagService,AlbumService albumService)
        {
            this.userService = userService;
            this.tagService = tagService;
            this.albumService = albumService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string backgroundColor = data[2];
            string[] tags = data.Skip(3).Select(t=>TagUtilities.ValidateOrTransform(t)).ToArray();

            if (!this.userService.IsUserExist(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            Color color;
            bool isColorValid = Enum.TryParse(backgroundColor, out color);
            if (!isColorValid)
            {
                throw new ArgumentException($"Color {backgroundColor} not found!");
            }
            if (!tags.Any(t =>this.tagService.IsTagExist(t)))
            {
                throw new ArgumentException($"Invalid Tags!");
            }
            
            if (this.albumService.isAlbumExisting(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} Exist!");
            }

            this.albumService.AddAlbum(albumTitle, username, color, tags);
           
            return $"Album {albumTitle} successfully created!";
        }
    }
}
