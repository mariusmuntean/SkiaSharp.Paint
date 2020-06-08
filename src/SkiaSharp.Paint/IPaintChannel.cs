using SkiaSharp.Views.Forms;

namespace SkiaSharp.Paint
{
    public interface IPaintChannel
    {
        IPaintChannelWriter CreateWriter();
        IPaintChannelReader GetChannelReader(SKCanvasView canvasView);
    }
}