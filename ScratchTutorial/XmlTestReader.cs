using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScratchTutorial
{
    public class XmlTestReader : XmlHeaderReader, ITestReader
    {
        private const string TagTest = "test";
        private const string TagQuestion = "question";
        private const string TagAnswer = "answer";

        private string AttributeText = "text";
        private string AttributeRight = "is_right";

        public Testing ReadTest(string path)
        {
            var questions = new List<Question>();
            var doc = XDocument.Load(PathToFile(path));
            foreach (var item in doc.Element(TagTest).Elements(TagQuestion))
            {
                var text = item.Attribute(AttributeText)?.Value;
                if (text == null)
                    throw new ArgumentException("Вопрос не содержит аттрибут \"text\"");
                var answers = new Dictionary<string, bool>();
                foreach (var answer in item.Elements(TagAnswer))
                {
                    answers.Add(answer.Value, answer.Attribute(AttributeRight) != null);
                }
                questions.Add(new Question(text, answers));
            }
            return new Testing(questions.ToArray());
        }
    }
}
