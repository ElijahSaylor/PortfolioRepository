using System;
using System.Collections.Generic;
using System.Text;

namespace PE_Interfaces
{
    internal class Point : IPosition
    {
        double Xpos;
        double Ypos;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get { return Xpos; } set { Xpos = value; } }
        public double Y { get { return Ypos; } set { Ypos = value; } }

        public double DistanceTo(IPosition something)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(something.X - X), 2) + Math.Pow(Math.Abs(something.Y - Y), 2));
        }

        public void MoveTo(double x, double y)
        {
            Xpos = x;
            Ypos = y;
        }

        public void MoveBy(double x, double y)
        {
            Xpos += x;
            Ypos += y;
        }

        public override string ToString()
        {
            return $"Position: ({X},{Y})";
        }

    }
}
