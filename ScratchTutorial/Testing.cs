using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchTutorial
{
    public class Testing
    {
        private Question[] questions;
        private uint wrongCount;
        private uint index;

        public Testing(Question[] questions)
        {
            this.questions = questions;
            this.Reset();
        }

        public Question Current => this.questions[this.index];

        public bool IsLast => (this.index == this.questions.Length - 1);

        public bool IsFirst => (this.index == 0u);

        public void Reset()
        {
            this.index = 0u;
            this.wrongCount = 0u;
            this.questions.Shuffle();
        }

        public bool ToNext()
        {
            if (this.IsLast)
                return false;
            ++this.index;
            return true;
        }

        public bool ToPrevious()
        {
            if (this.IsFirst)
                return false;
            --this.index;
            return false;
        }
    }
}
