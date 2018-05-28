using System.IO;
using System.Windows;
using AppResources = ScratchTutorial.Properties.Resources;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var window = new AuthenticationWindow(new DBAuthenticator());
            ShowDialog(window);
            this.username = window.Username;
        }

        private void btnRegistrate_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegistrationWindow(new DBRegistrator());
            ShowDialog(window);
            this.username = window.Username;
        }

        private void ShowDialog(Window window)
        {
            window.Owner = this;
            window.ShowDialog();
            //new Explorer(new LessonStorage(Path.GetFullPath(AppResources.PathLessons), new XmlLesson())).Show();
            //new Explorer(new TestStorage(Path.GetFullPath(AppResources.PathTests), new XmlTestReader())).Show();
        }
    }
}
