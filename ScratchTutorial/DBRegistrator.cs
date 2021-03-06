﻿using System;
using ScratchTutorial.Properties;
using System.Linq;
using System.Text.RegularExpressions;
using ScratchTutorial.Data;

namespace ScratchTutorial
{
    class DBRegistrator : IRegistrator
    {
        private const int MinUsername = 4;
        private const int MinPassword = 8;
        private const string UsernameRegex = @"[a-z0-9_]+$";
        private string username;

        public string Username => username;

        public void Registrate(string username, string password)
        {
            username = User.PrepareUsername(username);
            using (var context = new TutorialData())
            {
                if (!UsernameIsValid(username))
                    throw new RegistrationException(Resources.ErrorUsername);
                if (password.Length < MinPassword)
                    throw new RegistrationException(Resources.ErrorShortPassword);
                if (context.Users.Any(u => u.Username.Equals(username)))
                    throw new RegistrationException(Resources.ErrorAlreadyExists);
                password = User.PreparePassword(password);
                context.Users.Add(new User { Username = username, Password = password });
                context.SaveChanges();
            }
            this.username = username;
        }

        private static bool UsernameIsValid(string username)
        {
            if (username.Length < MinUsername)
                return false;
            if (Char.IsDigit(username.First()))
                return false;
            if (Regex.IsMatch(username, UsernameRegex))
                return true;
            return false;
        }
    }
}
