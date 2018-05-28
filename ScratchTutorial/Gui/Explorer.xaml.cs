using System.Windows;
using System.Windows.Controls;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
        private Storage storage;

        public Explorer(Storage storage)
        {
            InitializeComponent();
            this.storage = storage;
            this.lbTitles.ItemsSource = this.storage.Titles;
        }

        private void TitleChanged(object sender, SelectionChangedEventArgs e)
        {
            this.tbDescription.Text = this.storage.GetDescription(
                this.lbTitles.SelectedItem.ToString());
            this.btnOk.IsEnabled = true;
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            var viewer = this.storage.Load(this.lbTitles.SelectedItem.ToString());
            this.Hide();
            viewer.ShowDialog();
            this.Show();
        }
    }
}
