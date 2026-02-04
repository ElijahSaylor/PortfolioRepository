// Elijah Saylor
// Interface PE
// 1/15/2026

namespace PE_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(5, 7);
            Point point2 = new Point(10, 10);
            Circle circle1 = new Circle(10,10,3);
            Circle circle2 = new Circle(0,0,5);

            Console.WriteLine("\n-----Initial Print-----\n");

            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(circle1);
            Console.WriteLine(circle2);

            Console.WriteLine("\n-------Move point2 to 2,2-----\n");

            point2.MoveTo(2, 2);
            Console.WriteLine(point2);

            Console.WriteLine("\n-------Move circle2 by -1,-1 -----\n");

            circle2.MoveBy(-1, -1);
            Console.WriteLine(circle2);

            Console.WriteLine("\n-------distance of point 1 to point 2-----\n");

            Console.WriteLine(point1.DistanceTo(point2));

            Console.WriteLine("\n-------circles to points-----\n");

            Console.WriteLine($"Distance of point1 to circle 1: {point1.DistanceTo(circle1)}");
            Console.WriteLine($"Distance of point1 to circle 2: {point1.DistanceTo(circle2)}");
            Console.WriteLine($"Distance of point2 to circle 1: {point2.DistanceTo(circle1)}");
            Console.WriteLine($"Distance of point2 to circle 2: {point2.DistanceTo(circle2)}");

            Console.WriteLine("\n-------circle areas-----\n");

            Console.WriteLine("circle 1 area: " + circle1.Area);
            Console.WriteLine("circle 2 area: " + circle2.Area);

            Console.WriteLine("\n-------does X circle contain Y point?-----\n");

            Console.WriteLine($"Does circle 1 contain point 1? " + circle1.ContainsPosition(point1));
            Console.WriteLine($"Does circle 1 contain point 2? " + circle1.ContainsPosition(point2));
            Console.WriteLine($"Does circle 2 contain point 1? " + circle2.ContainsPosition(point1));
            Console.WriteLine($"Does circle 2 contain point 2? " + circle2.ContainsPosition(point2));

        }
    }
}
