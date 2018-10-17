using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    /*abstract partial class GeneralСharacteristics
    {
        public int Area { get; set; }
    }*/

    enum Enum
    {
        zero, one, two, seven = 7
    }

    struct User
    {
        public string name;
        public int age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }

    public class Container
    {
        public Substance[] array = new Substance[0];
        public Substance Add
        {
            get
            {
                return Add;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Enter correct value.");
                }
                else
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = value;
                }
            }
        }
        public Substance Del
        {
            get
            {
                return Del;
            }
            set
            {
                Console.WriteLine("Enter index of item to remove: ");
                int index = Convert.ToInt32(Console.ReadLine());
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }
        }
        public Substance Out
        {
            get
            {
                return Out;
            }
            set
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine($"Info about {i}-th element");
                    Console.WriteLine(array[i]);
                }
            }
        }
    }

    public class Controller
    {
        public void Task(Container container, string nameToSearch)
        {
            Substance[] check = container.array;
            Island[] islands = new Island[3];
            int counterOfSeas = 0;
            int counterOfIslands = 0;
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] as State != null)
                {
                    if ((check[i] as State).continentName == nameToSearch)
                    {
                        Console.WriteLine("Name of state on this continent - " + (check[i] as State).stateName);
                    }
                }
            }
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] as Sea != null)
                {
                    counterOfSeas++;
                }
            }
            Console.WriteLine("Quantity of seas = " + counterOfSeas);
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] as Island != null)
                {
                    islands[counterOfIslands] = check[i] as Island;
                    counterOfIslands++;
                }
            }
            Island temp;
            for (int i = 0; i < islands.Length - 2; i++)
            {
                for (int j = 0; j < islands.Length - i - 1; j++)
                {
                    string a = (islands[j] as Island).islandName;
                    string b = (islands[j + 1] as Island).islandName;
                    if (String.Compare(a, b) == 1)
                    {
                        temp = islands[j];
                        islands[j] = islands[j + 1];
                        islands[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Island names:");
            for (int i = 0; i < counterOfIslands; i++)
            {
                Console.WriteLine(islands[i].islandName);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Enum.two = " + Enum.two);
            Console.WriteLine("(int)Enum.two = " + (int)Enum.two);
            Console.ReadLine();
            Console.Clear();

            User user = new User { name = "Egor", age = 18 };
            user.DisplayInfo();
            Console.ReadLine();
            Console.Clear();*/

            Container container = new Container();
            Controller controller = new Controller();
            State belarus = new State();
            State brazil = new State();
            Sea sea1 = new Sea();
            Sea sea2 = new Sea();
            Island one = new Island();
            Island two = new Island();
            Island three = new Island();
            Console.WriteLine();
            container.Add = belarus;
            container.Add = brazil;
            container.Add = sea1;
            container.Add = sea2;
            container.Add = one;
            container.Add = two;
            container.Add = three;
            controller.Task(container, "evrasia");






            Console.ReadLine();
        }
    }
}
