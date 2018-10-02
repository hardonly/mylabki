using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class Point
    {
        public int x;
        public int y;
        readonly int points;
        public Point(int howMuchCoo = 2)
        {
            Console.Write("x=");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            y = Convert.ToInt32(Console.ReadLine());
            points = howMuchCoo;
        }
        public Point(int xPoint, int yPoint, int howMuchCoo = 2)
        {
            x = xPoint;
            y = yPoint;
            points = howMuchCoo;
        }
    }

    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;
        const int howMuchSides = 3;
        static int howMuchTriangles = 0;
        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
            howMuchTriangles++;
        }
        public double SideLength(Point first, Point second)
        {
            double length;
            length = Math.Sqrt(Math.Pow(second.x - first.x, 2) + Math.Pow(second.y - first.y, 2));
            return length;
        }
        public double Perimeter()
        {
            double perimeter;
            perimeter = SideLength(A, B) + SideLength(B, C) + SideLength(A, C);
            return perimeter;
        }
        public void TriangleInfo()
        {
            Console.WriteLine("Ax=" + A.x + " Ay=" + A.y);
            Console.WriteLine("Bx=" + B.x + " By=" + B.y);
            Console.WriteLine("Cx=" + C.x + " Cy=" + C.y);
            Console.WriteLine("Длина стороны AB = " + SideLength(A, B));
            Console.WriteLine("Периметр треугольника = " + Perimeter());
            Console.WriteLine("Сколько треугольников уже создано: " + howMuchTriangles);
        }
        public static void WhatAFigure()
        {
            Console.WriteLine("Фигура является треугольником");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            const int quantityTriangles = 3;
            Triangle[] triangleArray = new Triangle[quantityTriangles];
            Triangle[] equilateralTriangles = new Triangle[quantityTriangles];
            Triangle[] isoscelesTriangles = new Triangle[quantityTriangles];
            Triangle[] rightTriangles = new Triangle[quantityTriangles];
            Triangle[] arbitraryTriangles = new Triangle[quantityTriangles];
            int quantityEquilateral = 0;
            int quantityIsosceles = 0;
            int quantityRight = 0;
            int quantityArbitrary = 0;
            for (int i = 0; i < quantityTriangles; i++)
            {
                Console.WriteLine("Введите параметры нового треугольника:\n");
                Triangle newTriangle = new Triangle();
                triangleArray[i] = newTriangle;
                Console.Clear();
            }
            for (int i = 0; i < quantityTriangles; i++)
            {
                Triangle check = triangleArray[i];
                if (check.SideLength(check.A, check.B) == check.SideLength(check.B, check.C)
                    && check.SideLength(check.B, check.C) == check.SideLength(check.A, check.C))
                {
                    equilateralTriangles[i] = check;
                    quantityEquilateral++;
                    continue;
                }
                if (Math.Pow(check.SideLength(check.A, check.B), 2) + Math.Pow(check.SideLength(check.B, check.C), 2)
                    == Math.Pow(check.SideLength(check.A, check.C), 2)
                    || Math.Pow(check.SideLength(check.A, check.B), 2) + Math.Pow(check.SideLength(check.A, check.C), 2)
                        == Math.Pow(check.SideLength(check.B, check.C), 2)
                        || Math.Pow(check.SideLength(check.B, check.C), 2) + Math.Pow(check.SideLength(check.A, check.C), 2)
                            == Math.Pow(check.SideLength(check.A, check.B), 2))
                {
                    rightTriangles[i] = check;
                    quantityRight++;
                    continue;
                }
                if (check.SideLength(check.A, check.B) == check.SideLength(check.B, check.C)
                    || check.SideLength(check.B, check.C) == check.SideLength(check.A, check.C)
                        || check.SideLength(check.A, check.C) == check.SideLength(check.A, check.B))
                {
                    isoscelesTriangles[i] = check;
                    quantityIsosceles++;
                    continue;
                }
                arbitraryTriangles[i] = check;
                quantityArbitrary++;
            }
            const int quantityArrays = 4;
            int[] lengths = new int[quantityArrays];
            Triangle[][] ourTriangles = new Triangle[quantityArrays][];
            lengths[0] = quantityEquilateral;
            lengths[1] = quantityIsosceles;
            lengths[2] = quantityRight;
            lengths[3] = quantityArbitrary;
            ourTriangles[0] = equilateralTriangles;
            ourTriangles[1] = isoscelesTriangles;
            ourTriangles[2] = rightTriangles;
            ourTriangles[3] = arbitraryTriangles;
            for (int i = 0; i < quantityArrays; i++)
            {
                Console.WriteLine("Кол-во таких треугольников " + lengths[i] + ": " + MinMax(ourTriangles[i], lengths[i]));
            }

            
            string MinMax(Triangle[] triangles, int arrayLength)
            {
                double min = 0;
                double max = 0;
                if (arrayLength == 0)
                {
                    return "Таких треугольников нет";
                }
                for (int i = 0; i < quantityTriangles; i++)
                {
                    if (triangles[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (min == 0 || min > triangles[i].Perimeter())
                        {
                            min = triangles[i].Perimeter();
                        }
                        if (max == 0 || max < triangles[i].Perimeter())
                        {
                            max = triangles[i].Perimeter();
                        }
                    }
                }
                return "Минимальный периметр = " + min.ToString() + "; Максимальный периметр = " + max.ToString();
            }

            Console.ReadLine();
        }
    }
}
