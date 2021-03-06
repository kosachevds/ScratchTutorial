﻿using System;
using System.Windows;
using MahApps.Metro.Controls;
using AppResources = ScratchTutorial.Properties.Resources;

namespace ScratchTutorial.Gui
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class RegistrationWindow : MetroWindow
    {
        private IRegistrator registrator;

        public RegistrationWindow(IRegistrator registrator)
        {
            InitializeComponent();
            this.registrator = registrator;
        }

        public string Username => registrator.Username;

        private void Registrate(object sender, RoutedEventArgs e)
        {
            if (!this.pbPassword.Password.Equals(this.pbPasswordRepeat.Password))
            {
                ErrorBox.Show(AppResources.ErrorPasswords);
                return;
            }
            try
            {
                this.registrator.Registrate(this.tbLogin.Text, this.pbPassword.Password);
            }
            catch (RegistrationException exc)
            {
                ErrorBox.Show(exc.Message);
                return;
            }
            MessageBox.Show(AppResources.SuccessRegistration, String.Empty, MessageBoxButton.OK,
                            MessageBoxImage.Information);
            Close();
        }
    }
}
