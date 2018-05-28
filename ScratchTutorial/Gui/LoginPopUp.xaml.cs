using System.Windows;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for LoginPopUp.xaml
    /// </summary>
    public partial class LoginPopUp : Window
    {
        public LoginPopUp()
        {
            InitializeComponent();
            this.Title = Properties.Resources.TitleLoginPopup;
        }

        public string Username { get; private set; }

        private void Authentication(object sender, RoutedEventArgs e)
        {
            var window = new AuthenticationWindow(new DBAuthenticator());
            ShowDialog(window);
            this.Username = window.Username;
            this.Close();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            var window = new RegistrationWindow(new DBRegistrator());
            ShowDialog(window);
            this.Username = window.Username;
            this.Close();
        }

        private void ShowDialog(Window window)
        {
            window.Owner = this;
            window.ShowDialog();
        }

        private void Run()
        {
            //var storage = new TestStorage(Path.GetFullPath(AppResources.PathTests), new XmlTestReader(), 
            //var storage = new LessonStorage(Path.GetFullPath(AppResources.PathLessons), new XmlLesson(),
            //this.username);
            //new Explorer(storage).Show();
            //History.CreateTestWindow(this.username).Show();
            History.CreateLessonWindow(this.Username).Show();
        }
    }
}
