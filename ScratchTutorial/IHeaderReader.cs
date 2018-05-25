namespace ScratchTutorial
{
    public interface IHeaderReader
    {
        string ReadTitle(string path);

        string ReadDescription(string path);
    }
}
