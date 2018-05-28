﻿using System.Linq;
using ScratchTutorial.Data;

namespace ScratchTutorial
{
    public class DBAuthenticator : IAuthenticator
    {
        public bool DataIsRight(string username, string password)
        {
            username = User.PrepareUsername(username);
            password = User.PreparePassword(password);
            using (var context = new UserContext())
            {
                // TODO: prepare data
                var user = context.Users.FirstOrDefault(u => u.Username.Equals(username));
                if (user == null)
                    return false;
                return user.Password.Equals(password);
            }
        }
    }
}
