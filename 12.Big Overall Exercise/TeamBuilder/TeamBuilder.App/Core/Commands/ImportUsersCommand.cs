using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ImportUsersCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }
            List<User> users;
            try
            {
                users = this.GetUsersFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }
            this.addUsers(users);

            return $"You have successfully imported {users.Count} users!";
        }

        private void addUsers(List<User> users)
        {
            using (TeamBuilderContext context=new TeamBuilderContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            } 
        }

        private List<User> GetUsersFromXml(string filePath)
        {
            XDocument xmlUsers = XDocument.Load(filePath);
            var usersElement = xmlUsers.Root.Elements();
            List<User> usersList = new List<User>();

            foreach (var user in usersElement)
            {
                var username = user.Element("username").Value;
                var password = user.Element("password").Value;
                var firstName = user.Element("first-name").Value;
                var lastName = user.Element("last-name").Value;
                int age = int.Parse(user.Element("age").Value);
                var gender = user.Element("gender").Value;
                gender = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gender.ToLower());
                User userModel = new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = (Gender)Enum.Parse(typeof(Gender),gender)
                };

                usersList.Add(userModel);
            }
            return usersList;
        }
    }
}
