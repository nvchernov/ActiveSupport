using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using System.Diagnostics;

namespace ActiveSupport.Test
{
    public class QueueHandlerTest
    {

        [Fact]
        public void Test_QueueHandler_simple_test()
        {


            List<string> result = new List<string>();
            var queueHandler = new QueueHandler<string>((p, token) => {

                Thread.Sleep(100);
                result.Add(p);
            });

            for (int i = 0; i < 10; ++i)
                queueHandler.AddItem(i.ToString());

            Thread.Sleep(2000);

            Assert.Equal(10, result.Count);


        }

        [Fact]
        public void Test_QueueHandler_4_threads_test()
        {


            List<string> result = new List<string>();
            var queueHandler = new QueueHandler<string>((p, token) => {

                Thread.Sleep(10);
                result.Add(p);
            });

            Action addAction = () =>
            {
                // just testing QueueItems field
                var queueItems = queueHandler.QueueItems;

                var someValue = queueItems.Count();
                for (int i = 0; i < 10; ++i)
                {
                    queueHandler.AddItem(i.ToString());
                    someValue += queueHandler.QueueSize;
                }
            };

            Thread[] threads = new Thread[4];

            for(int i = 0; i < threads.Count(); ++i)
                threads[i] = new Thread(() => addAction());

            foreach (var thread in threads)
                thread.Start();

            Thread.Sleep(2000);

            Assert.Equal(40, result.Count);


        }


        [Fact]
        public void Test_QueueHandler_cancel_test()
        {

            List<string> result = new List<string>();

            QueueHandler<string> queueHandler = null;

            queueHandler = new QueueHandler<string>((p, token) => {

                if (token.IsCancellationRequested)
                    return;

                Thread.Sleep(10);

                if (token.IsCancellationRequested)
                    return;

                result.Add(p);

                if (result.Count == 20)
                    queueHandler.Dispose();

            });

            Action addAction = () =>
            {
                for (int i = 0; i < 10; ++i)
                    queueHandler.AddItem(i.ToString());
            };

            Thread[] threads = new Thread[4];

            for (int i = 0; i < threads.Count(); ++i)
                threads[i] = new Thread(() => addAction());

            foreach (var thread in threads)
                thread.Start();

            Thread.Sleep(2000);

            Assert.Equal(20, result.Count);


        }

        [Fact]
        public void Test_QueueHandler_thread_changing()
        {

            /*
             * second time new thread should be created
             * 
             * this test checking this
             *
             * */

            List<int> threadIds = new List<int>();

            List<string> result = new List<string>();
            var queueHandler = new QueueHandler<string>((p, token) => {

                Thread.Sleep(10);
                result.Add(p);

                threadIds.Add(Thread.CurrentThread.ManagedThreadId); 
                
                Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

            });

            // first time when queue is empty thread should be removed
            for (int i = 0; i < 5; ++i)
                queueHandler.AddItem(i.ToString());

            Thread.Sleep(2000);

            //ThreadPool.QueueUserWorkItem((e) => Thread.Sleep(4000));

            // second time new thread should be created
            for (int i = 0; i < 5; ++i)
                queueHandler.AddItem(i.ToString());

            Thread.Sleep(2000);

            Assert.Equal(10, result.Count);
            Assert.Equal(2, threadIds.Distinct().Count());

        }


    }
}
