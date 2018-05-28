using System.Linq;

namespace ScratchTutorial
{
    public class DBAuthenticator : IAuthenticator
    {
        public bool DataIsRight(string username, string password)
        {
            username = UserData.PrepareUsername(username);
            password = UserData.PreparePassword(password);
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
