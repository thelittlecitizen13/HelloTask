using System;
using System.Diagnostics;
using System.Threading;

namespace HelloTask
{
    public class PrintNumbers
    {
        public int times = 10000;
        /// <summary>
        /// Ex 1a
        /// </summary>
        public void PrintSyncNumbers()
        {
            for (int i = 1; i < times; i++)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// Ex 1b
        /// </summary>
        public void PrintThreadNumbers()
        {
            for (int i = 1; i < times; i++)
            {
                int num = i;
                Thread t = new Thread(() => Console.WriteLine(num));
                t.Start();
            }
        }
        /// <summary>
        /// Ex 1c
        /// </summary>
        public void PrintThreadPoolNumbers()
        {
            Stopwatch threadpoolWatch = new Stopwatch();
            threadpoolWatch.Start();
            
            for (int i = 1; i < times; i++)
            {
                int num = i;
                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Thread.CurrentThread.IsBackground = false;
                    Console.WriteLine((int) obj);
                }, num);
            }
            
            threadpoolWatch.Stop();
            Console.WriteLine($"Threadpool run: {threadpoolWatch.ElapsedMilliseconds}");

        }
    }
}
