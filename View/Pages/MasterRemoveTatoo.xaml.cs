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
using System.Windows.Threading;
using static Amalgama.Core.Navigation;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MasterRemoveTatoo.xaml
    /// </summary>
    public partial class MasterRemoveTatoo : Page
    {
        private DispatcherTimer _textTimer;
        private int _currentIndex;
        private int _currentParagraphIndex;
        private TextBlock[] _textBlocksTitle;
        private TextBlock[] _textBlocks; // Массив для хранения всех TextBlock
        private (string Text, bool IsBold)[][] _paragraphs;
        private (string Text, bool IsBold)[][] _paragraphstitle;

        public MasterRemoveTatoo()
        {
            InitializeComponent();
            InitializeTextBlocksAndParagraphs();
            StartTypingAnimation(0);
            AnimateButtonGrid();
            AnimateImage();
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
            ("\n\t\tУдаление тату", false)
        }
            };

            // Инициализируем основной текст
            _paragraphs = new (string Text, bool IsBold)[][]
            {
        new (string, bool)[]
        {
            ("\nМастер лазерного удаления татуировок, имеющий опыт более 5 лет." +
             "Специализируется на безопасном и эффективном удалении татуировок." +
             "Использует современные лазерные системы — на данный момент это самый эффективный способ очистить кожу от нежелательного рисунка." +
             "Успешно работает с клиентами, обеспечивая высокий уровень обслуживания и удовлетворенности.", false)
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
            var fadeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new PowerEase { Power = 3 }
            };

            var translateAnimation = new DoubleAnimation
            {
                From = -150,
                To = 0,
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(fadeAnimation, ImgAnimated);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(UIElement.OpacityProperty));

            Storyboard.SetTarget(translateAnimation, ImgAnimated);
            Storyboard.SetTargetProperty(translateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            var storyboard = new Storyboard();
            storyboard.Children.Add(fadeAnimation);
            storyboard.Children.Add(translateAnimation);
            storyboard.Begin();
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
    }
}
