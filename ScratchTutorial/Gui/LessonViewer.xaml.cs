using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            var hint = this.lesson.CurrentHint;
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
            // TODO: add Hint
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
    }
}
