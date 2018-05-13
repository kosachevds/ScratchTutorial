namespace ScratchTutorial
{
    public interface ILessonReader
    {
        string ReadTitle(string lessonPath);
        string ReadDescription(string lessonPath);
        Lesson ReadLesson(string lessonPath);
    }
}
