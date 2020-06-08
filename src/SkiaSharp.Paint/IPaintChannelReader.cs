using SkiaSharp.Views.Forms;

namespace SkiaSharp.Paint
{
    public interface IPaintChannelReader
    {
        void Paint(SKPaintSurfaceEventArgs eventArgs, bool shouldClearCanvasBeforePainting = true);
    }
}