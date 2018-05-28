using System.Linq;

namespace ScratchTutorial
{
    public class Testing
    {
        private Question[] questions;
        private uint index;

        public Testing(Question[] questions)
        {
            this.questions = questions;
            this.Reset();
        }

        public int WrongCount { get; private set; }

        public int QuestionsCount => this.questions.Length;

        public Question Current => this.questions[this.index];

        public bool IsLast => (this.index == this.questions.Length - 1);

        public bool IsFirst => (this.index == 0u);

        public void Reset()
        {
            this.index = 0u;
            this.WrongCount = 0;
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

        public bool Answer(params string[] answers)
        {
            var isRight = this.Current.IsRight(answers);
            if (!isRight)
                ++this.WrongCount;
            return isRight;
        }
    }
}
