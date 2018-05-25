namespace ScratchTutorial
{
    public interface ILessonReader : IHeaderReader
    {
        Lesson ReadLesson(string lessonPath);
    }
}
