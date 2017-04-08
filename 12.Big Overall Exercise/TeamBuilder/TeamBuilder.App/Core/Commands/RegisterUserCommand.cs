﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class RegisterUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            //ValidateInputLenght
            Check.CheckLength(7, inputArgs);

            string userName = inputArgs[0];

            //ValidateGivenUsername
            if (userName.Length<Constants.MinUsernameLength || userName.Length>Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid,userName));
            }

            string password = inputArgs[1];
            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            string reapeatedPassword =inputArgs[2];
            if (reapeatedPassword!=password)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordDoesNotMatch));
            }

            string firstName = inputArgs[3];
            string lastName = inputArgs[4];

            //AgeValidation
            int age;
            bool isNumber = int.TryParse(inputArgs[5], out age);
            if (!isNumber || age<=0)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.AgeNotValid));
            }

            //Validate Gender
            Gender gender;
            bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);
            if (!isGenderValid)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.GenderNotValid));
            }

            if (CommandHelper.IsUserExisting(userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameIsTaken,userName));
            }

            this.RegisterUser(userName, password, firstName, lastName, age, gender);
            return $"User {userName} was registered successfully!";
        }

        private void RegisterUser(string userName, string password, string firstName, string lastName, int age, Gender gender)
        {
            using(TeamBuilderContext context=new TeamBuilderContext())
            {
                User user = new User()
                {
                    Username = userName,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
