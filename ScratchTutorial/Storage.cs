using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ScratchTutorial
{
    public abstract class Storage
    {
        private List<string> titles;
        private Dictionary<string, string> descriptions;

        protected Storage(string path, IHeaderReader reader, string username)
        {
            this.Path = path;
            this.Reader = reader;
            this.Username = username;

            this.descriptions = new Dictionary<string, string>();
            this.titles = new List<string>();
            foreach (var item in Directory.GetDirectories(path))
            {
                this.titles.Add(reader.ReadTitle(item));
            }
        }

        protected IHeaderReader Reader { get; private set; }

        protected string Path { get; }

        protected string CurrentTitle { get; set; }

        protected string Username { get; private set; }

        public ReadOnlyCollection<string> Titles => this.titles.AsReadOnly();

        public string GetDescription(string title)
        {
            if (this.descriptions.ContainsKey(title))
                return this.descriptions[title];
            string description = null;
            foreach (var item in Directory.GetDirectories(this.Path))
            {
                if (this.Reader.ReadTitle(item).Equals(title))
                {
                    description = this.Reader.ReadDescription(item);
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

        public abstract void Load(string title);

        public abstract System.Windows.Window CreateViewer();

        public abstract void StoreToDB(TimeSpan span);
    }
}
