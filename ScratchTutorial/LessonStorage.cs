using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ScratchTutorial
{
    public class LessonStorage
    {
        private string path;
        private ILessonReader reader;
        private List<string> titles;
        private Dictionary<string, string> descriptions;
        private Dictionary<string, Lesson> lessons;

        private LessonStorage(string path, ILessonReader reader)
        {
            this.reader = reader;
            this.path = path;
            this.titles = new List<string>();
            this.descriptions = new Dictionary<string, string>();
            this.lessons = new Dictionary<string, Lesson>();
            CurrentLesson = null;
        }

        public ReadOnlyCollection<string> Titles { get { return this.titles.AsReadOnly(); } }

        public Lesson CurrentLesson { get; private set; }

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
            if (this.descriptions.ContainsKey(title))
                return this.descriptions[title];
            string description = null;
            foreach (var lesson in Directory.GetDirectories(this.path))
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

        public Lesson LoadLesson(string title)
        {
            if (this.lessons.ContainsKey(title))
                return CurrentLesson = this.lessons[title];
            Lesson lesson = null;
            foreach (var lessonDir in Directory.GetDirectories(this.path))
            {
                if (this.reader.ReadTitle(lessonDir).Equals(title))
                {
                    lesson = this.reader.ReadLesson(lessonDir);
                    break;
                }
            }
            if (lesson == null)
            {
                throw new ArgumentException("Invalid lesson's title");
            }
            this.lessons.Add(title, lesson);
            return CurrentLesson = this.lessons[title];
        }
    }
}
