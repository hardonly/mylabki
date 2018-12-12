using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace lab_16
{
    class Program
    {
        static void Multiplication()
        {
            if (A.GetLength(1) != B.GetLength(0)) throw new Exception("Matrices can not be multiplied.");
            int[,] r = new int[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        r[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
        }

        static void MultiplicationCanBeCanseled()
        {
            if (A.GetLength(1) != B.GetLength(0)) throw new Exception("Matrices can not be multiplied.");
            int[,] r = new int[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        r[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
        }

        static void Display(Task t)
        {
            Console.WriteLine("\nTask id: {0}", Task.CurrentId);
            Console.WriteLine("Previous task id: {0}", t.Id);
            Thread.Sleep(500);
        }

        static void Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Task {0}", Task.CurrentId);
            Console.WriteLine("Factorial of number {0} is {1}", x, result);
            Thread.Sleep(2000);
        }

        static void DisplayForInvoke()
        {
            Console.WriteLine("Task {0}", Task.CurrentId);
            Thread.Sleep(2000);
        }

        static void FactorialForInvoke(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Task {0}", Task.CurrentId);
            Thread.Sleep(2000);
            Console.WriteLine("Result {0}", result);
        }

        static void FactorialForAsync()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(6000);
            Console.WriteLine($"Factorial is {result}");
        }

        static async void FactorialAsync()
        {
            Console.WriteLine("Begin FactorialAsync");
            await Task.Run(() => FactorialForAsync());
            Console.WriteLine("End FactorialAsync");
        }

        static int[,] A = new int[500, 500];
        static int[,] B = new int[500, 500];
        static Random random = new Random();

        static void Main(string[] args)
        {
            /*Stopwatch sw = new Stopwatch();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = random.Next() % 90 + 10;
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.Next() % 90 + 10;
                }
            }
            Task task = new Task(Multiplication);
            Console.WriteLine("With Task:\n\nMatrices set. Press enter to start.");
            Console.Write($"Task {task.Id}: {task.Status}");
            Console.Read();
            sw.Start();
            task.Start();
            Thread.Sleep(2000);
            Console.WriteLine($"Task {task.Id}: {task.Status}");
            task.Wait();
            sw.Stop();
            Console.WriteLine("Multiplication complete.");
            Console.WriteLine($"Task {task.Id}: {task.Status}");
            Console.WriteLine($"Elapsed time {sw.Elapsed}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Task task1 = new Task(() =>
            { 
                if (A.GetLength(1) != B.GetLength(0)) throw new Exception("Matrices can not be multiplied.");
                int[,] r = new int[A.GetLength(0), B.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        for (int k = 0; k < B.GetLength(0); k++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Operation canceled.");
                                return;
                            }
                            r[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
            });
            Console.WriteLine("CancellationToken:\n\n");
            Console.WriteLine("Press enter to start.");
            Console.ReadLine();
            task1.Start();
            Console.WriteLine("Enter Q to cancel.");
            string s = Console.ReadLine();
            if (s == "q" || s == "Q")
                cancelTokenSource.Cancel();
            Thread.Sleep(200);
            Console.WriteLine(task1.Status);
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Return value:\n");
            int x = 0;
            Func<int> func = () =>
            {
                return ++x;
            };
            Task<int> taskToReturn1 = new Task<int>(func);
            Task<int> taskToReturn2 = new Task<int>(func);
            Task<int> taskToReturn3 = new Task<int>(func);
            Task[] tasks = new Task[3];
            tasks[0] = taskToReturn1;
            tasks[1] = taskToReturn2;
            tasks[2] = taskToReturn3;
            foreach(var t in tasks)
            {
                t.Start();
            }
            Func<int> result = () =>
            {
                return taskToReturn1.Result * taskToReturn2.Result * taskToReturn3.Result;
            };
            Task<int> taskToReturn = new Task<int>(result);
            taskToReturn.Start();
            Console.WriteLine($"Result = {taskToReturn.Result}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Continuation task:\n");
            Task taskOne = new Task(() => {
                Console.WriteLine("Task id: {0}", Task.CurrentId);
            });
            Task taskTwo = taskOne.ContinueWith(Display);
            taskOne.Start();
            taskTwo.Wait();
            Console.WriteLine("\n\nGetAwaiter & GetResult:");
            Task<int> what = Task.Run(() => random.Next() % 2);
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() => {
                int res = awaiter.GetResult();
                Console.WriteLine("\nResult: " + res);
            });
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Simple for:");
            int[] arr1 = new int[10000000];
            int[] arr2 = new int[10000000];
            int[] arr3 = new int[10000000];
            sw.Restart();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next() % 100;
                arr2[i] = random.Next() % 100;
                arr3[i] = random.Next() % 100;
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("\nParallel.For:");
            int[] array1 = new int[10000000];
            int[] array2 = new int[10000000];
            int[] array3 = new int[10000000];

            Task[] tasksParallel = new Task[2]
            {
                new Task(() => {for(int i = 0; i <= 5000000; i++)
            {
                array1[i] = random.Next() % 100;
                array2[i] = random.Next() % 100;
                array3[i] = random.Next() % 100;
            } }),
                new Task(() => {for(int i = 5000001; i < 10000000; i++)
            {
                array1[i] = random.Next() % 100;
                array2[i] = random.Next() % 100;
                array3[i] = random.Next() % 100;
            } })
            };
            foreach(var t in tasksParallel)
            {
                t.Start();
            }
            sw.Restart();
            Task.WaitAll(tasksParallel);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Parallel.Foreach:\n");
            ParallelLoopResult loopResult = Parallel.ForEach(new List<int>() { 1, 3, 5, 8 }, Factorial);
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Parallel.Invoke:\n");
            Parallel.Invoke(DisplayForInvoke, () => {
            Console.WriteLine("Task {0}", Task.CurrentId);
            Thread.Sleep(2000);
            }, () => FactorialForInvoke(5));
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            FactorialAsync();
            Console.WriteLine("Enter any number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Square of number is {n * n}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();*/

            Console.WriteLine("Producers and clients:\n");
            int xx = 0;
            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 5; producer++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int ii = 0; ii < 3; ii++)
                    {
                        int id = ++xx;
                        blockcoll.Add(id);
                        Console.WriteLine("Producer add " + id);
                        Thread.Sleep(random.Next() % 4000);
                    }
                });
            }
            Task consumer = Task.Factory.StartNew(
            () =>
            {
                foreach (var item in blockcoll.GetConsumingEnumerable())
                {
                    Console.WriteLine(" Reading " + item);
                }
            });
            consumer.Wait();
        }
    }
}
