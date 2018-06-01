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
            var bm = new BitmapImage(new Uri(fullpath));
            this.image.Source = bm;
            this.Height = bm.PixelHeight + 10;
            this.Width = bm.PixelWidth + 10;
    
            // TODO dynamic resize on init
        }
    }
}
