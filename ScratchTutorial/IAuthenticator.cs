namespace ScratchTutorial
{
    public interface IAuthenticator
    {
        bool DataIsRight(string username, string password);
    }
}
