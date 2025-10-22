using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace ImageGenerator
{
    public partial class MainPage : ContentPage
    {
        private int currentIndex = 0;
        private List<string> imageList = new()
        {
            "first",
            "second",
            "third",
            "forth",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten"
        };

        private HashSet<string> favoriteImages = new();
        private Random random = new(); // for random image selection

        public MainPage()
        {
            InitializeComponent();
            ShowImage();
        }

        private void ShowImage()
        {
#if WINDOWS
            ShowGallery.Source = $"{imageList[currentIndex]}.jpg";
#else
            ShowGallery.Source = imageList[currentIndex];
#endif
            ImageText.Text = imageList[currentIndex];

            FavoriteButton.Text = favoriteImages.Contains(imageList[currentIndex]) ? "❤️" : "🤍";
        }

        private void NextClicked(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= imageList.Count)
                currentIndex = 0;
            ShowImage();
        }

        private void PreviousClicked(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = imageList.Count - 1;
            ShowImage();
        }

        private void FavoriteClicked(object sender, EventArgs e)
        {
            string currentImage = imageList[currentIndex];

            // Toggle favorite status
            if (favoriteImages.Contains(currentImage))
                favoriteImages.Remove(currentImage);
            else
                favoriteImages.Add(currentImage);

            // 🎲 Now show a random image after clicking favorite
            int newIndex;
            do
            {
                newIndex = random.Next(imageList.Count);
            }
            while (newIndex == currentIndex && imageList.Count > 1);

            currentIndex = newIndex;
            ShowImage();
        }
    }
}
