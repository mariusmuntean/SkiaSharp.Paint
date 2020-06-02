using System;
using Xamarin.Forms;

namespace SkiaSharp.Paint.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void DemoOneBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DemoOne());
        }
    }
}