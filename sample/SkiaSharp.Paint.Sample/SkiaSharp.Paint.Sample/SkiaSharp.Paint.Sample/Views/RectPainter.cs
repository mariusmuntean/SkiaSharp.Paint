using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkiaSharp.Paint.Sample.Views
{
    public class RectPainter
    {
        SKPaint _rectPaint = new SKPaint
        {
            StrokeWidth = 2,
            Color = SKColors.Fuchsia,
            Style = SKPaintStyle.Fill
        };

        private CancellationTokenSource _cts;
        private Guid _actionId;
        private int _zIndex;
        private Task _artTask;
        private readonly IPaintChannelWriter _geometryChannelWriter;

        public RectPainter(Guid actionId, int zIndex)
        {
            _actionId = actionId;
            _zIndex = zIndex;

            var geometryChannel = PaintChannelFactory.CreateOrGetNamedPaintChannel("geometry");
            _geometryChannelWriter = geometryChannel.CreateWriter();
        }

        public void ProduceArt()
        {
            _cts?.Dispose();
            _cts = new CancellationTokenSource();
            _artTask = Art();
        }

        public void StopArt()
        {
            _cts?.Cancel();
        }

        private async Task Art()
        {
            var rand = new Random();

            while (!_cts.IsCancellationRequested)
            {
                // expensive operations
                _rectPaint.Color = new SKColor((byte) rand.Next(0, 256), (byte) rand.Next(0, 256), (byte) rand.Next(0, 256));
                _rectPaint.Style = rand.NextDouble() > 0.5d ? SKPaintStyle.Stroke : SKPaintStyle.Fill;

                var wFactor = 0.1f + rand.NextDouble() * 0.5f;
                var hFactor = 0.1f + rand.NextDouble() * 0.5f;

                var leftFactor = rand.NextDouble() * 0.5f;
                var topFactor = rand.NextDouble() * 0.5f;


                _geometryChannelWriter.Dispatch(new PaintMessage
                {
                    ActionId = _actionId,
                    ZIndex = _zIndex,
                    PaintAction = (canvasSize, canvas) =>
                    {
                        var rectWidth = (float) wFactor * canvasSize.Width;
                        var rectHeight = (float) hFactor * canvasSize.Height;

                        var rectLeft = (float) leftFactor * canvasSize.Right;
                        var rectTop = (float) topFactor * canvasSize.Bottom;

                        _rectPaint.Color = new SKColor((byte) rand.Next(0, 256), (byte) rand.Next(0, 256), (byte) rand.Next(0, 256));
                        _rectPaint.Style = rand.NextDouble() > 0.5d ? SKPaintStyle.Stroke : SKPaintStyle.Fill;

                        canvas.DrawRect(rectLeft, rectTop, rectWidth, rectHeight, _rectPaint);
                    }
                });

                await Task.Delay(1000);
            }
        }
    }
}