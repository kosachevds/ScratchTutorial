﻿using System.IO;
using System.Windows;
using MahApps.Metro.Controls;
using AppResources = ScratchTutorial.Properties.Resources;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string username;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ShowDialog(Window window, bool withHide = true)
        {
            window.Owner = this;
            if (withHide)
                this.Hide();
            window.ShowDialog();
            if (withHide)
                this.Show();
        }
        private void ShowHideWait(Window window)
        {
            window.Owner = this;
                this.Hide();
            window.Closed += (_, __) => this.Show();
            window.Show();
        }
        
        private void OpenPopup(object sender, RoutedEventArgs e)
        {
            this.username = LoginWindow();
            if (this.username == null)
                this.Close();
        }

        private void OpenLessons(object sender, RoutedEventArgs e)
        {
            var storage = new LessonStorage(Path.GetFullPath(AppResources.PathLessons),
                                            new XmlLesson(), this.username);
            ShowHideWait(new Explorer(storage));
        }

        private void OpenTests(object sender, RoutedEventArgs e)
        {
            var storage = new TestStorage(Path.GetFullPath(AppResources.PathTests),
                                          new XmlTestReader(), this.username);
            ShowHideWait(new Explorer(storage));
        }

        private void OpenLessonsHistory(object sender, RoutedEventArgs e)
        {
            ShowDialog(History.CreateLessonWindow(this.username));
        }

        private void OpenTestsHistory(object sender, RoutedEventArgs e)
        {
            ShowDialog(History.CreateTestWindow(this.username));
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            this.username = LoginWindow() ?? this.username;
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string LoginWindow()
        {
            var popup = new LoginPopUp { Owner = this };
            popup.ShowDialog();
            return popup.Username;
        }
    }
}
