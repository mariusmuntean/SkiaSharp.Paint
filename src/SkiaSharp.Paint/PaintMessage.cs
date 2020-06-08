using System;

namespace SkiaSharp.Paint
{
    /// <summary>
    /// Represents the intention to paint something on an <see cref="SKCanvas"/>.
    /// </summary>
    public class PaintMessage
    {
        /// <summary>
        /// The identifier of the intention to paint something.
        /// </summary>
        public Guid ActionId { get; set; }

        /// <summary>
        /// An <see cref="Action{T1, T2}"/> that takes a canvas size (<see cref="SKRectI"/>) and an <see cref="SKCanvas"/> instance and performs the paint operations.
        /// </summary>
        public Action<SKRectI, SKCanvas> PaintAction { get; set; }

        /// <summary>
        /// The relative height/layer to perform the painting on.
        /// </summary>
        public int ZIndex { get; set; }
    }
}