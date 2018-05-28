using System.Windows;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for Authentication.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        private IAuthenticator authenticator;

        public AuthenticationWindow(IAuthenticator authenticator)
        {
            InitializeComponent();
            this.authenticator = authenticator;
            #if (DEBUG)
            this.tbLogin.Text = "username";
            this.pbPassword.Password = "password";
            #endif
        }

        public string Username => authenticator.Username;

        private void Login(object sender, RoutedEventArgs e)
        {
            if (authenticator.DataIsRight(this.tbLogin.Text, this.pbPassword.Password))
            {
                Close();
            } 
            else
            {
                ErrorBox.Show(Properties.Resources.ErrorUserData);
            }
        }
    }
}
