using System.IO;
using System.Windows;
using AppResources = ScratchTutorial.Properties.Resources;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for LessonWindow.xaml
    /// </summary>
    public partial class LessonExplorer : Window
    {
        private LessonStorage storage;

        public LessonExplorer()
        {
            InitializeComponent();
            this.storage = LessonStorage.Create(
                Path.GetFullPath(AppResources.PathLessons), new XmlLesson());
            this.lbLessons.ItemsSource = this.storage.Titles;
        }

        private void lbLessons_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.tbDescription.Text = this.storage.GetDescription(
                this.lbLessons.SelectedItem.ToString());
            this.btnOk.IsEnabled = true;
        }

        private void SelectLesson(object sender, RoutedEventArgs e)
        {
            var viewer = new LessonViewer(
                this.storage.LoadLesson(this.lbLessons.SelectedItem.ToString()));
            this.Hide();
            viewer.ShowDialog();
            this.Show();
        }
    }
}
