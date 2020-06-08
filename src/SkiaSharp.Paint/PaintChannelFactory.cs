using System;
using System.Collections.Concurrent;
using PubSub;
using SkiaSharp.Paint.Implementations;

namespace SkiaSharp.Paint
{
    public static class PaintChannelFactory
    {
        private static readonly ConcurrentDictionary<string, IPaintChannel> _paintChannels = new ConcurrentDictionary<string, IPaintChannel>();

        /// <summary>
        /// Creates a new instance of <see cref="IPaintChannel"/>.
        /// </summary>
        /// <returns></returns>
        public static IPaintChannel CreatePaintChannel() => new PaintChannel(new Hub());

        /// <summary>
        /// Creates and returns a new named instance of an <see cref="IPaintChannel"/>. If a <see cref="IPaintChannel"/> instance with that name has already been created, then that instance is returned.
        /// </summary>
        /// <param name="channelName">The name of the <see cref="IPaintChannel"/>. <para>Null or empty strings are not allowed.</para></param>
        /// <returns></returns>
        public static IPaintChannel CreateOrGetNamedPaintChannel(string channelName)
        {
            return (string.IsNullOrWhiteSpace(channelName)) switch
            {
                true => throw new ArgumentException(nameof(channelName)),
                false => _paintChannels.GetOrAdd(channelName, key => new PaintChannel(new Hub()))
            };
        }
    }
}