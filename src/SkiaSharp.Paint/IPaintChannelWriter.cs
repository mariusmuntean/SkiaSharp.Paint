using System.Threading.Tasks;

namespace SkiaSharp.Paint
{
    public interface IPaintChannelWriter
    {
        /// <summary>
        /// Sends the given <see cref="PaintMessage"/> to the <see cref="IPaintChannel"/> that created this <see cref="IPaintChannelWriter"/>
        /// </summary>
        /// <param name="paintMessage"></param>
        void Dispatch(PaintMessage paintMessage);

        /// <summary>
        /// Asynchronously sends the given <see cref="PaintMessage"/> to the <see cref="IPaintChannel"/> that created this <see cref="IPaintChannelWriter"/>
        /// </summary>
        /// <param name="paintMessage"></param>
        Task DispatchAsync(PaintMessage paintMessage);
    }
}