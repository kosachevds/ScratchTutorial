using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using MahApps.Metro.Controls;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for TestViewer.xaml
    /// </summary>
    public partial class TestViewer : MetroWindow
    {
        private Testing test;
        private Dictionary<string, ToggleButton> answers;

        public TestViewer(Testing test)
        {
            InitializeComponent();
            this.test = test;
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            var current = this.test.Current;
            var currentAnswers = current.Answers;

            this.tbQuestion.Text = current.Text;
            this.answers = LoadAnswers(currentAnswers, current.SingleAnswer);
            foreach (var item in this.answers)
            {
                item.Value.Checked += (_, __) => { if (!btnOk.IsEnabled) btnOk.IsEnabled = true; };
                var panel = new StackPanel { Orientation = Orientation.Horizontal };
                panel.Children.Add(item.Value);
                panel.Children.Add(new TextBlock { Text = item.Key });
                this.spAnswers.Children.Add(panel);
            }
        }

        private static Dictionary<string, ToggleButton> LoadAnswers(string[] textAnswers, bool singleAnswer)
        {
            var answers = new Dictionary<string, ToggleButton>();
            if (singleAnswer)
            {
                foreach (var answer in textAnswers)
                {
                    answers.Add(answer, new RadioButton { GroupName = "answers" });
                }
            }
            else
            {
                foreach (var answer in textAnswers)
                {
                    answers.Add(answer, new CheckBox());
                }
            }
            return answers;
        }
        
        private void Answer(object sender, RoutedEventArgs e)
        {
            this.test.Answer(this.answers
                                 .Where(x => (bool)x.Value.IsChecked)
                                 .Select(x => x.Key)
                                 .ToArray());
            if (!this.test.ToNext())
            {
                EndTesting();
            }
            else
            {
                this.spAnswers.Children.Clear();
                LoadQuestion();
                this.btnOk.IsEnabled = false;
            }
        }

        private void EndTesting()
        {
            this.spAnswers.Children.Clear();
            this.btnOk.Visibility = Visibility.Collapsed;
            this.spAnswers.Children.Add(new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Text = String.Format("Твой результат: {0} правильных ответов из {1}.",
                                     this.test.QuestionsCount - this.test.WrongCount,
                                     this.test.QuestionsCount)

            });
        }
    }
}
