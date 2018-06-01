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
        private List<ToggleButton> answerButtons;

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
            this.answerButtons = LoadAnswers(currentAnswers, current.SingleAnswer);
            foreach (var item in this.answerButtons)
            {
                item.Checked += (_, __) => { if (!btnOk.IsEnabled) btnOk.IsEnabled = true; };
                this.spAnswers.Children.Add(item);
            }
        }

        private static List<ToggleButton> LoadAnswers(string[] textAnswers, bool singleAnswer)
        {
            var answers = new List<ToggleButton>();
            foreach (var answer in textAnswers)
            {
                ToggleButton button;
                if (singleAnswer)
                {
                    button = new RadioButton { GroupName = "answers" };
                }
                else
                {
                    button = new CheckBox();
                }
                button.Content = answer;
                button.FontSize = 13;
                button.Margin = new Thickness(0, 0, 0, 5);
                answers.Add(button);
            }
            return answers;
        }
        
        private void Answer(object sender, RoutedEventArgs e)
        {
            this.test.Answer(this.answerButtons
                                 .Where(x => (bool)x.IsChecked)
                                 .Select(x => (string)x.Content)
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
            this.tbQuestion.Text = String.Empty;
            this.spAnswers.Children.Clear();
            this.btnOk.Visibility = Visibility.Collapsed;
            this.btnExit.Visibility = Visibility.Visible;
            this.spAnswers.Children.Add(new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 15,
                Text = String.Format(Properties.Resources.TemplateResult,
                                     this.test.QuestionsCount - this.test.WrongCount,
                                     this.test.QuestionsCount)

            });
        }

        private void ExitTest(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
