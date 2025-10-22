using System.Diagnostics;

namespace ImageGenerator
{
    public partial class MainPage : ContentPage



    {
        private class ImageItem
        {

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

            UpdateFavoriteIcon();
        }




        private string GetImageFileEnding(string imageKey)
        {
#if WINDOWS
            return imageKey + ".jpg";
#else
            return imageKey;
#endif
        }


        private readonly List<string> _favoriteList = new();
        private readonly Stack<string> _recentFavorites = new();
        private string _currentImageKey;

        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentImageKey))

                return;


            bool isFavorite = _favoriteList.Contains(_currentImageKey);

            if (isFavorite)
            {
                _favoriteList.Remove(_currentImageKey);
                FavoriteButton.Source = new FontImageSource
                {
                    FontFamily = "MaterialIcons",
                    Glyph = "\ue87e",
                    Size = 32,
                    Color = Colors.Gray
                };
            }
            else
            {
                _favoriteList.Add(_currentImageKey);
                _recentFavorites.Push(_currentImageKey);
                FavoriteButton.Source = new FontImageSource
                {
                    FontFamily = "MaterialIcons",
                    Glyph = "\uf004",
                    Size = 32,
                    Color = Colors.Red
                };



            }
             }

            private void UpdateFavoriteIcon()
            {
            if(string.IsNullOrEmpty(_currentImageKey))
                    return;

                bool isFavorite = _favoriteList.Contains(_currentImageKey);

                FavoriteButton.Source = new FontImageSource
                    {

                    FontFamily = "MaterialIcons",
                    Glyph = isFavorite ? "\ue87d" : "\ue87e",
                    Size = 32,
                    Color = isFavorite ? Colors.Red : Colors.Gray

                };
        }
    }
}
