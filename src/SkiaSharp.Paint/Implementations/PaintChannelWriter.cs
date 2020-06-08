using System.Threading.Tasks;
using PubSub;

namespace SkiaSharp.Paint.Implementations
{
    internal class PaintChannelWriter : IPaintChannelWriter
    {
        private readonly Hub _hub;

        internal PaintChannelWriter(Hub hub)
        {
            _hub = hub;
        }

        public void Dispatch(PaintMessage paintMessage)
        {
            _hub.Publish(paintMessage);
        }

        public Task DispatchAsync(PaintMessage paintMessage)
        {
            return _hub.PublishAsync(paintMessage);
        }
    }
}