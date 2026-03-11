using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_OOP
{
    public abstract class Shape
    {
        public string Name { get; private set; }
        public Shape(string name)
        {
            Name = name;
        }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public override string ToString()
        {
            return $"{Name} - Area: {GetArea():N2}, Perimeter: {GetPerimeter():N2}";
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle("circle", 45.5);
            Shape anotherCirle = new Circle("another circle", 30.5);
            Console.WriteLine(circle.GetPerimeter());
            Console.WriteLine(circle.ToString());

        }
    }
}
