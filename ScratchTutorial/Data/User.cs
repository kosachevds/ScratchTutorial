using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ScratchTutorial.Data
{
    public class User
    {
        private const string Space = " ";

        [Key]
        public string Username { get; set; }

        public string Password { get; set; }

        public static string PrepareUsername(string username)
        {
            return username.ToLower().Replace(Space, String.Empty);
        }

        public static string PreparePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            return String.Join(String.Empty, hashBytes.Select(b => Convert.ToString(b, 16)));
        }
    }
}
