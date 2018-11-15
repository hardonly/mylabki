using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab_10
{
    class Student { }
    public class Sea : IComparable, IComparer
    {
        public string Name { get; set; }
        public int CompareTo(object o)
        {
            if (o as Sea != null)
                return Compare(this, o as Sea);
            else
                throw new Exception("Impossible to compare 2 objects");
        }
        public int Compare(object x, object y)
        {
            if ((x as Sea).Name.Length > (y as Sea).Name.Length)
                return 1;
            else if ((x as Sea).Name.Length < (y as Sea).Name.Length)
                return -1;
            else
                return 0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            Random random = new Random();
            list.AddRange(new int[] { random.Next(10), random.Next(10), random.Next(10), random.Next(10), random.Next(10) });
            list.AddRange(new string[] { "test1", "test2", "test3" });
            Student student = new Student();
            list.Add(student);
            list.Remove("test2");
            Console.WriteLine("Count of list elements " + list.Count + "\nMy arrayList: ");
            foreach (object obj in list)
            {
                Console.Write(obj + " ");
            }
            Console.WriteLine("\n" + list.Contains("test1"));

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(random.Next(10));
            }
            Console.WriteLine("\nMy queue: ");
            foreach(int i in queue)
            {
                Console.Write(i + " ");
            }
            for(int i = 0; i < 3; i++)
            {
                queue.Dequeue();
            }
            Console.WriteLine("\nMy queue after dequeue: ");
            foreach (int i in queue)
            {
                Console.Write(i + " ");
            }

            SortedDictionary<int, int> keyValues = new SortedDictionary<int, int>();
            int localCount = queue.Count;
            for(int i = 0; i < localCount; i++)
            {
                keyValues.Add(i, queue.Dequeue());
            }
            Console.WriteLine("\n\nMy sortedDictionary: ");
            foreach(object obj in keyValues)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine(keyValues.ContainsValue(9));

            Queue<Sea> seas = new Queue<Sea>();
            seas.Enqueue(new Sea() { Name = "black" });
            seas.Enqueue(new Sea() { Name = "red" });
            seas.Enqueue(new Sea() { Name = "yellow" });
            Console.WriteLine("\nMy seas:");
            foreach(object obj in seas)
            {
                Console.Write((obj as Sea).Name + " ");
            }
            SortedDictionary<int, Sea> sortedSeas = new SortedDictionary<int, Sea>();
            localCount = seas.Count;
            for (int i = 0; i < localCount; i++)
            {
                sortedSeas.Add(i, seas.Dequeue());
            }
            Console.WriteLine(sortedSeas.Count);
            Console.WriteLine("My sortedDictionary: ");
            foreach (object obj in sortedSeas)
            {
                Console.WriteLine(obj);
            }

            ObservableCollection<Sea> mySeas = new ObservableCollection<Sea>();
            mySeas.CollectionChanged += CollectionChangeMethod;
            mySeas.Add(new Sea { Name = "black" });
            mySeas.Add(new Sea { Name = "red" });
            mySeas.Add(new Sea { Name = "yellow" });
            mySeas.RemoveAt(2);
            Console.WriteLine("\nMy observableCollection: ");
            foreach(object obj in mySeas)
            {
                Console.Write(obj + " ");
            }

            Console.ReadLine();
        }
        public static void CollectionChangeMethod(object obj, NotifyCollectionChangedEventArgs n)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Collection chenged");
            Console.ResetColor();
        }
    }
}
