using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class testClass
    {
        // vec is now a property with a public getter and a private setter
        public Vector2 Vec { get; private set; } = new Vector2();
        public Vector2 simpleVec = new Vector2();
        void testMethod()
        {
            // update the property
            Vec = Vector2.Add(Vec, new Vector2(1, 1));
        }
        void anotherMethod()
        {
            // update the property
            Vec.X = 1; // This line will cause a compile-time error
            simpleVec.X = 1; // This line is fine
            var temp = Vec;
            temp.X = 1;
            Vec = temp;
            Vec = Vector2.Multiply(Vec, 2);
        }
    }
    internal class test
    {
        static void Main(string[] args)
        {
        }
    }
}