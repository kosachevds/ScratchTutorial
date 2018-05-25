using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ScratchTutorial
{
    public class LessonStorage : Storage
    {
        private Dictionary<string, Lesson> lessons;

        public LessonStorage(string path, ILessonReader reader) : base(path, reader)
        {
            this.lessons = new Dictionary<string, Lesson>();
            CurrentLesson = null;
        }

        public Lesson CurrentLesson { get; private set; }

        public override Window Load(string title)
        {
            throw new NotImplementedException();
        }

        public Lesson LoadLesson(string title)
        {
            if (this.lessons.ContainsKey(title))
                return CurrentLesson = this.lessons[title];
            var reader = (ILessonReader)this.Reader;
            Lesson lesson = null;
            foreach (var lessonDir in Directory.GetDirectories(this.Path))
            {
                if (this.Reader.ReadTitle(lessonDir).Equals(title))
                {
                    lesson = reader.ReadLesson(lessonDir);
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
