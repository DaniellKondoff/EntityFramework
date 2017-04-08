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
    public class DeleteUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            using(TeamBuilderContext context=new TeamBuilderContext())
            {
                currentUser = context.Users.Attach(AuthenticationManager.GetCurrentUser());
                currentUser.IsDeleted = true;
                context.SaveChanges();

                AuthenticationManager.Logout();
            }
            return $"User {currentUser.Username} was deleted successfully";
        }
    }
}
