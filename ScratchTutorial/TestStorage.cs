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


        public TestStorage(string path, ITestReader reader) : base(path, reader)
        {
            this.tests = new Dictionary<string, Testing>();
            this.CurrentTest = null;
        }

        public Testing CurrentTest { get; private set; }

        public override Window Load(string title)
        {
            if (this.tests.ContainsKey(title))
            {
                this.CurrentTest = this.tests[title];
                return new Gui.TestViewer(this.CurrentTest);
            }
            var testpath = Directory.GetDirectories(this.Path)
                                    .FirstOrDefault(x => this.Reader.ReadTitle(x).Equals(title));
            if (testpath == null)
                throw new ArgumentException("Invalid test's title");
            this.CurrentTest = ((ITestReader)this.Reader).ReadTest(testpath);
            this.tests.Add(title, this.CurrentTest);
            return new Gui.TestViewer(this.CurrentTest);
        }
    }
}
