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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog(new AuthenticationWindow(new DBAuthenticator()));
        }

        private void btnRegistrate_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog(new RegistrationWindow(new DBRegistrator()));
        }

        private void ShowDialog(Window window)
        {
            window.Owner = this;
            //window.ShowDialog();
            new Explorer(new LessonStorage(Path.GetFullPath(AppResources.PathLessons), new XmlLesson())).Show();
            //new Explorer(new TestStorage(Path.GetFullPath(AppResources.PathTests), new XmlTestReader())).Show();
        }
    }
}
