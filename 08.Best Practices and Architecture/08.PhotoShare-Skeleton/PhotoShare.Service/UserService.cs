namespace PhotoShare.Service
{
    using PhotoShare.Models;
    using System;
    using System.Linq;
    using PhotoShare.Client;
    using System.Data.Entity;

    public class UserService
    {
        public virtual void Add(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User ListAllFriends(string username)
        {
            using (PhotoShareContext context= new PhotoShareContext())
            {
                User user1 = context.Users.Include(u=>u.Friends).FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
                return user1;
            }
                
           
        }

        public void Remove(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User UserForRemove =context.Users.SingleOrDefault(u => u.Username == username);

                if (UserForRemove != null)
                {
                    UserForRemove.IsDeleted = true;
                    context.SaveChanges();
                }
            }
        }

        public bool UserIsFriend(string userName1, string userName2)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user1 = context.Users.Include(u=>u.Friends).SingleOrDefault(u => u.Username == userName1);
                //User user2 = context.Users.SingleOrDefault(u => u.Username == userName2);
                return user1.Friends.Any(f => f.Username == userName2);
            }

        }

        public void MakeFriends(string userName1, string userName2)
        {
            using (PhotoShareContext context= new PhotoShareContext())
            {
                User user1 = context.Users.FirstOrDefault(u => u.Username.ToLower() == userName1.ToLower());
                User user2 = context.Users.FirstOrDefault(u => u.Username.ToLower() == userName2.ToLower());
                user1.Friends.Add(user2);
                context.SaveChanges();
            }
        }

        public bool IsUserExist(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public bool  IsUserDeleted(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username);

                return user.IsDeleted == true;
                //return context.Users.Any(u => u.Username == username && u.IsDeleted==true);               
            }
        }


        public User GetUserByUsername(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }
        public void UpdateUser(User updatedUser)
        {
            using (PhotoShareContext context=new PhotoShareContext())
            {
                //context.Users.Attach(updatedUser);
                //context.Entry(updatedUser).State = EntityState.Modified;
                //context.SaveChanges();

                //If we do not use Foreign Key like int valies;
                User userToUpdate = context.Users
                    .Include(t => t.BornTown)
                    .Include(t => t.CurrentTown)
                    .SingleOrDefault(u => u.Id == updatedUser.Id);

                if (userToUpdate != null)
                {

                    if (updatedUser.Password != userToUpdate.Password)
                    {
                        userToUpdate.Password = updatedUser.Password;
                    }
                    if (updatedUser.BornTown != null &&
                        (userToUpdate.BornTown == null || updatedUser.BornTown.Id != userToUpdate.BornTown.Id))
                    {
                        userToUpdate.BornTown = context.Towns.Find(updatedUser.BornTown.Id);
                    }
                    if (updatedUser.CurrentTown != null &&
                        (userToUpdate.CurrentTown == null || updatedUser.CurrentTown.Id != userToUpdate.CurrentTown.Id))
                    {
                        userToUpdate.CurrentTown = context.Towns.Find(updatedUser.CurrentTown.Id);
                    }
                    context.SaveChanges();
                }
            }
        }

    }
}
