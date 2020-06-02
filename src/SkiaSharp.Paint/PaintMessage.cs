using System;

namespace SkiaSharp.Paint
{
    public class PaintMessage
    {
        public Guid ActionId { get; set; }

        public Action<SKRectI, SKCanvas> PaintAction { get; set; }
        public int ZIndex { get; set; }
    }
}