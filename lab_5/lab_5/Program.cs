using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    abstract class GeneralСharacteristics
    {
        public string Name { get; set; }
        public int Area { get; set; }
        /*public GeneralСharacteristics()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter area: ");
            Area = Convert.ToInt32(Console.ReadLine());
        }*/
    }

    class Earth : GeneralСharacteristics
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
    }

    class Water : GeneralСharacteristics
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
        //string name;
        //int area;
        int quantityOfLands;
        public Continent()
        {
            Console.WriteLine("\nCreating continent...\n");
            Console.Write("Enter name of continent: ");
            Name = Console.ReadLine();
            Console.Write("Enter area of continent(int): ");
            Area = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("name - " + Name);
            Console.WriteLine("area - " + Area);
            Console.WriteLine("quantityOfLands - " + quantityOfLands);
        }
        public override string ToString()
        {
            return "/nContinent relief - " + relief + ", soil - " + soil + ", name - " + Name
                + ", area - " + Area + ", quantityOfLands - " + quantityOfLands;
        }
    }

    class Island : Earth
    {
        //string name;
        //int area;
        public Island()
        {
            Console.WriteLine("\nCreating island...\n");
            Console.Write("Enter name of island: ");
            Name = Console.ReadLine();
            Console.Write("Enter area of island(int): ");
            Area = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("Island");
            Console.WriteLine("relief - " + relief);
            Console.WriteLine("soil - " + soil);
            Console.WriteLine("name - " + Name);
            Console.WriteLine("area - " + Area);
        }
        public override string ToString()
        {
            return "/nIsland relief - " + relief + ", soil - " + soil + ", name - " + Name
                + ", area - " + Area;
        }
    }

    class State : Continent, IFlight, ISailing
    {
        //string name;
        //int area;
        public State()
        {
            Console.WriteLine("\nCreating state...\n");
            Console.Write("Enter name of state: ");
            Name = Console.ReadLine();
            Console.Write("Enter area of state(int): ");
            Area = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("State");
            Console.WriteLine("relief - " + relief);
            Console.WriteLine("soil - " + soil);
            Console.WriteLine("name - " + Name);
            Console.WriteLine("area - " + Area);
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
            return "/nContinent relief - " + relief + ", soil - " + soil + ", name - " + Name
                + ", area - " + Area;
        }
    }

    sealed class Sea : Water, IFlight, ISailing
    {
        string deepness;
        public Sea()
        {
            Console.WriteLine("\nCreating sea...\n");
            Console.Write("Enter name of sea: ");
            Name = Console.ReadLine();
            Console.Write("Enter area of sea(int): ");
            Area = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter deepness of sea: ");
            deepness = Console.ReadLine();
            Console.Write("\nCreated: ");
            Info();
        }
        public new void Info()
        {
            Console.WriteLine("Sea");
            Console.WriteLine("name - " + Name);
            Console.WriteLine("area - " + Area);
            Console.WriteLine("deepness - " + deepness);
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


    class Program
    {
        static void Main(string[] args)
        {
            //Earth a = new Earth();
            //Earth b = new Earth();

            /*Continent continent = new Continent();
            Console.WriteLine(continent.ToString());*/

            /*State a = new State();
            IFlight state = new State()
            {
                Time = "right now"
            };
            state = a as IFlight;*/

            /*IFlight flight = new State
            {
                Time = "right now"
            };
            Console.WriteLine("Flight to " + flight.To() + " " + flight.Time);
            ISailing sailing = new State
            {
                Time = "tomorrow"
            };
            Console.WriteLine("Sailing to " + sailing.To() + " " + sailing.Time);*/


            /*IFlight flight = new State
            {
                Time = "Right now"
            };
            Console.WriteLine("Flight to " + flight.To() + " " + flight.Time);*/



            //Water b = new Water();
            //Continent c = new Continent();
            //Island d = new Island();

            //Console.WriteLine(a.ToString());
            //Console.WriteLine(a.Equals(b));
            //Console.WriteLine(a.GetHashCode());
            //Console.WriteLine(b.GetHashCode());
            //Console.WriteLine(a.GetType());

            State state = new State();
            Sea sea = new Sea();
            Printer printer = new Printer();
            IFlight[] flights = { state, sea };
            for(int i = 0; i < 2; i++)
            {
                printer.IAmPrinting(flights[i]);
            }


            Console.ReadLine();
        }
    }
}
