using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    public class Node
    {
        public int data;
        public Node next;
        public Node()
        {
            data = 0;
            next = null;
        }
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
    public class Stack
    {
        public int counter = 0;
        public Stack()
        {
            Begin = null;
        }
        public int Quantity()
        {
            return counter;
        }
        public bool IsEmpty()
        {
            return Begin == null;
        }
        public void Push(int data)
        {
            if (IsEmpty())
            {
                Begin = new Node(data);
                counter++;
                Console.WriteLine("Added element {0}. Total elements {1}", Begin.data, counter);
            }
            else
            {
                Node newNode = new Node(data);
                newNode.next = Begin;
                Begin = newNode;
                counter++;
                Console.WriteLine("Added element {0}. Total elements {1}", Begin.data, counter);
            }
        }
        public int Pop()
        {
            if (!IsEmpty())
            {
                Node tmp = Begin;
                int a = tmp.data;
                Begin = tmp.next;
                tmp.next = null;
                counter--;
                Console.WriteLine("Extracted element {0}. Total elements {1}", a, counter);
                return a;
            }
            else
            {
                throw new Exception("Stack is already empty.");
            }
        }
        public Node Begin { get; private set; }
        public static class MathOperations
        {
            static int min = 0;
            static int max = 0;
            public static void MaxAndMin(int[] array)
            {
                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                }
                Console.WriteLine($"\n\nMax={max}");
                Console.WriteLine($"\nMin={min}");
            }
            public static int HowMuchelements(Stack s)
            {
                return s.Quantity();
            }
        }
        public class Owner
        {
            public int id;
            public string name;
            public string organization;
            public Owner()
            {
                id = 27012000;
                name = "Egor";
                organization = "BelSTU";
            }
        }
        public class Date
        {
            public string data;
            public Date()
            {
                data = "03 oktober 2018";
            }
        }
        public static int operator +(Stack s1, int a)
        {
            s1.Push(a);
            return a;
        }
        public static Stack operator --(Stack s1)
        {
            s1.Pop();
            return s1;
        }
        public static bool operator true(Stack s1)
        {
            return s1.IsEmpty();
        }
        public static bool operator false(Stack s1)
        {
            return s1.IsEmpty();
        }
        public static bool operator >(Stack s1, Stack s2)
        {
            if (s1.IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return false;
            }
            int[] elements = new int[s1.Quantity()];
            int howMuchElements = s1.Quantity();
            for (int i = 0; i < howMuchElements; i++)
            {
                elements[i] = s1.Pop();
            }
            for (int i = 0; i < howMuchElements; i++)
            {
                s1.Push(elements[howMuchElements - i - 1]);
            }
            Array.Sort(elements);
            for (int i = 0; i < howMuchElements; i++)
            {
                s2.Push(elements[i]);
            }
            return true;
        }
        public static bool operator <(Stack s1, Stack s2)
        {
            return false;
        }
    }
    public static class StackExtansion
    {
        public static int Count(this Stack s)
        {
            int count = 0;
            if (s.IsEmpty())
            {
                return count;
            }
            int length = s.Quantity();
            int[] elements = new int[length];
            for (int i = 0; i < length; i++)
            {
                elements[i] = s.Pop();
                if (elements[i] >= 10 && elements[i] <= 99)
                {
                    count++;
                }
            }
            for (int i = 0; i < length; i++)
            {
                s.Push(elements[length - i - 1]);
            }
            return count;
        }
        public static int Average(this Stack s)
        {
            int average = -1;
            if (s.IsEmpty())
            {
                return average;
            }
            int length = s.Quantity();
            int[] elements = new int[length];
            int min = 0;
            int max = 0;
            for (int i = 0; i < length; i++)
            {
                elements[i] = s.Pop();
            }
            for (int i = 0; i < length; i++)
            {
                s.Push(elements[length - i - 1]);
            }
            for (int i = 0; i < length; i++)
            {
                if (min == 0 || min > elements[i])
                {
                    min = elements[i];
                }
                if (max == 0 || max < elements[i])
                {
                    max = elements[i];
                }
            }
            int idealAverage = (max - min) / 2;
            for (int i = 0; i < idealAverage - 1; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (elements[j] == idealAverage + i)
                    {
                        average = idealAverage + i;
                        return average;
                    }
                    if (elements[j] == idealAverage - i)
                    {
                        average = idealAverage - i;
                        return average;
                    }
                }
            }
            return average;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack s1 = new Stack();
            int newElem = s1 + 7;
            newElem = s1 + 9;
            newElem = s1 + 65;
            newElem = s1 + 67;
            newElem = s1 + 4;
            s1--;
            s1--;
            if (s1)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            Stack s2 = new Stack();
            bool result = s1 > s2;

            Console.WriteLine(s1.Count());

            Console.WriteLine("Average element of stack is {0}", s1.Average());
        }
    }
}