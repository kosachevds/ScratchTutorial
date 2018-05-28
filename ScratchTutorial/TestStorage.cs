using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace ScratchTutorial
{
    public class TestStorage : Storage
    {
        private Dictionary<string, Testing> tests;

        public TestStorage(string path, ITestReader reader, string username) 
            : base(path, reader, username)
        {
            this.tests = new Dictionary<string, Testing>();
            this.CurrentTest = null;
        }

        public Testing CurrentTest { get; private set; }

        public override Window CreateViewer()
        {
            return new Gui.TestViewer(this.CurrentTest);
        }

        public override void Load(string title)
        {
            if (this.tests.ContainsKey(title))
            {
                this.CurrentTest = this.tests[title];
                this.CurrentTitle = title;
                return;
            }
            var testpath = Directory.GetDirectories(this.Path)
                                    .FirstOrDefault(x => this.Reader.ReadTitle(x).Equals(title));
            if (testpath == null)
                throw new ArgumentException("Invalid test's title");
            this.CurrentTest = ((ITestReader)this.Reader).ReadTest(testpath);
            this.tests.Add(title, this.CurrentTest);
            this.CurrentTitle = title;
        }

        public override void StoreToDB(TimeSpan span)
        {
            if (!this.CurrentTest.IsLast)
                return;
            using (var db = new Data.TutorialData())
            {
                db.TestHistory.Add(new Data.TestStatistic
                {
                    Time = span,
                    Title = this.CurrentTitle,
                    Username = this.Username,
                    RightCount = this.CurrentTest.QuestionsCount - this.CurrentTest.WrongCount,
                    Amount = this.CurrentTest.QuestionsCount
                });
                db.SaveChanges();
            }
        }
    }
}
