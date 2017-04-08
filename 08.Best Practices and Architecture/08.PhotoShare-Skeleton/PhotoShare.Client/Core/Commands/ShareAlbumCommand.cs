namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Service;
    using System;

    public class ShareAlbumCommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        private UserService userService;
        private AlbumService albumService;

        public ShareAlbumCommand(UserService userService, AlbumService albumService)
        {
            this.userService = userService;
            this.albumService = albumService;
        }
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            int albumId = int.Parse(data[0]);
            string userName = data[1];
            string permission = data[2];

            Album album = this.albumService.GetAlbumByAlbumId(albumId);
            if (album==null)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }
            if (!this.userService.IsUserExist(userName))
            {
                throw new ArgumentException($"User {userName} not found!");
            }

            Role role;
            bool isRoleValid = Enum.TryParse(permission, out role);
            if (!isRoleValid)
            {
                throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
            }
            User loggedUser = SecurityService.GetCurrentUser();
            if (loggedUser.Username==userName)
            {
                if (permission!="Owner")
                {
                    throw new InvalidOperationException("Invalid credentials");
                }
            }
            else if(loggedUser.Username != userName)
            {
                throw new InvalidOperationException("Invalid credentials");
            }
            this.albumService.AddAlbumShare(albumId, userName, role);

            return $"Username {userName} added to album {album.Name} ({permission})";
        }
    }
}
