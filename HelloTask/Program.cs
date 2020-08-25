using System;
using System.Diagnostics;
using System.Linq;

namespace HelloTask
{
    class Program
    {
        static void Main(string[] args)
        {

            StackEx();
        }
        public static void NumbersEx()
        {
            PrintNumbers pN = new PrintNumbers();
            Stopwatch syncWatch = new Stopwatch();
            syncWatch.Start();
            //pN.PrintSyncNumbers();
            syncWatch.Stop();

            Stopwatch threadWatch = new Stopwatch();
            threadWatch.Start();
            //pN.PrintThreadNumbers();
            threadWatch.Stop();

            Stopwatch threadpoolWatch = new Stopwatch();
            threadpoolWatch.Start();
            pN.PrintThreadPoolNumbers();
            threadpoolWatch.Stop();
            Console.WriteLine($"Syncronic run: {syncWatch.ElapsedMilliseconds}");
            Console.WriteLine($"Thread run: {threadWatch.ElapsedMilliseconds}");
            Console.WriteLine($"Threadpool run: {threadpoolWatch.ElapsedMilliseconds}");
        }
        public static void StackEx()
        {
            StackNumbers sNumbers = new StackNumbers();
            sNumbers.FillStack(5000);
            //Console.WriteLine(sNumbers.getNumbersStack().First());
            //sNumbers.PrintUsingTasks();
            sNumbers.PrintUsingParallel();
        }
        
    }
}
