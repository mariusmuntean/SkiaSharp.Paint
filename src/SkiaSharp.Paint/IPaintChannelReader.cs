using SkiaSharp.Paint.Implementations;
using SkiaSharp.Views.Forms;

namespace SkiaSharp.Paint
{
    public interface IPaintChannelReader
    {
        /// <summary>
        /// Paints the current content of the <see cref="IPaintChannel"/> onto the provided <see cref="SKCanvas"/> instance.
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="paintOptions">Options that control the painting</param>
        public void Paint(SKPaintSurfaceEventArgs eventArgs, PaintOptions paintOptions = null);
    }
}