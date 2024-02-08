using System;
using System.Collections.Generic;
using System.Threading;

namespace ActiveSupport
{
    /// <summary>
    /// Represents queue with custom handler
    /// </summary>
    /// <typeparam name="T">Queue item type</typeparam>
    public interface IQueueHandler<T>
    {
        /// <summary>
        /// Some hanlder that works with queued items
        /// </summary>
        Action<T, CancellationToken> Hander { get; }

        int QueueSize { get; }

        /// <summary>
        /// Should return copy of inner queue items
        /// </summary>
        IEnumerable<T> QueueItems { get; }

        void AddItem(T item);
    }
}