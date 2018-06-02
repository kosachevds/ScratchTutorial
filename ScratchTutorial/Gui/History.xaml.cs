using System.Linq;
using MahApps.Metro.Controls;
using System.Windows.Documents;
using DocParagraph = System.Windows.Documents.Paragraph;
using System.Windows;

namespace ScratchTutorial.Gui
{
    public partial class History : MetroWindow
    {

        private History()
        {
            InitializeComponent();
        }

        public static History CreateTestWindow(string username)
        {
            var window = new History { Width = 600 };
            Data.TestStatistic[] lines;
            using (var db = new Data.TutorialData())
            {
                lines = db.TestHistory.Where(l => l.Username.Equals(username)).ToArray();
            }
            window.tableLessons.Visibility = Visibility.Collapsed;
            window.tableTests.ItemsSource = lines;
            return window;
        }

        public static History CreateLessonWindow(string username)
        {
            var window = new History { Width = 380 };
            Data.LessonStatistic[] lines;
            using (var db = new Data.TutorialData())
            {
                lines = db.LessonHistory.Where(l => l.Username.Equals(username)).ToArray();
            }
            window.tableTests.Visibility = Visibility.Collapsed;
            window.tableLessons.ItemsSource = lines;
            return window;
        }

        private static void AddCell(TableRow row, string text)
        {
            row.Cells.Add(new TableCell(new DocParagraph(new Run(text))));
        }
    }
}
