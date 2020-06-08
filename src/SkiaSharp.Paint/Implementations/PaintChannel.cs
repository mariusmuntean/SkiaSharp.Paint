using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using PubSub;
using SkiaSharp.Views.Forms;

namespace SkiaSharp.Paint.Implementations
{
    internal class PaintChannel : IPaintChannel
    {
        private readonly ConcurrentDictionary<Guid, PaintMessage> _paintMap;
        private readonly Hub _hub;
        private PaintChannelReader _channelReader;

        internal PaintChannel(Hub hub)
        {
            _paintMap = new ConcurrentDictionary<Guid, PaintMessage>();
            _hub = hub;

            _hub.Subscribe<PaintMessage>(newPaintMessage =>
            {
                _paintMap.AddOrUpdate(newPaintMessage.ActionId, newPaintMessage, (id, oldMessage) => newPaintMessage);
                _channelReader?.OnNewPaintMessage();
            });
        }

        public IPaintChannelReader GetChannelReader(SKCanvasView canvasView) => _channelReader ?? (_channelReader = new PaintChannelReader(this, canvasView));

        public IPaintChannelWriter CreateWriter() => new PaintChannelWriter(_hub);

        internal KeyValuePair<Guid, PaintMessage>[] GetPaintMessages() => _paintMap.ToArray();
    }
}