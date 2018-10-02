using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_dop
{
    class SimpleClass
    {
        static readonly long baseline;
        int a;
        int b = 7;

        public int A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public int B
        {
            get
            {
                return b;
            }
        }
        public void Method(ref int refArgument)
        {
            refArgument = refArgument + 44;
        }
        public void OutArgExample(out int number)
        {
            number = 44;
        }

        static SimpleClass()
        {
            baseline = DateTime.Now.Ticks;
        }
        public void SimpleInfo()
        {
            Console.WriteLine(baseline);
        }
    }

    class NLog
    {
        private NLog() { }

        public static double e = Math.E;
    }

    public partial class Employee
    {
        public void DoWork()
        {
            Console.WriteLine("DoWork");
        }
    }
    public partial class Employee
    {
        public void GoToLunch()
        {
            Console.WriteLine("GoToLunch");
        }
    }

    class EqualsOverride
    {
        int a = 1;
        int b = 2;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            SimpleClass m = obj as SimpleClass; // возвращает null если объект нельзя привести к типу Money
            if (m as SimpleClass == null)
                return false;
            return m.A == this.a && m.B == this.b;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SimpleClass test = new SimpleClass();
            SimpleClass test1 = new SimpleClass();
            //test.SimpleInfo();
            //test1.SimpleInfo();

            //NLog test2 = new NLog();

            test.A = 654;
            //Console.WriteLine(test.A);
            //test.B = 654;

            int number = 1;
            test.Method(ref number);
            //Console.WriteLine(number);

            int initializeInMethod;
            test.OutArgExample(out initializeInMethod);
            //Console.WriteLine(initializeInMethod);

            Employee part = new Employee();
            //part.DoWork();
            //part.GoToLunch();

            var v = new { Amount = 108, Message = "Hello" };
            Console.WriteLine(v.Amount + "\n" + v.Message);

            Console.ReadLine();
        }
    }
}
