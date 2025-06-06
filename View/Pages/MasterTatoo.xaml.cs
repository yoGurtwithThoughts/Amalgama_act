﻿using System;
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
using System.Windows.Threading;
using static Amalgama.Core.Navigation;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MasterTatoo.xaml
    /// </summary>
    public partial class MasterTatoo : Page
    {
        private DispatcherTimer _textTimer;
        private int _currentIndex;
        private int _currentParagraphIndex;
        private TextBlock[] _textBlocksTitle;
        private TextBlock[] _textBlocksTitle2;
        private TextBlock[] _textBlocks; // Массив для хранения всех TextBlock
        private (string Text, bool IsBold)[][] _paragraphs;
        private (string Text, bool IsBold)[][] _paragraphstitle;
        private (string Text, bool IsBold)[][] _paragraphstitle2;

        string[] imagePaths =
           {
        "/Images/MastersPersonalDate/TatooWorks/1.png",
        "/Images/MastersPersonalDate/TatooweWorks/2.png",
        "/Images/MastersPersonalDate/TatooWorks/3.png",
        "/Images/MastersPersonalDate/TatooWorks/4.png",
        "/Images/MastersPersonalDate/TatooWorks/5.png",
        "/Images/MastersPersonalDate/TatooWorks/6.png",
        "/Images/MastersPersonalDate/TatooWorks/7.png",
        "/Images/MastersPersonalDate/TatooWorks/8.png",
        "/Images/MastersPersonalDate/TatooWorks/9.png",
        "/Images/MastersPersonalDate/TatooWorks/10.png",
        "/Images/MastersPersonalDate/TatooWorks/11.png",
        "/Images/MastersPersonalDate/TatooWorks/12.png"
    };
        public MasterTatoo()
        {
            InitializeComponent();

            InitializeTextBlocksAndParagraphs();
            StartTypingAnimation(0);
            AnimateButtonGrid();
            AnimateImage();
            LoadGallery();
        }

        private void InitializeTextBlocksAndParagraphs()
        {
            // Связываем TextBlock'и с их параграфами
            _textBlocks = new TextBlock[] { TxtWrite };
            _textBlocksTitle = new TextBlock[] { TxtWriteTitle };

            // Инициализируем заголовок
            _paragraphstitle = new (string Text, bool IsBold)[][]
            {
        new (string, bool)[]
        {
            ("\n\t\tтату", false)
        }
            };

            // Инициализируем заголовок "Плюсы"
            _paragraphstitle2 = new (string Text, bool IsBold)[][]
            {
        new (string, bool)[]
        {
            ("\n\t\tПлюсы", false)
        }
            };

            // Инициализируем основной текст
            _paragraphs = new (string Text, bool IsBold)[][]
            {
        new (string, bool)[]
        {
            ("\nТату-мастер с опытом более 3х лет в создании " +
             "уникальных и качественных татуировок. Обладаю" +
             "высоким уровнем художественного мастерства и" +
             "вниманием к деталям, что позволяет мне создавать локаничные и актуальные дизайны  в соответствии с пожеланиями клиентов.", false)
        }
            };

            // Применяем текст к элементам интерфейса
            ApplyTextToTextBlocks();
        }

        private void ApplyTextToTextBlocks()
        {
            // Применяем заголовок
            foreach (var paragraph in _paragraphstitle)
            {
                foreach (var (text, isBold) in paragraph)
                {
                    TxtWriteTitle.Inlines.Add(new Run(text)
                    {
                        FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal
                    });
                }
            }

            // Применяем заголовок "Плюсы" в TxtPluses
            foreach (var paragraph in _paragraphstitle2)
            {
                foreach (var (text, isBold) in paragraph)
                {
                    TxtWriteTitle2.Inlines.Add(new Run(text)
                    {
                        FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal
                    });
                }
            }

            // Применяем основной текст
            foreach (var paragraph in _paragraphs)
            {
                foreach (var (text, isBold) in paragraph)
                {
                    TxtWrite.Inlines.Add(new Run(text)
                    {
                        FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal
                    });
                }
            }
        }
        private void AnimateImage()
        {
            // Создаем анимацию для изменения прозрачности (Opacity)
            var fadeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new PowerEase { Power = 3 }
            };

            // Создаем анимацию для смещения по оси X
            var translateAnimation = new DoubleAnimation
            {
                From = -150,
                To = 0,
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            // Убеждаемся, что RenderTransform является TranslateTransform
            if (!(AnimatedBack.RenderTransform is TranslateTransform))
            {
                AnimatedBack.RenderTransform = new TranslateTransform();
            }

            // Применяем анимации к элементу AnimatedBack
            Storyboard.SetTarget(fadeAnimation, AnimatedBack);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(UIElement.OpacityProperty));

            Storyboard.SetTarget(translateAnimation, AnimatedBack);
            Storyboard.SetTargetProperty(translateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            // Если нужно также анимировать ImgAnimated, создаем отдельные анимации
            if (ImgAnimated != null)
            {
                if (!(ImgAnimated.RenderTransform is TranslateTransform))
                {
                    ImgAnimated.RenderTransform = new TranslateTransform();
                }

                var fadeAnimationForImg = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new PowerEase { Power = 3 }
                };

                var translateAnimationForImg = new DoubleAnimation
                {
                    From = -150,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(1),
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                };

                Storyboard.SetTarget(fadeAnimationForImg, ImgAnimated);
                Storyboard.SetTargetProperty(fadeAnimationForImg, new PropertyPath(UIElement.OpacityProperty));

                Storyboard.SetTarget(translateAnimationForImg, ImgAnimated);
                Storyboard.SetTargetProperty(translateAnimationForImg, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

                // Добавляем анимации для ImgAnimated в Storyboard
                var storyboard = new Storyboard();
                storyboard.Children.Add(fadeAnimation);
                storyboard.Children.Add(translateAnimation);
                storyboard.Children.Add(fadeAnimationForImg);
                storyboard.Children.Add(translateAnimationForImg);

                storyboard.Begin();
            }
            else
            {
                // Если ImgAnimated отсутствует, запускаем анимацию только для AnimatedBack
                var storyboard = new Storyboard();
                storyboard.Children.Add(fadeAnimation);
                storyboard.Children.Add(translateAnimation);
                storyboard.Begin();
            }
        }

        private void StartTypingAnimation(int index)
        {
            if (index >= _textBlocks.Length) return;

            _currentIndex = 0;
            _currentParagraphIndex = 0;
            _textBlocks[index].Inlines.Clear();

            _textTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1)
            };
            _textTimer.Tick += (sender, e) => TextTimer_Tick(sender, e, index);
            _textTimer.Start();
        }

        private void TextTimer_Tick(object sender, EventArgs e, int index)
        {
            if (_currentParagraphIndex < _paragraphs[index].Length)
            {
                var (text, isBold) = _paragraphs[index][_currentParagraphIndex];

                if (_currentIndex < text.Length)
                {
                    char currentChar = text[_currentIndex];
                    var run = new Run(currentChar.ToString())
                    {
                        FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal
                    };
                    _textBlocks[index].Inlines.Add(run);
                    _currentIndex++;
                }
                else
                {
                    _currentIndex = 0;
                    _currentParagraphIndex++;
                    _textBlocks[index].Inlines.Add(new LineBreak()); // Перенос строки
                }
            }
            else
            {
                _textTimer.Stop();
                StartTypingAnimation(index + 1); // Переход к следующему TextBlock
            }
        }
        private void AnimateButtonGrid()
        {
            var translateAnimation = new DoubleAnimation
            {
                From = 50,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.7),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };


            var opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.7),
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };


            var transform = (TranslateTransform)AnimatedBRD.RenderTransform;
            transform.BeginAnimation(TranslateTransform.YProperty, translateAnimation);
            AnimatedBRD.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
        }
        private void Closer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ArrowBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new MastersPage());
        }

        private void RecButtom_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new RecordPage());
        }
        private void LoadGallery()
        {

            int columns = 4;
            int rows = (int)Math.Ceiling((double)imagePaths.Length / columns);

            GalleryGrid.Columns = columns;
            GalleryGrid.Rows = rows;

            foreach (var path in imagePaths)
            {
                var image = new Image
                {
                    Source = new BitmapImage(new Uri(path, UriKind.Relative)),
                    Stretch = Stretch.UniformToFill,
                    Width = 250,
                    Height = 250,
                    Margin = new Thickness(2),
                    Style = (Style)FindResource("PfotoContainer"),
                    Tag = path  // Сохраняем путь в Tag
                };

                // Добавляем обработчик клика
                image.MouseLeftButtonDown += Image_Click;

                GalleryGrid.Children.Add(image);
            }

        }
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            // Проверяем, что sender действительно является Image
            if (sender is Image image && image.Tag is string imagePath)
            {
                // Получаем индекс текущего изображения в массиве imagePaths
                int currentIndex = Array.IndexOf(imagePaths, imagePath);

                // Проверяем, что индекс найден
                if (currentIndex != -1)
                {
                    // Создаем экземпляр PhotoViewWindow и передаем массив изображений и индекс
                    var viewer = new PhotoViewWindow(imagePaths, currentIndex);
                    viewer.ShowDialog(); // Показываем окно
                }
                else
                {
                    MessageBox.Show("Ошибка: изображение не найдено в массиве.");
                }
            }
            else
            {
                MessageBox.Show("Ошибка: невозможно открыть изображение.");
            }
        }
    }
}
