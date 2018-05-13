using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchTutorial
{
    public class XmlLesson : ILessonReader
    {
        private int testCount;

        public XmlLesson()
        {
            this.testCount = 0;
        }

        public string ReadDescription(string lessonPath)
        {
            ++this.testCount;
            return "Тестовое описание. Обращение #" + this.testCount;
        }

        public Lesson ReadLesson(string lessonPath)
        {
            throw new NotImplementedException();
        }

        public string ReadTitle(string lessonPath)
        {
            ++this.testCount;
            return "Тестовый заголовок. Обращение #" + this.testCount;
        }
    }
}
