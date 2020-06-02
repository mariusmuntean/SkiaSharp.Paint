using System.Collections.Concurrent;
using PubSub;

namespace SkiaSharp.Paint
{
    public static class PaintChannelFactory
    {
        private static readonly ConcurrentDictionary<string, PaintChannel> _paintChannels = new ConcurrentDictionary<string, PaintChannel>();

        public static PaintChannel CreatePaintChannel() => new PaintChannel(new Hub());

        public static PaintChannel CreateOrGetNamedPaintChannel(string channelName)
        {
            return _paintChannels.GetOrAdd(channelName, key => new PaintChannel(new Hub()));
        }
    }
}