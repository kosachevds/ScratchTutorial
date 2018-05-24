using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ScratchTutorial
{
    public class XmlLesson : ILessonReader
    {
        const string Extension = ".xml";

        public XmlLesson()
        {
            //this.testCount = 0;
        }

        public string ReadDescription(string lessonPath)
        {
            lessonPath = LessonPath(lessonPath);
            using (var reader = new XmlTextReader(lessonPath))
            {
                // TODO: checks
                reader.MoveToContent();
                reader.ReadToDescendant("title");
                var title = reader.ReadString();
                reader.ReadToNextSibling("description");
                var description = reader.ReadString();
                return String.Format("{0}\n{1}", title, description);
            }
        }

        public Lesson ReadLesson(string lessonPath)
        {
            throw new NotImplementedException();
        }

        public string ReadTitle(string lessonPath)
        {
            lessonPath = LessonPath(lessonPath);
            var name = Path.GetFileName(lessonPath).ToLower();
            return name.Substring(0, name.Length - Extension.Length + 1);
        }

        public string LessonPath(string path)
        {
            // TODO: remade
            if (Directory.Exists(path))
            {
                path = Directory.EnumerateFiles(path).FirstOrDefault(x => x.EndsWith(".xml"));
            }
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            if (!path.EndsWith(Extension))
                throw new Exception("Ожидался файл XML");
            return path;
        }
    }
}
