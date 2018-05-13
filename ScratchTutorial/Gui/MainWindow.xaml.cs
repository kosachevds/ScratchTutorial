using System.Windows;

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
            window.ShowDialog();
            new LessonExplorer().Show();
        }
    }
}
