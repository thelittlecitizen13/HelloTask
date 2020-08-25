using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloTask
{
    class StackNumbers
    {
        ConcurrentStack<int> numbersStack = new ConcurrentStack<int>();
        public void ClearStack()
        {
            numbersStack = new ConcurrentStack<int>();
        }
        public void FillStack(int times)
        {
            for (int i = 1; i < times + 1; i++)
            {
                numbersStack.Push(i);
            }
        }
        public ConcurrentStack<int> getNumbersStack()
        {
            return numbersStack;
        }
        /// <summary>
        /// Ex 2a
        /// </summary>
        public void PrintUsingTasks()
        {
            var task1 = Task.Run(() => popAndPrint());
            var task2 = Task.Run(() => popAndPrint());
            var task3 = Task.Run(() => popAndPrint());
            Task.WaitAll(task1, task2, task3);
        }
        /// <summary>
        /// Ex 2b
        /// </summary>
        public void PrintUsingParallel()
        {
            Parallel.ForEach(numbersStack, i =>
            {
                int result = -1;
                numbersStack.TryPop(out result);
                Console.WriteLine(result);
            });
        }
        private void popAndPrint()
        {
            while (numbersStack.Count != 0)
            {
                int result = -1;
                numbersStack.TryPop(out result);
                if (result != -1)
                    Console.WriteLine(result);
            }
            
        }
    }
}
