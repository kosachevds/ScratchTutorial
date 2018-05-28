namespace ScratchTutorial
{
    public interface IRegistrator
    {
        string Username { get; }

        void Registrate(string username, string password);
    }
}
