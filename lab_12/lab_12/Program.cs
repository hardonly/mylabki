using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab_12
{
    public static class Reflector
    {
        public static void OutInfoIntoFile(Type explore)
        {
            using (FileStream fstream = new FileStream(@"F:\\note.txt", FileMode.Create))
            {
                foreach (MemberInfo mi in explore.GetMembers())
                {
                    byte[] array = Encoding.Default.GetBytes(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                    Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                    fstream.Write(array, 0, array.Length);
                }
                Console.WriteLine("\nInfo is written to file.");
            }
        }
        public static void ExtractPublicMethods(Type explore)
        {
            MethodInfo[] publicMethods = new MethodInfo[explore.GetMethods().Length];
            int index = 0;
            foreach(MethodInfo method in explore.GetMethods())
            {
                if (method.IsPublic)
                {
                    publicMethods[index] = method;
                    index++;
                }
            }
            Console.WriteLine("Info about public methods:\n");
            foreach (MethodInfo method in publicMethods)
            {
                Console.Write("public " + method.ReturnType.Name + " " + method.Name + " (");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        public static void ExtractFieldsAndProperties(Type explore)
        {
            Console.WriteLine("Info about fields and properties:\n");
            foreach(FieldInfo field in explore.GetFields())
            {
                Console.WriteLine(field);
            }
            foreach(PropertyInfo property in explore.GetProperties())
            {
                Console.WriteLine(property);
            }
        }
        public static void ExtractInterfaces(Type explore)
        {
            Console.WriteLine("Info about interfaces:\n");
            foreach(Type i in explore.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void ExtractSpecificMethods(Type explore)
        {
            MethodInfo[] rightMethods = new MethodInfo[explore.GetMethods().Length];
            int index = 0;
            Console.Write("Enter parameter type: ");
            string parameterType = Console.ReadLine();
            foreach (MethodInfo method in explore.GetMethods())
            {
                bool flag = false;
                foreach(ParameterInfo parameter in method.GetParameters())
                {
                    if (parameter.ParameterType.Name == parameterType)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    rightMethods[index] = method;
                    index++;
                }
            }
            Console.WriteLine("Info about specific methods:\n");
            foreach (MethodInfo method in rightMethods)
            {
                if (method != null)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
        public static void MethodСall(string typeName, string methodName)
        {
            using (FileStream fstream = File.OpenRead(@"F:\\parameter.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string parameter = Encoding.Default.GetString(array);
                Type explore = Type.GetType($"lab_12.{typeName}");
                object obj = Activator.CreateInstance(explore);
                MethodInfo method = explore.GetMethod(methodName);
                Console.WriteLine("MethodCall:");
                method.Invoke(obj, new object[] { parameter });
            }
        }
    }
    public class Student : IStudent
    {
        public string Name { get; set; }
        public int age;
        public void Write()
        {
            Console.WriteLine("I'm student.");
        }
        public void Scream(string toScream)
        {
            Console.WriteLine(toScream + "!");
        }
    }
    interface IStudent
    {
        string Name { get; set; }
        void Write();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type explore = typeof(Student);
            Reflector.OutInfoIntoFile(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractPublicMethods(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractFieldsAndProperties(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractInterfaces(explore);
            Console.ReadLine();
            Console.Clear();
            Console.Write("Enter type name: ");
            explore = Type.GetType($"lab_12.{Console.ReadLine()}");
            Reflector.ExtractSpecificMethods(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.MethodСall("Student", "Scream");
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractPublicMethods(typeof(Console));
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractFieldsAndProperties(typeof(Console));
            Console.ReadLine();
        }
    }
}
