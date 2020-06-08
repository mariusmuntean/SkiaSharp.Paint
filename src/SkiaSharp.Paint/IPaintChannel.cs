using SkiaSharp.Views.Forms;

namespace SkiaSharp.Paint
{
    public interface IPaintChannel
    {
        /// <summary>
        /// Creazes a new writer for this channel.
        /// </summary>
        /// <returns></returns>
        IPaintChannelWriter CreateWriter();

        /// <summary>
        /// Gets the channel reader.
        ///
        /// <para>Calling this method repeatedly returns the same instance</para>
        /// </summary>
        /// <param name="canvasView">The <see cref="SKCanvasView"/> instance that this channel reader will inform that a repaint is necessary.</param>
        /// <returns></returns>
        IPaintChannelReader GetChannelReader(SKCanvasView canvasView);
    }
}