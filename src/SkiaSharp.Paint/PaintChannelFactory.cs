using System.Collections.Concurrent;
using PubSub;
using SkiaSharp.Paint.Implementations;

namespace SkiaSharp.Paint
{
    public static class PaintChannelFactory
    {
        private static readonly ConcurrentDictionary<string, IPaintChannel> _paintChannels = new ConcurrentDictionary<string, IPaintChannel>();

        public static IPaintChannel CreatePaintChannel() => new PaintChannel(new Hub());

        public static IPaintChannel CreateOrGetNamedPaintChannel(string channelName)
        {
            return _paintChannels.GetOrAdd(channelName, key => new PaintChannel(new Hub()));
        }
    }
}