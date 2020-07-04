using System;

namespace SkiaSharp.Paint.Implementations
{
    internal class RemoveMessage
    {
        public Guid ActionIdToRemove { get; }

        public RemoveMessage(Guid actionIdToRemove)
        {
            ActionIdToRemove = actionIdToRemove;
        }
    }
}