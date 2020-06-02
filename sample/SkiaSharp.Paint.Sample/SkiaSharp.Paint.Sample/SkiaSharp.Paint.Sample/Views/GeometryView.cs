using System;
using System.Collections.Concurrent;
using PubSub;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharp.Paint.Sample.Views
{
    public class GeometryView : SKCanvasView
    {
        private readonly Hub _hub = Hub.Default;
        private readonly ConcurrentDictionary<Guid, PaintMessage> _paintMap = new ConcurrentDictionary<Guid, PaintMessage>();
        private readonly PaintChannel _paintChannel;
        private readonly PaintChannelReader _channelReader;

        public GeometryView()
        {
            PaintSurface += OnPaintSurface;
            
            _hub.Subscribe<PaintMessage>(newMessage =>
            {
                _paintMap.AddOrUpdate(newMessage.ActionId, newMessage, (guid, oldMessage) => newMessage);
                Device.BeginInvokeOnMainThread(this.InvalidateSurface);
            });

            _paintChannel = PaintChannelFactory.CreateOrGetNamedPaintChannel("geometry");
            _channelReader = _paintChannel.GetChannelReader(this);
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            _channelReader.Paint(e);
        }
    }
}