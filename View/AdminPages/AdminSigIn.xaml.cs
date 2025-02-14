using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace Amalgama.View.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminSigIn.xaml
    /// </summary>
    public partial class AdminSigIn : Window
    {
        private bool _isPasswordVisible = false;
        public AdminSigIn()
        {
            InitializeComponent();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isPasswordVisible)
            {
                Password.Text = new string('*', Password.Tag.ToString().Length);
                (TogglePasswordButton.Content as PackIcon).Kind = PackIconKind.Eye; 
            }
            else
            {
                Password.Text = Password.Tag?.ToString() ?? "";
                (TogglePasswordButton.Content as PackIcon).Kind = PackIconKind.EyeOff; 
            }

            _isPasswordVisible = !_isPasswordVisible;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.Tag = Password.Text;

            if (!string.IsNullOrEmpty(Password.Text))
            {
                TogglePasswordButton.Visibility = Visibility.Visible;

                if (!_isPasswordVisible)
                {
                    Password.Text = new string('*', Password.Text.Length);
                }
            }
            else
            {
                TogglePasswordButton.Visibility = Visibility.Collapsed;
                _isPasswordVisible = false; 

                (TogglePasswordButton.Content as PackIcon).Kind = PackIconKind.Eye;
            }
        }

        private void CloseDialog_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void TogglePasswordButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
