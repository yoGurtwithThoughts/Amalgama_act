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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Amalgama.View.Pages;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using static Amalgama.Core.Navigation;
using static Amalgama.Servis.DBConnection;

namespace Amalgama.View.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminSigIn.xaml
    /// </summary>
    public partial class AdminSigIn : Window
    {
        private bool isPasswordVisible = false;

        public AdminSigIn()
            {
                InitializeComponent();
               
            }

            private void AdminSigIn_Loaded(object sender, RoutedEventArgs e)
            {
                // Отображаем матовый фон при загрузке
                Overlay.Visibility = Visibility.Visible;
            }

            private void Login_TextChanged(object sender, TextChangedEventArgs e)
            {
                // Логика для изменения текста логина (если необходимо)
            }

            private void Password_TextChanged(object sender, RoutedEventArgs e)
            {
                
            }
            private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
            {
                
            }


        private void CloseDialog_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

        //private async Task SignUp_MouseDownAsync(object sender, MouseButtonEventArgs e)
        //{
        //    string username = Login.Text;
        //    string password = Password.Text;

        //    using (var dbContext = new ApplicationDbContext())
        //    {
        //        // Here, we're directly checking the hardcoded credentials.
        //        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Login == username && u.Password == password);

        //        if (user != null)
        //        {
        //            // Navigate to another page on successful login
        //            var nextPage = new DataRecForAdmin(); // Replace DataRecForAdmin with your actual page class
        //            CoreNavigate.NavigatorCore.Navigate(nextPage);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Неверное имя пользователя или пароль.");
        //        }
        //    }
        //}

        private async void SignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string username = Login.Text;
            string password = Password.Text;

            using (var dbContext = new ApplicationDbContext())
            {
                // Check the hardcoded credentials in the database.
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Login == username && u.Password == password);

                if (user != null)
                {
                    // Navigate to another page on successful login
                    var nextPage = new DataRecForAdmin(); // Replace DataRecForAdmin with your actual page class
                    CoreNavigate.NavigatorCore.Navigate(nextPage);
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.");
                }
            }
        }
    }
}
