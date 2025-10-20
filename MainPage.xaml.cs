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
            "forth"
        };

      

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
    }
}
