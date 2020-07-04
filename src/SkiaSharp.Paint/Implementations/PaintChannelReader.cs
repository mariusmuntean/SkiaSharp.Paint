using System.Linq;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharp.Paint.Implementations
{
    internal class PaintChannelReader : IPaintChannelReader
    {
        private static readonly PaintOptions DefaultPaintOptions = new PaintOptions();

        private readonly PaintChannel _paintChannel;
        private readonly SKCanvasView _canvasView;

        internal PaintChannelReader(PaintChannel paintChannel, SKCanvasView canvasView)
        {
            _paintChannel = paintChannel;
            _canvasView = canvasView;
        }

        public void Paint(SKPaintSurfaceEventArgs eventArgs, PaintOptions paintOptions = null)
        {
            var canvas = eventArgs.Surface.Canvas;
            var canvasSize = eventArgs.Info.Rect;

            paintOptions ??= DefaultPaintOptions;
            var (shouldClearCanvasBeforePainting, clearCanvasColor) = paintOptions;

            if (shouldClearCanvasBeforePainting)
            {
                canvas.Clear(clearCanvasColor);
            }

            foreach (var paintMessage in _paintChannel.GetPaintMessages().Select(pair => pair.Value).OrderBy(message => message.ZIndex))
            {
                paintMessage.PaintAction(canvasSize, canvas);
            }
        }

        internal void OnNewPaintMessage()
        {
            Device.BeginInvokeOnMainThread(() => _canvasView.InvalidateSurface());
        }
    }
}