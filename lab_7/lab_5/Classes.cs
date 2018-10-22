using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public abstract partial class Substance //: GeneralСharacteristics
    {
        public Substance() { }
        public new object GetType()
        {
            if (this is Earth)
            {
                return typeof(Earth);
            }
            if (this is Continent)
            {
                return typeof(Continent);
            }
            if (this is Island)
            {
                return typeof(Island);
            }
            if (this is State)
            {
                return typeof(State);
            }
            return typeof(object);
        }
        public virtual void Info() { }
    }

    class Earth : Substance
    {
        public string relief;
        public string soil;
        public Earth()
        {
            Console.WriteLine("\nCreating earth...\n");
            Console.Write("Enter relief: ");
            relief = Console.ReadLine();
            Console.Write("Enter soil: ");
            soil = Console.ReadLine();
            Console.Write("\nCreated: ");
            Info();
        }
        public void Info()
        {
            Console.WriteLine("Earth");
            Console.WriteLine("relief - " + relief);
            Console.WriteLine("soil - " + soil);
        }
        public override string ToString()
        {
            return "\nEarth relief - " + relief + ", soil - " + soil;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Earth a = (Earth)obj;
            if (relief == a.relief && soil == a.soil)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }

    class Water : Substance
    {
        public bool salinity;
        public Water()
        {
            Console.WriteLine("\nCreating water...\n");
            Console.Write("Enter salinity of water:\n1 - true\n2 - false");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 2)
            {
                salinity = false;
            }
            else
            {
                salinity = true;
            }
            Console.Write("\nCreated: ");
            Info();
        }
        public void Info()
        {
            Console.WriteLine("Water");
            Console.WriteLine("salinity - " + salinity);
        }
    }

    class Continent : Earth
    {
        public string continentName;
        public int continentArea;
        int quantityOfLands;
        public Continent()
        {
            Console.WriteLine("\nCreating continent...\n");
            Console.Write("Enter name of continent: ");
            continentName = Console.ReadLine();
            Console.Write("Enter area of continent(int): ");
            continentArea = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter quantity of lands(int): ");
            quantityOfLands = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("Continent");
            Console.WriteLine("relief - " + relief);
            Console.WriteLine("soil - " + soil);
            Console.WriteLine("name - " + continentName);
            Console.WriteLine("area - " + continentArea);
            Console.WriteLine("quantityOfLands - " + quantityOfLands);
        }
        public override string ToString()
        {
            return "/nContinent relief - " + relief + ", soil - " + soil + ", name - " + continentName
                + ", area - " + continentArea + ", quantityOfLands - " + quantityOfLands;
        }
    }

    class Island : Earth
    {
        public string islandName;
        public int islandArea;
        public Island()
        {
            Console.WriteLine("\nCreating island...\n");
            Console.Write("Enter name of island: ");
            islandName = Console.ReadLine();
            Console.Write("Enter area of island(int): ");
            islandArea = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("Island");
            Console.WriteLine("relief - " + relief);
            Console.WriteLine("soil - " + soil);
            Console.WriteLine("name - " + islandName);
            Console.WriteLine("area - " + islandArea);
        }
        public override string ToString()
        {
            return "/nIsland relief - " + relief + ", soil - " + soil + ", name - " + islandName
                + ", area - " + islandArea;
        }
    }

    class State : Continent, IFlight, ISailing
    {
        public string stateName;
        public int stateArea;
        public State()
        {
            Console.WriteLine("\nCreating state...\n");
            Console.Write("Enter name of state: ");
            stateName = Console.ReadLine();
            Console.Write("Enter area of state(int): ");
            stateArea = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("State");
            Console.WriteLine("relief - " + relief);
            Console.WriteLine("soil - " + soil);
            Console.WriteLine("name - " + stateName);
            Console.WriteLine("area - " + stateArea);
        }
        public string Time { get; set; }
        string IFlight.To()
        {
            return "edge of the world by plane";
        }
        string ISailing.To()
        {
            return "edge of the world by ship";
        }
        public override string ToString()
        {
            return "\nState relief - " + relief + ", soil - " + soil + ", name - " + stateName
                + ", area - " + stateArea + "\n";
        }
    }

    sealed class Sea : Water, IFlight, ISailing
    {
        public string seaName;
        public int seaArea;
        public string seaDeepness;
        public Sea()
        {
            Console.WriteLine("\nCreating sea...\n");
            Console.Write("Enter name of sea: ");
            seaName = Console.ReadLine();
            Console.Write("Enter area of sea(int): ");
            seaArea = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter deepness of sea: ");
            seaDeepness = Console.ReadLine();
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("Sea");
            Console.WriteLine("name - " + seaName);
            Console.WriteLine("area - " + seaArea);
            Console.WriteLine("deepness - " + seaDeepness);
        }
        public string Time { get; set; }
        string IFlight.To()
        {
            return "home by plane";
        }
        string ISailing.To()
        {
            return "home by ship";
        }
    }

    interface IFlight
    {
        string Time { get; set; }
        string To();
    }
    interface ISailing
    {
        string Time { get; set; }
        string To();
    }

    class Printer
    {
        public Printer() { }
        public virtual void IAmPrinting(IFlight a)
        {
            Console.WriteLine(a.GetType().ToString());
        }
    }

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
}
