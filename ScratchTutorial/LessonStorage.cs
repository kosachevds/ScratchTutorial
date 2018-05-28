using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ScratchTutorial
{
    public class LessonStorage : Storage
    {
        private Dictionary<string, Lesson> lessons;

        public LessonStorage(string path, ILessonReader reader, string username) 
            : base(path, reader, username)
        {
            this.lessons = new Dictionary<string, Lesson>();
            CurrentLesson = null;
        }

        public Lesson CurrentLesson { get; private set; }

        public override Window CreateViewer()
        {
            return new Gui.LessonViewer(this.CurrentLesson);
        }

        public override void Load(string title)
        { 
            if (this.lessons.ContainsKey(title))
            {
                this.CurrentLesson = this.lessons[title];
                this.CurrentTitle = title;
                return;
            }
            Lesson lesson = null;
            foreach (var lessonDir in Directory.GetDirectories(this.Path))
            {
                if (this.Reader.ReadTitle(lessonDir).Equals(title))
                {
                    lesson = ((ILessonReader)this.Reader).ReadLesson(lessonDir);
                    break;
                }
            }
            if (lesson == null)
            {
                throw new ArgumentException("Invalid lesson's title");
            }
            this.lessons.Add(title, lesson);
            this.CurrentLesson = this.lessons[title];
            this.CurrentTitle = title;
        }

        public override void StoreToDB(TimeSpan span)
        {
            if (!this.CurrentLesson.IsLast)
                return;
            using (var db = new Data.TutorialData())
            {
                db.LessonHistory.Add(new Data.LessonStatistic
                {
                    Time = span,
                    Title = this.CurrentTitle,
                    Username = this.Username
                });
                db.SaveChanges();
            }
        }
    }
}
