using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        private DispatcherTimer _timer;
        public RecordPage()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += Timer_Tick;
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            MessageTextBlock.Visibility = Visibility.Collapsed;
            _timer.Stop();
        }

        private void Imageclosed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AgeAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageTextBlock.Text = "Ваш возраст добавлен!";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();

        }

        private void RecCons_Click(object sender, RoutedEventArgs e)
        {
            RecCons.Background = new SolidColorBrush(Color.FromRgb(135, 0, 0));
            Seance.Background = new SolidColorBrush(Colors.Transparent);
            RecCons.Foreground = new SolidColorBrush(Colors.White);
            Seance.Foreground = new SolidColorBrush(Colors.Black);
            MessageTextBlock.Text = "Вы выбрали запись на консультацию";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void Seance_Click(object sender, RoutedEventArgs e)
        {

            Seance.Background = new SolidColorBrush(Color.FromRgb(95, 0, 0));
            RecCons.Background = new SolidColorBrush(Colors.Transparent);
            RecCons.Foreground = new SolidColorBrush(Colors.Black);
            Seance.Foreground = new SolidColorBrush(Colors.White);
            MessageTextBlock.Text = "Вы выбрали запись на сеанс";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void Tatoo_Click(object sender, RoutedEventArgs e)
        {
            Tatoo.Background = new SolidColorBrush(Color.FromRgb(135, 0, 0));
            Pirc.Background = new SolidColorBrush(Colors.Transparent);
            Remove.Background = new SolidColorBrush(Colors.Transparent);

            Tatoo.Foreground = new SolidColorBrush(Colors.White);
            Pirc.Foreground = new SolidColorBrush(Colors.Black);
            Remove.Foreground = new SolidColorBrush(Colors.Black);
            MessageTextBlock.Text = "Вы выбрали тату";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();

        }

        private void Pirc_Click(object sender, RoutedEventArgs e)
        {
            Pirc.Background = new SolidColorBrush(Color.FromRgb(95, 0, 0));
            Tatoo.Background = new SolidColorBrush(Colors.Transparent);
            Remove.Background = new SolidColorBrush(Colors.Transparent);

            Pirc.Foreground = new SolidColorBrush(Colors.White);
            Tatoo.Foreground = new SolidColorBrush(Colors.Black);
            Remove.Foreground = new SolidColorBrush(Colors.Black);
            MessageTextBlock.Text = "Вы выбрали пирсинг";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Remove.Background = new SolidColorBrush(Color.FromRgb(95, 0, 0));
            Tatoo.Background = new SolidColorBrush(Colors.Transparent);
            Pirc.Background = new SolidColorBrush(Colors.Transparent);

            Remove.Foreground = new SolidColorBrush(Colors.White);
            Pirc.Foreground = new SolidColorBrush(Colors.Black);
            Tatoo.Foreground = new SolidColorBrush(Colors.Black);
            MessageTextBlock.Text = "Вы выбрали сведение татуировки";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();

        }

        private void Txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt.Text) || Txt.Text == "Фамилия имя")
            {
                Txt.Text = string.Empty;
                Txt.Foreground = new SolidColorBrush(Colors.Black);
                Txt.Focus();
                Txt.SelectionStart = Txt.Text.Length;
            }

        }

        private void Txt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt.Text) || Txt.Text == "Номер телефона")
            {
                Txt.Text = string.Empty;
                Txt.Foreground = new SolidColorBrush(Colors.Black);
                Txt.Focus();
                Txt.SelectionStart = Txt.Text.Length;
            }
        }

        private void ColorTatoo_Click(object sender, RoutedEventArgs e)
        {
            ColorTatoo.Background = new SolidColorBrush(Color.FromRgb(135, 0, 0));
            Mono.Background = new SolidColorBrush(Colors.Transparent);
            ColorTatoo.Foreground = new SolidColorBrush(Colors.White);
            Mono.Foreground = new SolidColorBrush(Colors.Black);
            MessageTextBlock.Text = "Вы выбрали цветную тату";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();

        }

        private void Mono_Click(object sender, RoutedEventArgs e)
        {
            Mono.Background = new SolidColorBrush(Color.FromRgb(135, 0, 0));
            ColorTatoo.Background = new SolidColorBrush(Colors.Transparent);
            Mono.Foreground = new SolidColorBrush(Colors.White);
            ColorTatoo.Foreground = new SolidColorBrush(Colors.Black);
            MessageTextBlock.Text = "Вы выбрали ч/б тату";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void Txt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt2.Text) || Txt2.Text == "Номер телефона")
            {
                Txt2.Text = string.Empty;
                Txt2.Foreground = new SolidColorBrush(Colors.Black);
                Txt2.Focus();
                Txt2.SelectionStart = Txt.Text.Length;
            }
        }

        private void MastersSelect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageTextBlock.Text = "Вы выбрали мастра Laura";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void MastersSelect1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageTextBlock.Text = "Вы выбрали мастра Nikita";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void RecSucces_Click(object sender, RoutedEventArgs e)
        {
            MessageTextBlock.Text = "Вы успешно записанны!";
            MessageTextBlock.Visibility = Visibility.Visible;


            _timer.Start();
        }

        private void Txt3_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
       
    }
}
    
    

