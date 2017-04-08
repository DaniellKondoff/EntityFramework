namespace PhotoShare.Service
{
    using Client;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AlbumService
    {
        public void AddAlbum(string albumName,string ownerUserName, Color color,string[] tagNames)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = new Album();
                album.Name = albumName;
                album.BackgroundColor = color;
                album.Tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                User owner = context.Users.SingleOrDefault(u => u.Username == ownerUserName);
                if (owner!=null)
                {
                    AlbumRole albumRole = new AlbumRole();
                    albumRole.User = owner;
                    albumRole.Album = album;
                    albumRole.Role = Role.Owner;
                    album.AlbumRoles.Add(albumRole);

                    context.Albums.Add(album);
                    context.SaveChanges();
                }
            }              
        }

        public bool IsUserOwner(string albumName, User loggedUser)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name.ToLower() == albumName.ToLower());
                return context.AlbumRoles.Any(a => a.Album.Id == album.Id && a.User.Id == loggedUser.Id && a.Role == 0);
            }
        }

        public void AddPictureToAlbum(string albumName, string pictureTitle)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name.ToLower() == albumName.ToLower());
                Picture picture = context.Pictures.SingleOrDefault(p => p.Title.ToLower() == pictureTitle.ToLower());
                album.Pictures.Add(picture);
                context.SaveChanges();
            }
        }

        public Album GetAlbumByAlbumId(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album= context.Albums.SingleOrDefault(a => a.Id == albumId);
                return album;
            }
        }

        public void AddAlbumShare(int albumId, string userName, Role permission)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Id == albumId);
                User user = context.Users.SingleOrDefault(u => u.Username == userName);
                Role role = permission;
                AlbumRole albumRole = new AlbumRole();
                albumRole.Album = album;
                albumRole.User = user;
                albumRole.Role = role;
                context.AlbumRoles.Add(albumRole);
                context.SaveChanges();
            }
        }

        public bool isAlbumExisting(string albumName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumName);
            }
        }

        public void AddTagToAlbum(string albumName,string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Tag tag = context.Tags.Single(t => t.Name == tagName);
                //album.Tags = context.Tags.Where(t => t.Name == tagName).ToList();
                album.Tags.Add(tag);
                context.SaveChanges();
            }

        }
    }
}
