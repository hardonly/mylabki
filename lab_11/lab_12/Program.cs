using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    public class Point
    {
        public double x;
        public double y;
        readonly int points;
        public Point(int howMuchCoo = 2)
        {
            Console.Write("x=");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            y = Convert.ToInt32(Console.ReadLine());
            points = howMuchCoo;
        }
        public Point(double xPoint, double yPoint, int howMuchCoo = 2)
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
        public string type;
        public double Perimeter
        {
            get
            {
                double perimeter;
                perimeter = SideLength(A, B) + SideLength(B, C) + SideLength(A, C);
                return perimeter;
            }
        }
        public double Area
        {
            get
            {
                double area;
                area = Math.Sqrt((Perimeter / 2) * (Perimeter / 2 - SideLength(A, B))
                    * (Perimeter / 2 - SideLength(B, C)) * (Perimeter / 2 - SideLength(A, C)));
                return area;
            }
        }
        /*public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
            howMuchTriangles++;
        }*/
        public double SideLength(Point first, Point second)
        {
            double length;
            length = Math.Sqrt(Math.Pow(second.x - first.x, 2) + Math.Pow(second.y - first.y, 2));
            return length;
        }
        public double GetPerimeter()
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
            Console.WriteLine("Периметр треугольника = " + GetPerimeter());
            Console.WriteLine("Сколько треугольников уже создано: " + howMuchTriangles);
        }
        public static void WhatAFigure()
        {
            Console.WriteLine("Фигура является треугольником");
        }
        public void WhatAType(List<Triangle> triangleList)
        {
            for (int i = 0; i < triangleList.Count; i++)
            {
                if (triangleList[i].SideLength(triangleList[i].A, triangleList[i].B) == triangleList[i].SideLength(triangleList[i].B, triangleList[i].C)
                    && triangleList[i].SideLength(triangleList[i].B, triangleList[i].C) == triangleList[i].SideLength(triangleList[i].A, triangleList[i].C))
                {
                    triangleList[i].type = "equilateral";
                    continue;
                }
                if (Math.Pow(triangleList[i].SideLength(triangleList[i].A, triangleList[i].B), 2) + Math.Pow(triangleList[i].SideLength(triangleList[i].B, triangleList[i].C), 2)
                    == Math.Pow(triangleList[i].SideLength(triangleList[i].A, triangleList[i].C), 2)
                    || Math.Pow(triangleList[i].SideLength(triangleList[i].A, triangleList[i].B), 2) + Math.Pow(triangleList[i].SideLength(triangleList[i].A, triangleList[i].C), 2)
                        == Math.Pow(triangleList[i].SideLength(triangleList[i].B, triangleList[i].C), 2)
                        || Math.Pow(triangleList[i].SideLength(triangleList[i].B, triangleList[i].C), 2) + Math.Pow(triangleList[i].SideLength(triangleList[i].A, triangleList[i].C), 2)
                            == Math.Pow(triangleList[i].SideLength(triangleList[i].A, triangleList[i].B), 2))
                {
                    triangleList[i].type = "right";
                    continue;
                }
                if (triangleList[i].SideLength(triangleList[i].A, triangleList[i].B) == triangleList[i].SideLength(triangleList[i].B, triangleList[i].C)
                    || triangleList[i].SideLength(triangleList[i].B, triangleList[i].C) == triangleList[i].SideLength(triangleList[i].A, triangleList[i].C)
                        || triangleList[i].SideLength(triangleList[i].A, triangleList[i].C) == triangleList[i].SideLength(triangleList[i].A, triangleList[i].B))
                {
                    triangleList[i].type = "isosceless";
                    continue;
                }
                triangleList[i].type = "arbitrary";
            }
        }
    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[] { "Oktober", "June", "July", "May",
                "December", "September", "January", "February", "Mart", "April", "August", "November" };


            var stringLength = from arr1 in array
                               where arr1.Length == 6
                               select arr1;

            var mounthReturn = from arr2 in array
                               where arr2 == "June" || arr2 == "July" || arr2 == "August"
                               || arr2 == "January" || arr2 == "December" || arr2 == "February"
                               select arr2;

            var mounthAlphabet = from arr3 in array
                                 orderby arr3 ascending
                                 select arr3;

            var lengthAndU = (from arr4 in array
                              where arr4.Contains("u") && arr4.Length >= 4
                              select arr4).Count();
            Console.WriteLine("First request:");
            foreach (string i in stringLength)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine("\n\nSecond request:");
            foreach (string i in mounthReturn)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine("\n\nThird request:");
            foreach (string i in mounthAlphabet)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine($"\n\nFourth request: {lengthAndU}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            List<Triangle> triangles = new List<Triangle>
            {
                new Triangle{ A = new Point(2,2), B = new Point(4,4), C = new Point(1,0) },
                new Triangle{ A = new Point(3,2), B = new Point(4,4), C = new Point(1,3) },
                new Triangle{ A = new Point(5,2), B = new Point(2,4), C = new Point(2,1) },
                new Triangle{ A = new Point(2,2), B = new Point(4,4), C = new Point(1,3) },
                new Triangle{ A = new Point(4,2), B = new Point(3,4), C = new Point(2,4) },
                new Triangle{ A = new Point(2,2), B = new Point(4,4), C = new Point(2,4) },
                new Triangle{ A = new Point(3,2), B = new Point(4,4), C = new Point(1,3) },
                new Triangle{ A = new Point(5,2), B = new Point(2,4), C = new Point(2,1) },
                new Triangle{ A = new Point(2,2), B = new Point(4,4), C = new Point(1,3) },
                new Triangle{ A = new Point(4,2), B = new Point(3,4), C = new Point(2,4) }
            };
            triangles[1].WhatAType(triangles);
            var quantityEquilateral = (from i in triangles
                                       where i.type == "equilateral"
                                       select i).Count();
            var quantityRight = (from i in triangles
                                 where i.type == "right"
                                 select i).Count();
            var quantityIsosceless = (from i in triangles
                                      where i.type == "isosceless"
                                      select i).Count();
            var quantityArbitrary = (from i in triangles
                                     where i.type == "arbitrary"
                                     select i).Count();
            var minRight = (from i in triangles
                            where i.type == "right"
                            select i).Min(i => i.Perimeter);
            var minIsosceless = (from i in triangles
                                 where i.type == "isosceless"
                                 select i).Min(i => i.Perimeter);
            var minArbitrary = (from i in triangles
                                where i.type == "arbitrary"
                                select i).Min(i => i.Perimeter);
            var maxRight = (from i in triangles
                            where i.type == "right"
                            select i).Max(i => i.Perimeter);
            var maxIsosceless = (from i in triangles
                                 where i.type == "isosceless"
                                 select i).Max(i => i.Perimeter);
            var maxArbitrary = (from i in triangles
                                where i.type == "arbitrary"
                                select i).Max(i => i.Perimeter);
            var minArea = triangles.Min(i => i.Area);
            var trianglesFromRange = (from i in triangles
                                      where i.SideLength(i.A, i.B) <= 4 && i.SideLength(i.A, i.B) >= 2
                                      && i.SideLength(i.B, i.C) <= 4 && i.SideLength(i.B, i.C) >= 2
                                      && i.SideLength(i.A, i.C) <= 4 && i.SideLength(i.A, i.C) >= 2
                                      select i).Count();
            var orderedByPerimeter = triangles.OrderByDescending(i => i.Perimeter);
            Console.WriteLine($"quantityEquilateral = {quantityEquilateral}");
            Console.WriteLine($"quantityRight = {quantityRight}");
            Console.WriteLine($"quantityIsosceless = {quantityIsosceless}");
            Console.WriteLine($"quantityArbitrary = {quantityArbitrary}");
            Console.WriteLine($"minRight = {minRight}");
            Console.WriteLine($"minIsosceless = {minIsosceless}");
            Console.WriteLine($"minArbitrary = {minArbitrary}");
            Console.WriteLine($"maxRight = {maxRight}");
            Console.WriteLine($"maxIsosceless = {maxIsosceless}");
            Console.WriteLine($"maxArbitrary = {maxArbitrary}");
            Console.WriteLine($"minArea = {minArea}");
            Console.WriteLine($"trianglesFromRange = {trianglesFromRange}");
            Console.WriteLine("\n\norderedByPerimeter:\n");
            foreach (var i in orderedByPerimeter)
            {
                Console.WriteLine(i.Perimeter + " ");
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("My request");
            var myRequest = (from i in triangles
                             where i.Perimeter > 7
                             select i).OrderBy(i => i.Perimeter).Reverse().First().Area;
            Console.WriteLine($"\nmyRequest = {myRequest}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var result = players.Join(teams, p => p.Team, t => t.Name,
                (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country });
            foreach (var item in result)
                Console.WriteLine("{0} - {1} ({2})", item.Name, item.Team, item.Country);
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
