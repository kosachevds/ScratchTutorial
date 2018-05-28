using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ScratchTutorial
{
    public class XmlLesson : XmlHeaderReader, ILessonReader
    {
        private const string TagPage = "page";
        private const string TagLesson = "lesson";

        private const string AttributeHint = "hint";
        private const string AttributeImage = "image";
        
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
    }
}
