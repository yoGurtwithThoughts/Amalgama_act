using Amalgama.View.Pages;
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
using static Amalgama.Core.Navigation;

namespace Amalgama.View.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для DataRecForAdmin.xaml
    /// </summary>
    public partial class DataRecForAdmin : Page
    {
        private bool isMenuOpen = false;
        public DataRecForAdmin()
        {
            InitializeComponent();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            DrawerHost.IsRightDrawerOpen = !DrawerHost.IsRightDrawerOpen;
            if (DrawerHost.IsRightDrawerOpen)
            {
                BlurOverlay.Visibility = Visibility.Visible;
                BackgroundBlur.Radius = 25; // Активируем размытие
            }
            else
            {
                BlurOverlay.Visibility = Visibility.Visible;
                BackgroundBlur.Radius = 0; // Активируем размытие
            }
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new StartPage());
        }

        private void Gallery_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new Gallery());
        }

        private void Masters_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new MastersPage());
        }

        private void QW_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new QwestionsPage());
        }
    }
}
