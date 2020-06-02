using System;
using SkiaSharp.Paint.Sample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkiaSharp.Paint.Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoOne : ContentPage
    {
        private readonly RectPainter _rectPainter1;
        private readonly RectPainter _rectPainter2;
        private readonly RectPainter _rectPainter3;
        private readonly OvalPainter _ovalPainter;

        public DemoOne()
        {
            InitializeComponent();

            _rectPainter1 = new RectPainter(Guid.NewGuid(), 1);
            _rectPainter2 = new RectPainter(Guid.NewGuid(), 2);
            _rectPainter3 = new RectPainter(Guid.NewGuid(), 3);
            _ovalPainter = new OvalPainter(Guid.NewGuid(), 10);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _rectPainter1.ProduceArt();
            _rectPainter2.ProduceArt();
            _rectPainter3.ProduceArt();
            _ovalPainter.ProduceArt();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _rectPainter1?.StopArt();
            _rectPainter2?.StopArt();
            _rectPainter3?.StopArt();
            _ovalPainter?.StopArt();
        }
    }
}