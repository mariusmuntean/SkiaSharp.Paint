using System.Threading.Tasks;

namespace SkiaSharp.Paint
{
    public interface IPaintChannelWriter
    {
        void Dispatch(PaintMessage paintMessage);
        Task DispatchAsync(PaintMessage paintMessage);
    }
}