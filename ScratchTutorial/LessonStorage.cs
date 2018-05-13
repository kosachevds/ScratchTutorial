using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchTutorial
{
    public class LessonStorage
    {
        private string path;
        private ILessonReader reader;
        private List<string> titles;
        private Dictionary<string, string> descriptions;

        private LessonStorage(string path, ILessonReader reader)
        {
            this.reader = reader;
            this.path = path;
            this.titles = new List<string>();
            this.descriptions = new Dictionary<string, string>();
        }

        public ReadOnlyCollection<string> Titles { get { return this.titles.AsReadOnly(); } }

        public static LessonStorage Create(string path, ILessonReader reader)
        {
            var storage = new LessonStorage(path, reader);
            foreach (var lesson in Directory.GetDirectories(path))
            {
                storage.titles.Add(reader.ReadTitle(lesson));
            }
            return storage;
        }

        public string GetDescription(string title)
        {
            if (this.descriptions.Keys.Contains(title))
                return this.descriptions[title];
            string description = null;
            foreach (var lesson in Directory.GetDirectories(path))
            {
                if (this.reader.ReadTitle(lesson).Equals(title))
                {
                    description = this.reader.ReadDescription(lesson);
                    break;
                }
            }
            if (description == null)
            {
                throw new ArgumentException("Invalid lesson's title");
            }
            this.descriptions.Add(title, description);
            return description;
        }
    }
}
