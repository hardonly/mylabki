using System;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace lab_15
{
    class Program
    {
        private static void SecondaryDomain_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Domain unloaded from process.");
        }

        private static void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Assembly uploaded.");
        }

        public static void ToConsole()
        {
            int max = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < max + 1; i++)
            {
                Console.WriteLine(i);
                using (StreamWriter fstream = new StreamWriter(@"F:\\Threads.txt", false, Encoding.Default))
                {
                    fstream.Write(i + " ");
                }
                Thread.Sleep(400);
            }
        }

        static int x = 1;
        static Mutex mutex = new Mutex();
        public static void Count1()
        {
            for (; x < 20;)
            {
                mutex.WaitOne();
                Thread.Sleep(300);
                if (x % 2 == 0)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {x}");
                    File.AppendAllText("oddandeven.txt", " " + x + " ", Encoding.Default);
                    x++;
                }
                mutex.ReleaseMutex();
            }
        }

        public static void Count2()
        {
            for (; x < 20;)
            {
                mutex.WaitOne();
                Thread.Sleep(100);
                if (x % 2 != 0)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {x}");
                    File.AppendAllText("oddandeven.txt", " " + x + " ", Encoding.Default);
                    x++;
                }
                mutex.ReleaseMutex();
            }
        }

        static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        static object lockerObj = new object();
        public static void OnlyOddNumbers()
        {
            lock (lockerObj)
            {
                for(int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {numbers[i]}");
                        File.AppendAllText("oddoreven.txt", " " + numbers[i] + " ", Encoding.Default);
                    }
                }
            }
        }

        public static void OnlyEvenNumbers()
        {
            lock (lockerObj)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {numbers[i]}");
                        File.AppendAllText("oddoreven.txt", " " + numbers[i] + " ", Encoding.Default);
                    }
                }
            }
        }

        public static void Timer(object fake)
        {
            Console.WriteLine("1 second passed.");
        }

        static void Main(string[] args)
        {
            Process[] process = Process.GetProcesses();
            Console.WriteLine("Current processes:\n");
            foreach (Process p in process)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Id: " + p.Id + " ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Name: " + p.ProcessName + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Base priority: " + p.BasePriority + " ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Virtual memory: " + p.VirtualMemorySize64 + "\n");
                Console.ResetColor();
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Domain: \n");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: " + domain.FriendlyName);
            Console.WriteLine("Base directory: " + domain.BaseDirectory);
            Assembly[] assemblies = domain.GetAssemblies();
            Console.WriteLine("Assemblies: ");
            foreach (Assembly a in assemblies)
            {
                Console.WriteLine("\t" + a.GetName().Name);
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Secondary domain: \n");
            AppDomain second = AppDomain.CreateDomain("Secondary domain");
            second.AssemblyLoad += Domain_AssemblyLoad;
            second.DomainUnload += SecondaryDomain_DomainUnload;
            Console.WriteLine("Domain: " + second.FriendlyName);
            second.Load(new AssemblyName("StreamJsonRpc"));
            Assembly[] secAssemblies = second.GetAssemblies();
            foreach (Assembly a in secAssemblies)
            {
                Console.WriteLine("\t" + a.GetName().Name);
            }
            AppDomain.Unload(second);
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.Write("From 1 to ");
            Thread thread = new Thread(new ThreadStart(ToConsole));
            thread.Start();
            Thread.Sleep(4000);
            thread.Suspend();
            Thread.Sleep(2000);
            thread.Resume();
            Console.WriteLine($"ManagedThreadId: {thread.ManagedThreadId}   State: {thread.ThreadState}     Priority: {thread.Priority}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Thread onlyOdd = new Thread(OnlyOddNumbers) { Name = "odd" };
            Thread onlyEven = new Thread(OnlyEvenNumbers) { Name = "even" };
            onlyOdd.Start();
            onlyEven.Start();
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Thread firstThread = new Thread(Count1) { Name = "1" };
            Thread secondThread = new Thread(Count2) { Name = "2" };
            firstThread.Start();
            secondThread.Start();
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            TimerCallback tm = new TimerCallback(Timer);
            Timer timer = new Timer(tm, null, 0, 1000);

            Console.ReadLine();
        }
    }
}
