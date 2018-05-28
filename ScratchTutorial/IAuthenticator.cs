namespace ScratchTutorial
{
    public interface IAuthenticator
    {
        string Username { get; }

        bool DataIsRight(string username, string password);
    }
}
