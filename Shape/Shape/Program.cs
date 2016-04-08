using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Circle v. Circle ...");
            Console.WriteLine((new Circle().Equals(new Circle())));

            Console.WriteLine("Running Rectangle v. Rectangle ...");
            Console.WriteLine(new Rectangle().Equals(new Rectangle()));

            Console.WriteLine("Running Circle v. Rectangle ...");
            Console.WriteLine(new Circle().Equals(new Rectangle()));

            Console.WriteLine("Printing Circle properties ...");
            Console.WriteLine(new Circle().ToString());

            Console.WriteLine("Running Rectangle properties ...");
            Console.WriteLine(new Rectangle().ToString());

            Console.ReadLine();
        }
    }

    public abstract class Shape
    {
        public string Type { get; protected set; }
        public abstract int CalculateArea();
    }

    class Circle : Shape
    {
        public Circle()
        {
            Type = "Circle";
        }

        public override int CalculateArea()
        {
            return 83;
        }

        public override bool Equals(object obj)
        { // from https://msdn.microsoft.com/en-us/library/ms173147(VS.80).aspx
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Circle c = obj as Circle;
            if ((System.Object)c == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ToString() == c.ToString());
        }

        public override string ToString()
        {
            return (string.Format("Type: {0}\nArea: {1}", Type, CalculateArea()));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class Rectangle : Shape
    {
        public Rectangle()
        {
            Type = "Rectangle";
        }

        public override int CalculateArea()
        {
            return 257;
        }

        public override string ToString()
        {
            return (string.Format("Type: {0}\nArea: {1}", Type, CalculateArea()));
        }

        public override bool Equals(object obj)
        { // from https://msdn.microsoft.com/en-us/library/ms173147(VS.80).aspx
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Rectangle c = obj as Rectangle;
            if ((System.Object)c == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ToString() == c.ToString());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
