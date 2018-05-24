using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ScratchTutorial
{
    public class XmlLesson : ILessonReader
    {
        private const string Extension = ".xml";
        private const string TagTitle = "title";
        private const string TagDescription = "description";
        private const string TagPage = "page";
        private const string TagLesson = "lesson";

        private const string AttributeHint = "hint";
        private const string AttributeImage = "image";

        public XmlLesson() { }

        public string ReadDescription(string lessonPath)
        {
            lessonPath = PathToFile(lessonPath);
            using (var reader = new XmlTextReader(lessonPath))
            {
                // TODO: checks
                reader.MoveToContent();
                reader.ReadToDescendant(TagTitle);
                var title = reader.ReadString();
                reader.ReadToNextSibling(TagDescription);
                var description = reader.ReadString();
                return String.Format("{0}\n{1}", title, description);
            }
        }

        public Lesson ReadLesson(string lessonPath)
        {
            // TODO: checks etc.
            var filepath = PathToFile(lessonPath);
            var dirpath = Path.GetDirectoryName(filepath);
            var pages = new List<List<Paragraph>>();
            var hints = new List<string>();
            var doc = XDocument.Load(filepath);
            foreach (var page in doc.Element(TagLesson).Elements(TagPage))
            {
                var hint = page.Attribute(AttributeHint)?.Value;
                if (hint != null)
                    hint = Path.Combine(dirpath, hint);
                hints.Add(hint);
                var paragraphs = new List<Paragraph>();
                foreach (var paragraph in page.Elements())
                {
                    var image = paragraph.Attribute(AttributeImage)?.Value;
                    string imagePath = null;
                    if (image != null)
                        imagePath = Path.Combine(dirpath, image);
                    paragraphs.Add(new Paragraph(paragraph.Value, imagePath));
                }
                pages.Add(paragraphs);
            }
            return new Lesson(pages, hints);
        }

        public string ReadTitle(string lessonPath)
        {
            lessonPath = PathToFile(lessonPath);
            return Path.GetFileNameWithoutExtension(lessonPath);
        }

        public string PathToFile(string path)
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
