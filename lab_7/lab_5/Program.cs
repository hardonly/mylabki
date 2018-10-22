using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab_5
{
    public class MyException
    {
        public string value;
        public MyException() { }
        public void ExceptionMethod()
        {
            Console.Write("Enter any int value: ");
            value = Console.ReadLine();
            if (value == "")
            {
                Console.WriteLine("Incorrect value, empty string.\nvalue = null");
                value = null;
            }
            else
            {
                Console.WriteLine($"Correct value.\nvalue = {value}");
            }
        }
    }
    public class ArrayException : MyException
    {
        public void ArrExceptionMethod()
        {
            int[] array = new int[10];
            Console.Write("My array: ");
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                Console.Write(array[i] + " ");
            }
            Console.Write("\nWhat element do you want to write? ");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > array.Length || index < 0)
            {
                Console.WriteLine("Incorrect index.");
            }
            else
            {
                Console.WriteLine($"Element with index {index} = {array[index]}");
            }
        }
    }
    public class ZeroDivision : ArrayException
    {
        public void ZeroDivisionException()
        {
            float dividend;
            float divider;
            Console.Write("\nEnter the divident: ");
            dividend = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the divider: ");
            divider = Convert.ToInt32(Console.ReadLine());
            if (divider == 0)
            {
                Console.WriteLine("Incorrect divider. Division by zero.");
            }
            else
            {
                Console.WriteLine($"Result of the division = {dividend / divider}");
            }
        }
    }

    public class ChildException : Exception
    {
        public ChildException(string message) : base(message) { }
    }

    public class Child
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    throw new ChildException("\nEmptyChildName");
                }
                else
                {
                    name = value;
                }
            }
        }
    }

    public class MyValue
    {
        public void ValueMethod()
        {
            try
            {
                Console.Write("\nEnter some number: ");
                string myvalue = Console.ReadLine();
                int result = int.Parse(myvalue);
                Console.WriteLine($"value = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException: " + ex.Message);
                Console.WriteLine("Method: " + ex.TargetSite);
                Console.WriteLine("Assembly name: " + ex.Source);
                Console.WriteLine("Call address: " + ex.StackTrace);
                Console.WriteLine("Set default value.\nmyvalue = 0");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*MyException myException = new MyException();
            myException.ExceptionMethod();*/

            /*ArrayException arrayException = new ArrayException();
            arrayException.ArrExceptionMethod();*/

            /*ZeroDivision division = new ZeroDivision();
            division.ZeroDivisionException();*/

            /*Child child = new Child();
            try
            {
                child.Name = "";
            }
            catch(ChildException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Method: " + ex.TargetSite);
                Console.WriteLine("Assembly name: " + ex.Source);
                Console.WriteLine("Call address: " + ex.StackTrace);
            }
            finally
            {
                child.Name = "Egor";
                Console.WriteLine($"Set default child name - {child.Name}");
            }*/

            /*MyValue myValue = new MyValue();
            myValue.ValueMethod();*/

            /*int[] arr = null;
            Debug.Assert(arr != null, "Values array cannot be null");
            Console.WriteLine("Сontinue");*/




            Console.ReadLine();
        }
    }
}
