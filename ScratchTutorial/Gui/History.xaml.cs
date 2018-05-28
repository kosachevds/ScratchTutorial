using System.Linq;
using System.Windows;

namespace ScratchTutorial.Gui
{
    public partial class History : Window
    {
        private History()
        {
            InitializeComponent();
        }

        public static History CreateTestWindow(string username)
        {
            var window = new History();
            Data.TestStatistic[] lines;
            using (var db = new Data.TutorialData())
            {
                lines = db.TestHistory.Where(l => l.Username.Equals(username)).ToArray();
            }
            window.table.ItemsSource = lines;
            return window;
        }

        public static History CreateLessonWindow(string username)
        {
            var window = new History();
            Data.LessonStatistic[] lines;
            using (var db = new Data.TutorialData())
            {
                lines = db.LessonHistory.Where(l => l.Username.Equals(username)).ToArray();
            }
            window.table.ItemsSource = lines;
            return window;
        }
    }
}
