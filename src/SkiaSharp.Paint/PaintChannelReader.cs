using System.Linq;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharp.Paint
{
    public class PaintChannelReader
    {
        private readonly PaintChannel _paintChannel;
        private readonly SKCanvasView _canvasView;

        internal PaintChannelReader(PaintChannel paintChannel, SKCanvasView canvasView)
        {
            _paintChannel = paintChannel;
            _canvasView = canvasView;
        }

        public void Paint(SKPaintSurfaceEventArgs eventArgs, bool shouldClearCanvasBeforePainting = true)
        {
            var canvas = eventArgs.Surface.Canvas;
            var canvasSize = eventArgs.Info.Rect;

            if (shouldClearCanvasBeforePainting)
            {
                canvas.Clear(SKColors.LightGray);
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