﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MasterPirs.xaml
    /// </summary>
    public partial class MasterPirs : Page
    {
        private bool _isAdmin;
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
                "/Images/MastersPersonalDate/PirsWorks/1.png",
                "/Images/MastersPersonalDate/PirsWorks/2.png",
                 "/Images/MastersPersonalDate/PirsWorks/3.png",
                 "/Images/MastersPersonalDate/PirsWorks/4.png",
                 "/Images/MastersPersonalDate/PirsWorks/5.png",
                 "/Images/MastersPersonalDate/PirsWorks/6.png",
                 "/Images/MastersPersonalDate/PirsWorks/7.png",
                 "/Images/MastersPersonalDate/PirsWorks/8.png",
                 "/Images/MastersPersonalDate/PirsWorks/9.png", 
                 "/Images/MastersPersonalDate/PirsWorks/10.png",
                 "/Images/MastersPersonalDate/PirsWorks/11.png",
                 "/Images/MastersPersonalDate/PirsWorks/12.png",
                 "/Images/MastersPersonalDate/PirsWorks/13.png",
                 "/Images/MastersPersonalDate/PirsWorks/14.png",
                 "/Images/MastersPersonalDate/PirsWorks/15.png",
                 "/Images/MastersPersonalDate/PirsWorks/16.png",
                 "/Images/MastersPersonalDate/PirsWorks/17.png",
                 "/Images/MastersPersonalDate/PirsWorks/18.png",
                 "/Images/MastersPersonalDate/PirsWorks/19.png",
                 "/Images/MastersPersonalDate/PirsWorks/20.png",
                 "/Images/MastersPersonalDate/PirsWorks/21.png",
                 "/Images/MastersPersonalDate/PirsWorks/22.png",
                 "/Images/MastersPersonalDate/PirsWorks/23.png",
                 "/Images/MastersPersonalDate/PirsWorks/24.png",
                 "/Images/MastersPersonalDate/PirsWorks/25.png",
                 "/Images/MastersPersonalDate/PirsWorks/26.png",

    };
        public MasterPirs()
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
            ("\n\t\tПирсинг", false)
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
            ("\nМастер пирсинга с опытом более 2 лет, " +
             "специализирующийся на выполнении различных видов пирсинга, " +
             "включая пирсинг ушей, носа, бровей, языка и других частей тела. " +
             "Обладаю хорошим уровнем квалификации и вниманием к деталям, " +
             "что позволяет мне оказывать безопасные и " +
             "качественные услуги клиентам.", false)
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
                    Tag = path
                };

                image.MouseLeftButtonDown += AddImage_Click;
                GalleryGrid.Children.Add(image);
            }

            // Если пользователь — админ, показываем кнопку "Добавить фото"
            AddImageButton.Visibility = _isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }
        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            if (!_isAdmin)
            {
                MessageBox.Show("У вас нет прав на добавление изображений!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Открываем диалог выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedPath = openFileDialog.FileName;

                // Генерируем путь для сохранения в ресурсах приложения
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string targetPath = System.IO.Path.Combine(appDirectory, "Images/MastersPersonalDate/PirsWorks", System.IO.Path.GetFileName(selectedPath));

                try
                {
                    // Копируем файл в папку приложения
                    File.Copy(selectedPath, targetPath, true);

                    // Добавляем новый путь в массив imagePaths
                    List<string> updatedPaths = imagePaths.ToList();
                    updatedPaths.Add(targetPath);
                    imagePaths = updatedPaths.ToArray();

                    // Перерисовываем галерею
                    LoadGallery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
