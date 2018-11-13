using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public delegate void ProgrammingLanguageStateHandler(string message);
    delegate void Programmer();
    public class ProgrammingLanguage
    {
        public string name;
        public string property;
        public string version;
        public event ProgrammingLanguageStateHandler Rename;
        public event ProgrammingLanguageStateHandler Property;
        public event ProgrammingLanguageStateHandler Version;
        public ProgrammingLanguage()
        {
            name = "C#";
            property = "good";
            version = "8.0";
        }
        public void SetName()
        {
            name = "Java";
            if (Rename != null)
                Rename($"Name changed to {name}");
        }
        public void SetProperty()
        {
            property = "perfect";
            if (Property != null)
                Property($"Changed property to {property}");
        }
        public void SetVersion()
        {
            version = "SE 11";
            if (Version != null)
                Version($"Version updated to {version}");
        }
        public void Info()
        {
            Console.WriteLine($"Name = {name}\nProperty = {property}\nVersion = {version}\n");
        }
    }
    class Program
    {
        static void DisplayWithColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void Out(string value)
        {
            Console.WriteLine(value);
        }
        static void FirstWord(string value)
        {
            string[] words = value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"The first word is {words[0]}");
        }
        static string Add(int x, string value)
        {
            value = value.Insert(x, ", just perfect");
            return value;
        }
        static string Replace(int x, string value)
        {
            if (x == 1)
            {
                value = value.Replace("Good, just ", "");
            }
            else
            {
                value = value.Replace("Good, ", "");
            }
            return value;
        }
        static string ToUpperCase(int x, string value)
        {
            
            if (x == 1)
            {
                return Char.ToUpper(value[0]) + value.Substring(1);
            }
            else
            {
                return value.ToUpper();
            }
        }
        static void Main(string[] args)
        {
            ProgrammingLanguage language = new ProgrammingLanguage();
            language.Info();
            language.Rename+=DisplayWithColor;
            language.Property+=DisplayWithColor;
            language.Version+=DisplayWithColor;
            language.SetName();
            language.SetProperty();
            language.SetVersion();
            Console.WriteLine();
            language.Info();

            Console.ReadLine();

            Action<string> action;
            //Action<string> _out = Out;
            //Action<string> _firstWord = FirstWord;
            string value = "Good day";
            action = Out;
            action += FirstWord;
            action(value);
            action -= FirstWord;
            Func<int, string, string> func;
            func = Add;
            value = func(4, value);
            action(value);
            func = Replace;
            value = func(2, value);
            action(value);
            func = ToUpperCase;
            value = func(1, value);
            action(value);

            Console.ReadLine();
        }
    }
}
