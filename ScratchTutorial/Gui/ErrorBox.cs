using ScratchTutorial.Properties;
using System.Windows;

namespace ScratchTutorial.Gui
{
    static class ErrorBox
    {
        public static void Show(string message)
        {
            MessageBox.Show(message, Resources.Error, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
