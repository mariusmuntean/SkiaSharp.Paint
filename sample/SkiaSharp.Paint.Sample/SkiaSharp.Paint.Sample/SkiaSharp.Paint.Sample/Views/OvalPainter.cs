using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkiaSharp.Paint.Sample.Views
{
    public class OvalPainter
    {
        SKPaint _ovalPaint = new SKPaint
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


        public OvalPainter(Guid actionId, int zIndex)
        {
            _zIndex = zIndex;
            _actionId = actionId;

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
                _ovalPaint.Color = new SKColor((byte) rand.Next(0, 256), (byte) rand.Next(0, 256), (byte) rand.Next(0, 256));

                var cxFactor = 0.25f + rand.NextDouble() * 0.5f;
                var cyFactor = 0.25f + rand.NextDouble() * 0.5f;

                var rxFactor = 0.1f + rand.NextDouble() * 0.65f;
                var ryFactor = 0.1f + rand.NextDouble() * 0.65f;

                await _geometryChannelWriter.DispatchAsync(new PaintMessage
                {
                    ActionId = _actionId,
                    ZIndex = _zIndex,
                    PaintAction = (canvasSize, canvas) =>
                    {
                        var rx = (float) rxFactor * canvasSize.Width;
                        var ry = (float) ryFactor * canvasSize.Height;

                        var cx = (float) cxFactor * canvasSize.Width;
                        var cy = (float) cyFactor * canvasSize.Height;

                        canvas.DrawOval(cx, cy, rx, ry, _ovalPaint);
                    }
                });

                await Task.Delay(3100);
            }
        }
    }
}