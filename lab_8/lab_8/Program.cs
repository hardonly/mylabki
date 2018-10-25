using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_8
{
    interface IEditable<T>
    {
        void Add();
        int Delete();
        void Look();
    }

    public interface IRight<T>
    {
        int Data { get; set; }
        T Next { get; set; }
    }

    public class Node : IRight<Node>
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node()
        {
            Console.Write("Enter the value of element(int): ");
            Data = Convert.ToInt32(Console.ReadLine());
            Next = null;
        }
    }

    public class Stack<T> : IEditable<T> where T : class, IRight<T>, new()
    {
        public static int counter = 0;
        public T Begin { get; private set; }
        public Stack()
        {
            Begin = null;
        }
        public bool IsEmpty()
        {
            return Begin == null;
        }
        public void Add()
        {
            if (IsEmpty())
            {
                Begin = new T();
                counter++;
                Console.WriteLine("Added element {0}. Total elements {1}", Begin.Data, counter);
            }
            else
            {
                T newNode = new T();
                newNode.Next = Begin;
                Begin = newNode;
                counter++;
                Console.WriteLine("Added element {0}. Total elements {1}", Begin.Data, counter);
            }
        }
        public int Delete()
        {
            if (!IsEmpty())
            {
                T tmp = Begin;
                int a = tmp.Data;
                Begin = tmp.Next;
                tmp.Next = null;
                counter--;
                Console.WriteLine("Extracted element {0}. Total elements {1}", a, counter);
                return a;
            }
            else
            {
                throw new Exception("Stack is already empty.");
            }
        }
        public void Look()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            T temp = Begin;
            Console.Write("\nMy stack: begin -> ");
            for (int i = 0; i < counter; i++)
            {
                Console.Write(temp.Data + " ");
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
                else
                {
                    return;
                }
            }
        }
        public override string ToString()
        {
            T temp = Begin;
            string info = "From head: \n";
            for (int i = 0; i < counter; i++)
            {
                info = info + $"{i}-st data = " + temp.Data + "\n";
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
                else
                {
                    return info;
                }
            }
            return info;
        }
        public static void Save(Stack<T> stack)
        {
            using (FileStream fstream = new FileStream(@"D:\aboutStack.txt", FileMode.Create))
            {
                byte[] array = Encoding.Default.GetBytes(stack.ToString());
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("\nInfo saved.");
            }
        }
        public static void Out()
        {
            using (FileStream fstream = File.OpenRead(@"D:\aboutStack.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine("\nInfo from file: {0}", textFromFile);
            }
        }
    }

    public class Test
    {
        public Test() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> a = new Stack<int>();
            //Stack<Test> b = new Stack<Test>();
            Stack<Node> stack = new Stack<Node>();

            bool exception = false;
            try
            {
                stack.Add();
                stack.Add();
                stack.Add();
                stack.Add();
                //Console.ReadLine();
                //stack.Delete();
                //Console.ReadLine();
                stack.Look();
            }
            catch (Exception ex)
            {
                exception = true;
                Console.WriteLine("\nException: " + ex.Message);
                Console.WriteLine("Method: " + ex.TargetSite);
                Console.WriteLine("Assembly name: " + ex.Source);
                Console.WriteLine("Call address: " + ex.StackTrace);
            }
            finally
            {
                if (exception)
                {
                    Console.WriteLine("\nAn exception was thrown");
                }
                else
                {
                    Console.WriteLine("\nNo exception was thrown");
                }
            }
            Stack<Node>.Save(stack);
            Stack<Node>.Out();


            Console.ReadLine();
        }
    }
}
