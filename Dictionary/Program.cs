using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionarys
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> aDictionary = new Dictionary<string, int>();

            aDictionary.Add("Spitfire", 8);
            aDictionary.Add("Hurricane", 8);
            aDictionary.Add("Typhoon", 12);
            aDictionary.Add("Mustang", 6);
            aDictionary.Add("B-17", 22);


            Console.WriteLine("Enter the plane");
            string plane = Console.ReadLine();
            if (aDictionary.ContainsKey(plane))
            {
                Console.WriteLine($"The {plane} has {aDictionary[plane]} ");
            }
            else
            {

                Console.WriteLine($"{plane} does not exist");
            }
            Console.ReadLine();
        }
    }
}
