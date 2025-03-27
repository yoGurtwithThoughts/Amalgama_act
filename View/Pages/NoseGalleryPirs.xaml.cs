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

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для NoseGalleryPirs.xaml
    /// </summary>
    public partial class NoseGalleryPirs : Page
    {
        public NoseGalleryPirs()
        {
            InitializeComponent();
            LoadGallery();
        

            }
        private void LoadGallery()
        {
            var galleryItems = new[]
            {
            new { Title = "Картинка 1", ImagePath = "Images/image1.jpg", Description = "Описание 1" },
            new { Title = "Картинка 2", ImagePath = "Images/image2.jpg", Description = "Описание 2" },
            new { Title = "Картинка 3", ImagePath = "Images/image3.jpg", Description = "Описание 3" },
            new { Title = "Картинка 4", ImagePath = "Images/image4.jpg", Description = "Описание 4" }
        };

            foreach (var item in galleryItems)
            {
                var stackPanel = new StackPanel { HorizontalAlignment = HorizontalAlignment.Center };

                // Заголовок
                var titleBlock = new TextBlock
                {
                    Text = item.Title,
                    Style = (Style)FindResource("OtherTxt"),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                stackPanel.Children.Add(titleBlock);

                // Контейнер для изображения
                var imageBorder = new Border { Style = (Style)FindResource("PfotoContainer") };
                var image = new Image
                {
                    Source = new BitmapImage(new Uri(item.ImagePath, UriKind.Relative)),
                    Stretch = Stretch.UniformToFill
                };
                imageBorder.Child = image;
                stackPanel.Children.Add(imageBorder);

                // Описание
                var descriptionBlock = new TextBlock
                {
                    Text = item.Description,
                    Style = (Style)FindResource("OtherTxt"),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                stackPanel.Children.Add(descriptionBlock);

                GalleryGrid.Children.Add(stackPanel);
            }
        }
    
}
}
