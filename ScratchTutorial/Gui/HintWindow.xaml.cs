using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for HintWindow.xaml
    /// </summary>
    public partial class HintWindow : Window
    {
        public HintWindow(string fullpath)
        {
            InitializeComponent();
            this.image.Source = new BitmapImage(new Uri(fullpath));
        }
    }
}
