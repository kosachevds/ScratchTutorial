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
            this.SingleAnswer = (answers.Count(x => x.Value) == 1);
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

        public bool IsRight(params string[] answers)
        {
            if (this.answers.Count(x => x.Value) != answers.Length)
                return false;
            return answers.All(a => this.answers.ContainsKey(a) && this.answers[a]);
        }
    }
}
