using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Введите ваше имя");
            string str = Console.ReadLine();
            Console.WriteLine("Привет " + str + "!!!");
            Console.WriteLine("Введите один символ с клавитуры");
            int kod = Console.Read();
            char sim = (char)kod;
            Console.WriteLine("Код символа {0} = {1}", sim, kod);*/
            int s1 = 255;
            int s2 = 32;
            Console.WriteLine(" \n{0,5}\n+{1,4}\n-----\n{2,5}", s1, s2, s1 + s2);
            Console.WriteLine(" \n{1,5}\n+{0,4}\n-----\n{2,5}", s1, s2, s1 + s2);
            Console.ReadKey();
        }
    }
}
