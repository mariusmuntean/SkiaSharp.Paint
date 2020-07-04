namespace SkiaSharp.Paint
{
    public class PaintOptions
    {
        /// <summary>
        /// Whether or not the canvas should be cleared before painting onto it. The default value is <code>false</code>
        /// </summary>
        public bool ShouldClearCanvasBeforePainting { get; set; } = false;

        /// <summary>
        /// The color to be used when clearing the canvas. The default value is <code>SKColors.Transparent</code>
        /// </summary>
        public SKColor ClearCanvasColor { get; set; } = SKColors.Transparent;

        public void Deconstruct(out bool shouldClearCanvasBeforePainting, out SKColor clearCanvasColor) => (shouldClearCanvasBeforePainting, clearCanvasColor) = (ShouldClearCanvasBeforePainting, ClearCanvasColor);
    }
}