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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        public MastersPage()
        {
            InitializeComponent();
            Loaded += Page_Loaded;
            MyGrid.Loaded += (sender, args) =>
            {
                DoubleAnimation fadeInAnimation = new DoubleAnimation
                {
                    From = 0, // Начальная прозрачность
                    To = 1,   // Конечная прозрачность
                    Duration = TimeSpan.FromSeconds(1) // Длительность анимации (1 секунда)
                };

                // Запуск анимации
                MyGrid.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
            };
        
        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation imageSlideIn = new DoubleAnimation
            {
                From = -350,
                To = 0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CircleEase { EasingMode = EasingMode.EaseInOut }
            };
            BackgroundImage.RenderTransform.BeginAnimation(TranslateTransform.YProperty, imageSlideIn);

            // Анимация прозрачности изображения
            DoubleAnimation imageFadeIn = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(0.5)
            };
            BackgroundImage.BeginAnimation(UIElement.OpacityProperty, imageFadeIn);

            // Анимация перемещения текста
            DoubleAnimation textSlideIn = new DoubleAnimation
            {
                From = -75,
                To = 0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(1.0),
                EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 2, Springiness = 5 }
            };
            HeaderText.RenderTransform.BeginAnimation(TranslateTransform.YProperty, textSlideIn);

            // Анимация прозрачности текста
            DoubleAnimation textFadeIn = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(1.0)
            };
            HeaderText.BeginAnimation(UIElement.OpacityProperty, textFadeIn);
            DoubleAnimation textSlideIn1 = new DoubleAnimation
            {
                From = -75,
                To = 0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(1.0),
                EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 2, Springiness = 5 }
            };
            Txt1_Line1.RenderTransform.BeginAnimation(TranslateTransform.YProperty, textSlideIn1);

            // Анимация прозрачности текста
            DoubleAnimation textFadeIn1 = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(1.0)
            };
            Txt1_Line1.BeginAnimation(UIElement.OpacityProperty, textFadeIn1);
            DoubleAnimation textSlideIn2 = new DoubleAnimation
            {
                From = -75,
                To = 0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(1.0),
                EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 2, Springiness = 5 }
            };
            Txt1_Line2.RenderTransform.BeginAnimation(TranslateTransform.YProperty, textSlideIn1);

            // Анимация прозрачности текста
            DoubleAnimation textFadeIn2 = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(1.5),
                BeginTime = TimeSpan.FromSeconds(1.0)
            };
            Txt1_Line2.BeginAnimation(UIElement.OpacityProperty, textFadeIn1);

            AnimateImage(MasterTatoo, -350, 0);
            // Анимация для второго изображения
            AnimateImage(MasterDeleteTatoo, -350, 0);
            // Анимация для третьего изображения
            AnimateImage(MasterPirc, -350, 0);
        }

        private void AnimateImage(Image image, double fromY, double toY)
        {
            // Проверяем, является ли RenderTransform TransformGroup
            if (image.RenderTransform is TransformGroup transformGroup)
            {
                // Находим TranslateTransform в TransformGroup
                var translateTransform = transformGroup.Children.OfType<TranslateTransform>().FirstOrDefault();
                if (translateTransform != null)
                {
                    DoubleAnimation slideIn = new DoubleAnimation
                    {
                        From = fromY,
                        To = toY,
                        Duration = TimeSpan.FromSeconds(1.5),
                        BeginTime = TimeSpan.FromSeconds(0.5),
                        EasingFunction = new CircleEase { EasingMode = EasingMode.EaseInOut }
                    };

                    // Применяем анимацию к TranslateTransform
                    translateTransform.BeginAnimation(TranslateTransform.YProperty, slideIn);
                }
            }
            else
            {
                // Если RenderTransform не является TransformGroup, создаем новый TranslateTransform
                var translateTransform = new TranslateTransform { Y = fromY };
                image.RenderTransform = translateTransform;

                DoubleAnimation slideIn = new DoubleAnimation
                {
                    From = fromY,
                    To = toY,
                    Duration = TimeSpan.FromSeconds(1.5),
                    BeginTime = TimeSpan.FromSeconds(0.5),
                    EasingFunction = new CircleEase { EasingMode = EasingMode.EaseInOut }
                };

                // Применяем анимацию к новому TranslateTransform
                translateTransform.BeginAnimation(TranslateTransform.YProperty, slideIn);
            }
        }
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Image image && image.RenderTransform is TransformGroup transformGroup)
            {
                // Находим ScaleTransform в TransformGroup
                var scaleTransform = transformGroup.Children.OfType<ScaleTransform>().FirstOrDefault();
                if (scaleTransform != null)
                {
                    // Анимация увеличения
                    DoubleAnimation scaleUp = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.2,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 1, Springiness = 5 }
                    };
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUp);
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUp);
                }
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Image image && image.RenderTransform is TransformGroup transformGroup)
            {
                // Находим ScaleTransform в TransformGroup
                var scaleTransform = transformGroup.Children.OfType<ScaleTransform>().FirstOrDefault();
                if (scaleTransform != null)
                {
                    // Анимация уменьшения
                    DoubleAnimation scaleDown = new DoubleAnimation
                    {
                        From = 1.2,
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleDown);
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleDown);
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MasterDeleteTatoo_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MasterTatoo_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MasterPirc_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
