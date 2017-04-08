namespace PhotoShare.Service
{
    using System;
    using PhotoShare.Client;
    using PhotoShare.Models;
    using System.Linq;
    public class PictureService
    {
        public void CreatePicute(string pictureTitle, string pictureFilePath)
        {
            Picture picture = new Picture()
            {
                Title = pictureTitle,
                Path = pictureFilePath
            };
            using(PhotoShareContext context=new PhotoShareContext())
            {
                context.Pictures.Add(picture);
                context.SaveChanges();
            }
        }
    }
}
