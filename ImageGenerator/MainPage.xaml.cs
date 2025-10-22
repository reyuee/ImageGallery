using System.Diagnostics;

namespace ImageGenerator
{
    public partial class MainPage : ContentPage

        private class ImageItem

    {
        private class ImageItem { 
        
            public string FileName { get; set; }
            public string Title { get; set; }


        }

        private readonly List<ImageItem> _images = new()
        {
            new ImageItem { FileName = "image1", Title = "Fog Forest" },
            new ImageItem { FileName = "image2", Title = "Mushroom" },
            new ImageItem { FileName = "image3", Title = "Cool Car" },
            new ImageItem { FileName = "image4", Title = "Picture of a guy jumping" },
            new ImageItem { FileName = "image5", Title = "Galaxy" },
            new ImageItem { FileName = "image6", Title = "Mountain" },
            new ImageItem { FileName = "image7", Title = "Tunel" },
            new ImageItem { FileName = "image8", Title = "Desert" },
            new ImageItem { FileName = "image9", Title = "Truck" },
            new ImageItem { FileName = "image10", Title = "Tower" }


        }; 


   



        private Random random = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageOnClicked(object? sender, EventArgs e)
        {
            ShowImageAndText();
        }

        private void ShowImageAndText()
        {
            var item = _images[random.Next(_images.Count)];

            _currentImageKey = item.FileName;

           string showKey = GetImageFileEnding(item.FileName);

            ShowGallery.Source = showKey;

            ImageText.Text = item.Title;

            UpdatefavoriteIcon();
        }


       

        private string GetImageFileEnding(string imageKey)
        {
#if WINDOWS
            return imageKey + ".jpg";
#else
            return imageKey;
#endif
        }

        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            _isFavorite = !_isFavorite;

            if (_isFavorite)
            {
                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = "\ue87d",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = Colors.Red
                };
            }
            else
            {
                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = "\ue87e",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = Colors.Gray
                };
            }
        }
    }
}