using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for LessonViewer.xaml
    /// </summary>
    public partial class LessonViewer : Window
    {
        private Lesson lesson;

        public LessonViewer(Lesson lesson)
        {
            InitializeComponent();
            this.lesson = lesson;
            LoadPage();
        }

        private void LoadPage()
        {
            this.lessonView.Children.Clear();
            var page = this.lesson.CurrentPage;
            foreach (var paragraph in this.lesson.CurrentPage)
            {
                this.lessonView.Children.Add(new TextBlock
                {
                    TextWrapping = TextWrapping.Wrap,
                    Text = paragraph.Text
                });
                if (paragraph.Image != null)
                {
                    this.lessonView.Children.Add(new Image
                    {
                        Source = new BitmapImage(new Uri(paragraph.Image))
                    });
                }
            }
            if (this.lesson.CurrentHint != null)
            {
                AddHintButton(this.lessonView, Path.GetFullPath(this.lesson.CurrentHint));
            }
            // TODO: counts percents and write to statistic
            this.btnBack.IsEnabled = !this.lesson.IsFirst;
            this.btnForward.IsEnabled = !this.lesson.IsLast;
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            this.lesson.ToNext();
            LoadPage();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.lesson.ToPrevious();
            LoadPage();
        }

        private static void AddHintButton(StackPanel panel, string path)
        {
            var hintButton = new Button
            {
                Height = 25,
                Width = 65,
                Opacity = 80,
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = "Подсказка"
            };
            hintButton.Click += (_, __) =>
            {
                new HintWindow(path).ShowDialog();
            };
            panel.Children.Add(hintButton);
        }
    }
}
