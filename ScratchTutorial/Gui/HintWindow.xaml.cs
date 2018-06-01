using System;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for HintWindow.xaml
    /// </summary>
    public partial class HintWindow : MetroWindow
    {
        public HintWindow(string fullpath)
        {
            InitializeComponent();
            this.image.Source = new BitmapImage(new Uri(fullpath));
        }
    }
}
