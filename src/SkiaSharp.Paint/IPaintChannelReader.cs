using SkiaSharp.Views.Forms;

namespace SkiaSharp.Paint
{
    public interface IPaintChannelReader
    {
        /// <summary>
        /// Paints the current content of the <see cref="IPaintChannel"/> onto the provided <see cref="SKCanvas"/> instance.
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="shouldClearCanvasBeforePainting">Whether or not this method should clear the canvas before painting onto it.</param>
        void Paint(SKPaintSurfaceEventArgs eventArgs, bool shouldClearCanvasBeforePainting = true);
    }
}