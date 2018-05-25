using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchTutorial
{
    public class Question
    {
        private static Random random = new Random();
        private Dictionary<string, bool> answers;

        public Question(string text, Dictionary<string, bool> answers)
        {
            this.answers = answers;
            this.Text = text;
        }

        public string Text { get; }

        public bool SingleAnswer { get; }

        // TODO: ReadOnlyCollection
        public string[] Answers
        {
            get
            {
                var result = this.answers.Keys.ToArray();
                result.Shuffle();
                return result;
            }
        }

        public bool IsRight(string answer)
        {
            if (!this.answers.ContainsKey(answer))
                return false;
            return this.answers[answer];
        }

    }
}
