namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Service;
    using System;

    public class UploadPictureCommand
    {
        private AlbumService albumService;
        private PictureService pictureService;
        public UploadPictureCommand(AlbumService albumService,PictureService pictureService)
        {
            this.albumService = albumService;
            this.pictureService = pictureService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }
            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];

            if (!this.albumService.isAlbumExisting(albumName))
            {
                throw new ArgumentException($"Album [{albumName}] not found!");
            }

            User loggedUser = SecurityService.GetCurrentUser();
            if (!this.albumService.IsUserOwner(albumName, loggedUser))
            {
                throw new ArgumentException("Invadil credentials");
            }

            this.pictureService.CreatePicute(pictureTitle, pictureFilePath);
            this.albumService.AddPictureToAlbum(albumName, pictureTitle);
            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
