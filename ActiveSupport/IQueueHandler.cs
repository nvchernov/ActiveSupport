using System;
using System.Threading;

namespace ActiveSupport
{
    /// <summary>
    /// Represents queue with custom handler
    /// </summary>
    /// <typeparam name="T">Queue item type</typeparam>
    public interface IQueueHandler<T>
    {
        Action<T, CancellationToken> Hander { get; }

        int QueueSize { get; }

        void AddItem(T item);
    }
}