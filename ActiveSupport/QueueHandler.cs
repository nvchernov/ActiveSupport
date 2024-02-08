using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveSupport
{

    /// <summary>
    /// Queue with custom 1-thread handler
    /// It uses thread if it needed - if queue is empty, there is no thread running
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueHandler<T> : IDisposable, IQueueHandler<T>
    {

        private readonly Queue<T> _queue = new Queue<T>();

        private volatile bool _handleDone = true;

        private readonly object _syncObj = 0;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken;

        /// <summary>
        /// Custom handler, that sequently works with every queued item
        /// </summary>
        public Action<T, CancellationToken> Hander { get; private set; }

        public int QueueSize { get { lock (_syncObj) return _queue.Count; } }

        /// <summary>
        /// Return copy of inner queue items
        /// </summary>
        public IEnumerable<T> QueueItems => GetQueueItems();

        private IEnumerable<T> GetQueueItems()
        {
            lock(_syncObj)
            {
                var arr = new T[_queue.Count];

                _queue.CopyTo(arr, arrayIndex: 0);

                return arr;
            }
        }

        /// <summary>
        /// Queue with custom 1-thread handler
        /// It uses thread if it needed - if queue is empty, there is no thread running
        /// </summary>
        /// <param name="handler">Custom handler, that sequently works with every queued item</param>
        public QueueHandler(Action<T, CancellationToken> handler)
        {
            if (handler is null)
                throw new ArgumentNullException($"{nameof(QueueHandler<T>)} ctr, {nameof(handler)} is null");

            Hander = handler;

            _cancellationToken = _cancellationTokenSource.Token;

        }

        private void HandleQueue()
        {
            T item;

            try
            {

                do
                {
                    lock (_syncObj)
                    {
                        if (_queue.Count == 0)
                        {
                            _handleDone = true;
                            return;
                        }

                        item = _queue.Dequeue();
                    }

                    if (_cancellationToken.IsCancellationRequested)
                    {
                        _handleDone = true;
                        return;
                    }

                    Hander.Invoke(item, _cancellationToken);

                } while (!_cancellationToken.IsCancellationRequested && item != null);


            }
            finally
            {
                _handleDone = true;
            }

        }

        /// <summary>
        /// Add item to queue
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            lock (_syncObj)
            {
                _queue.Enqueue(item);

                if (_handleDone)
                {
                    _handleDone = false;
                    if (!ThreadPool.QueueUserWorkItem((state) => HandleQueue()))
                    {
                        _handleDone = true;
                        throw new InvalidOperationException($"{nameof(QueueHandler<T>)} cannot get thread from thread pool");
                    }
                }

            }

        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();

        }



    }
}
