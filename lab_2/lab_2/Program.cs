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
            var var = 10;   //Определите переменные примитивных типов С# и проинициализируйте их
            byte bait = 255;
            sbyte sbait = -128;
            int num = -12;
            int a;
            short s = 10;
            ushort us = 10;
            uint num_1 = 10;
            uint u;
            long lon = 43243;
            ulong ulon = 4334432423;
            float num_2 = 1.23f;
            float b;
            double num_3 = 4.5678d;
            double c;
            decimal dec = 77.777m;
            bool boolean = true;
            string name = "Egor";
            string l;
            char letter = 'E';
            object bei = 2132432;
            

            a = (int)num_2;    //явные преобразования
            b = (float)num_3;
            a = (int)num_3;
            u = (uint)num_2;
            s = (short)num;

            b = num;    //неявные преобразования
            c = b;
            a = s;
            lon = a;
            num_3 = lon;

            int i = 123;    //упаковка
            object o = i;
            o = 123;    //распаковка
            i = (int)o;

            var v = "Hello";    //работа с неявно типизированной переменной
            string blabla;
            blabla = v + v;

            int? z1 = 5;    //пример работы с nullable
            bool? enabled1 = null;
            Nullable<int> z2 = 5;
            Nullable<bool> enabled2 = null;

            string elefant = "Elefant";     //строки
            string rabbit = "Rabbit";
            string elef = "Elefant is big";
            string rabb = "Rabbit is small";

            String.Compare("a","b"); //вернёт -1

            string sum_of_strings;      //сцепление
            sum_of_strings = elefant + rabbit;
            
            int startIndex = 8;     //выделение подстроки
            int length = 2;
            string substring_elef = elef.Substring(startIndex, length);

            string[] words = rabb.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //разбиение на слова
            /*foreach (string strtttr in words)
            {
                Console.WriteLine(strtttr);
            }*/

            string text = "Хороший день";   //вставка подстроки
            string subString = "замечательный ";
            text = text.Insert(8, subString);
            //Console.WriteLine(text);

            elef = elef.Remove(0, 2);   //удаление подстроки
            rabb = rabb.Replace("is ", "");
            //Console.WriteLine(rabb);

            string empty = "";      //путсные строки
            string null_ = null;
            //Console.WriteLine(String.IsNullOrWhiteSpace(empty));
            //Console.WriteLine(String.IsNullOrEmpty(null_));

            StringBuilder sb = new StringBuilder("название");   //StringBuilder
            sb = sb.Remove(1, 7);
            sb = sb.Insert(0, "о");
            sb = sb.Insert(sb.Length, "и");
            //Console.WriteLine(sb);

            int[,] intArr = new int[4, 5];   //целый двумерный массив
            Random ran = new Random();
            for(int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 5; j++)
                {
                    intArr[k, j] = ran.Next(1, 15);
                    //Console.Write("{0}\t", intArr[k, j]);
                }
                //Console.WriteLine();
            }

            string[] strs = new string[] { "Hello", "World", "Good", "Day" };   //массив строк
            /*for (int k = 0; k < strs.Length; k++)
            {
                Console.WriteLine(strs[k]);
            }
            Console.WriteLine("Длина массива " + strs.Length);

            Console.WriteLine("Введите номер элемента, который хотите поменять(1-4): ");
            int toReplace = Convert.ToInt16(Console.ReadLine()) - 1;
            Console.WriteLine("Введите значение, на которое хотите поменять: ");
            string newMember = Console.ReadLine();
            strs[toReplace] = newMember;
            for (int k = 0; k < strs.Length; k++)
            {
                Console.WriteLine(strs[k]);
            }*/

            int d = 0;      //ступенчатый массив
            int[][] myArr = new int[3][];
            myArr[0] = new int[2];
            myArr[1] = new int[3];
            myArr[2] = new int[4];
            for (; d < 2; d++)
            {
                myArr[0][d] = d;
                //Console.Write("{0}\t", myArr[0][d]);
            }
            //Console.WriteLine();
            for (d = 0; d < 3; d++)
            {
                myArr[1][d] = d;
                //Console.Write("{0}\t", myArr[1][d]);
            }
            //Console.WriteLine();
            for (d = 0; d < 4; d++)
            {
                myArr[2][d] = d;
                //Console.Write("{0}\t", myArr[2][d]);
            }

            var tup = (count: 5, items: "words", letter1: 'w', words: "items", longg: 45234);   //кортежи

            /*Console.WriteLine(tup.count);
            Console.WriteLine(tup.items);
            Console.WriteLine(tup.letter1);
            Console.WriteLine(tup.words);
            Console.WriteLine(tup.longg);*/

            int[] intArray = new int[] { 1, 2, 3, 4, 5 }; //???????????????????
            string abs = "func";
            (int, int, int, string) ourTuple;
            void buildTuple(int[] numbers, string ourString)
            {
                
            }

            Console.ReadLine();
        }
    }
}
