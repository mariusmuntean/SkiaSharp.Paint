using System.Threading.Tasks;

namespace SkiaSharp.Paint
{
    public interface IPaintChannelWriter
    {
        /// <summary>
        /// Sends the given <see cref="PaintMessage"/> to the <see cref="IPaintChannel"/> that created this <see cref="IPaintChannelWriter"/>
        /// <para>Sending a new <see cref="PaintMessage"/> with an existing <see cref="PaintMessage.ActionId"/> will replace the previous <see cref="PaintMessage"/> with the same <see cref="PaintMessage.ActionId"/>. This allow refreshing some content on the canvas. </para>
        /// </summary>
        /// <param name="paintMessage"></param>
        void Dispatch(PaintMessage paintMessage);

        /// <summary>
        /// Asynchronously sends the given <see cref="PaintMessage"/> to the <see cref="IPaintChannel"/> that created this <see cref="IPaintChannelWriter"/>
        /// <para>Sending a new <see cref="PaintMessage"/> with an existing <see cref="PaintMessage.ActionId"/> will replace the previous <see cref="PaintMessage"/> with the same <see cref="PaintMessage.ActionId"/>. This allow refreshing some content on the canvas. </para>
        /// </summary>
        /// <param name="paintMessage"></param>
        Task DispatchAsync(PaintMessage paintMessage);
    }
}