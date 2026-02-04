using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PE_Interfaces
{
    internal class Circle : IPosition, IArea
    {
        double Xpos;
        double Ypos;
        double radius;

        #region properties
        public double X { get { return Xpos; } set { Xpos = value; } }
        public double Y { get { return Ypos; } set { Ypos = value; } }
        public double Area
        {
            get { return (Math.PI * Math.Pow(radius, 2)); }
        }
        public double Perimeter { get { return radius * 2 * (float)Math.PI; } }
        #endregion

        #region constructors
        // default constructor
        public Circle()
        {
            Xpos = 0;
            Ypos = 0;
            radius = 1;
        }
        // P constructor
        public Circle(float x, float y, float radius)
        {
            this.Xpos = x;
            this.Ypos = y;
            this.radius = radius;
        }
        #endregion

        #region methods
        public double DistanceTo(IPosition something)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(something.X - X),2) + Math.Pow(Math.Abs(something.Y - Y),2));
        }

        public void MoveTo(double x, double y)
        {
            Xpos = x;
            Ypos = y;
        }

        public void MoveBy(double x,double y)
        {
            Xpos += x;
            Ypos += y;
        }

        public bool IsLargerThan(IArea thing)
        {
            if (Area > thing.Area) return true;
            else return true;

        }

        public bool ContainsPosition(IPosition thing)
        {
            if (DistanceTo(thing) <= radius) return true;
            else return false;
        }

        public override string ToString()
        {
            return $"Circle Position: ({X},{Y})\n" +
                $"Radius: {radius}\n" +
                $"Area: {Area}\n" +
                $"Perimeter: {Perimeter}";
        }
        #endregion

        


    }
}
