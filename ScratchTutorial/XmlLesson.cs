using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchTutorial
{
    public class XmlLesson : ILessonReader
    {
        const string Extension = ".xml";
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
            if (!File.Exists(lessonPath))
                throw new FileNotFoundException(lessonPath);
            var name = Path.GetFileName(lessonPath).ToLower();
            if (!name.EndsWith(Extension))
                throw new Exception("Ожидался файл XML");
            return name.Substring(0, name.Length - Extension.Length + 1);
        }
    }
}
