using PubSub;

namespace SkiaSharp.Paint
{
    public class PaintChannelWriter
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
    }
}