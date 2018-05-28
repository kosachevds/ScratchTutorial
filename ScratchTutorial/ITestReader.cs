namespace ScratchTutorial
{
    public interface ITestReader : IHeaderReader
    {
        Testing ReadTest(string path);
    }
}
