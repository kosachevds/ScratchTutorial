using System;
using System.Collections.Generic;

namespace ScratchTutorial
{
    public class Lesson
    {
        // TODO: index checks etc.
        private uint index;
        private Paragraph[][] paragraphs;
        private string[] hints;
        private uint count;  // TODO: readonly

        public Lesson(Paragraph[][] paragraphs, string[] hints)
        {
            this.paragraphs = paragraphs;
            this.hints = hints;
            this.index = 0;
            this.count = (uint)paragraphs.Length;
            if (this.count != hints.Length)
                throw new ArgumentException("Numbers of pages and hints aren't same"); // TODO: mb it possible?
        }

        public Lesson(List<List<Paragraph>> paragraphs, List<string> hints)
            : this(ListsToArrays(paragraphs), hints.ToArray()) { }

        // TODO: ReadOnlyCollection
        public Paragraph[] CurrentPage => this.paragraphs[this.index];

        public string CurrentHint => this.hints[this.index];

        public bool IsLast => (this.index == this.count - 1);

        public bool IsFirst => (this.index == 0);

        public bool ToNext()
        {
            if (this.index >= this.count)
                return false;
            ++this.index;
            return true;
        }

        public bool ToPrevious()
        {
            if (this.index <= 0u)
                return false;
            --this.index;
            return true;
        }

        private static Paragraph[][] ListsToArrays(List<List<Paragraph>> lists)
        {
            var arrays = new Paragraph[lists.Count][];
            for (var i = 0; i < lists.Count; ++i)
            {
                arrays[i] = lists[i].ToArray();
            }
            return arrays;
        }
    }
}
