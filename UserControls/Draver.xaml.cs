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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amalgama.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Draver.xaml
    /// </summary>
    public partial class Draver : UserControl
    {
        public Draver()
        {
            InitializeComponent();
        }

        private void Servises_Click(object sender, RoutedEventArgs e)
        {
            SetButtonStyles(Servises, Masters, Gallery, Record, Qw);
        }

        private void Masters_Click(object sender, RoutedEventArgs e)
        {
            SetButtonStyles(Masters, Gallery, Record, Servises, Qw);
        }

        private void Gallery_Click(object sender, RoutedEventArgs e)
        {
            SetButtonStyles(Gallery, Record, Servises, Masters, Qw);
        }

        private void Qw_Click(object sender, RoutedEventArgs e)
        {
            SetButtonStyles(Qw, Servises, Masters, Gallery, Record);
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            SetButtonStyles(Record, Qw, Servises, Masters, Gallery);
        }
        private void SetButtonStyles(Button activeButton, Button button2, Button button3, Button button4, Button button5)
        {

            activeButton.Background = new SolidColorBrush(Color.FromRgb(95, 0, 0));
            activeButton.Foreground = new SolidColorBrush(Colors.White);

            button2.Background = new SolidColorBrush(Colors.Transparent);
            button2.Foreground = new SolidColorBrush(Colors.Black);

            button3.Background = new SolidColorBrush(Colors.Transparent);
            button3.Foreground = new SolidColorBrush(Colors.Black);

            button4.Background = new SolidColorBrush(Colors.Transparent);
            button4.Foreground = new SolidColorBrush(Colors.Black);

            button5.Background = new SolidColorBrush(Colors.Transparent);
            button5.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
