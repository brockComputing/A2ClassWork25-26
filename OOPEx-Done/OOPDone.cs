using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPPExerciseShapes
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
    public class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }
    public class Triangle : Shape
    {
        public double TheBase { get; private set; }
        public double Height { get; private set; }
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(string name, double thebase, double height, double sideA, double sideB, double sideC) : base(name)
        {
            TheBase = thebase;
            Height = height;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetArea()
        {
            return 0.5 * TheBase * Height;
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
    public class ShapeManager
    {
        private List<Shape> Shapes;

        public ShapeManager()
        {
            Shapes = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void DisplayShapes()
        {
            foreach (var shape in Shapes)
            {
                Console.WriteLine(shape.ToString());
                Console.WriteLine(shape.GetArea());
            }
        }
    }

    internal class OOPDone
    {
        static void Main(string[] args)
        {
            #region step3
            Circle circle = new Circle("circle", 45.5);
            Console.WriteLine(circle.GetArea());
            Console.WriteLine(circle.ToString());
            Shape circle2 = new Circle("another circle", 5.5);
            Console.WriteLine(circle2.ToString());
            #endregion
            #region step6
            Shape rectangle = new Rectangle("Rectangle", 4.0, 6.0);
            Shape triangle = new Triangle("Triangle", 3.0, 4.0, 3.0, 4.0, 5.0);
            Console.WriteLine(rectangle.GetPerimeter());
            Console.WriteLine(triangle.ToString());
            #endregion
            //Shape circle = new Circle("Circle", 5.0);
            //Shape rectangle = new Rectangle("Rectangle", 4.0, 6.0);
            //Shape triangle = new Triangle("Triangle", 3.0, 4.0, 3.0, 4.0, 5.0);

            //// Create shape manager and add shapes
            ShapeManager shapeManager = new ShapeManager();
            shapeManager.AddShape(circle);
            shapeManager.AddShape(circle2);
            shapeManager.AddShape(rectangle);
            shapeManager.AddShape(triangle);

            //// Display all shapes
            shapeManager.DisplayShapes();
            Console.ReadLine();
        }
    }
}
