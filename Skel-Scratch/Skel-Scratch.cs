//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System;
using System.Collections.Generic;

namespace AntSimCS
{
    class Program
    {
        public static Random RGen = new Random();

        static void Main()
        {
            List<int> SimulationParameters = new List<int>();
            Console.Write("Enter simulation number: ");
            string SimNo = Console.ReadLine();
            switch (SimNo)
            {
                case "1":
                    SimulationParameters = new List<int> { 1, 5, 5, 500, 3, 5, 1000, 50 };
                    break;
                case "2":
                    SimulationParameters = new List<int> { 1, 5, 5, 500, 3, 5, 1000, 100 };
                    break;
                case "3":
                    SimulationParameters = new List<int> { 1, 10, 10, 500, 3, 9, 1000, 25 };
                    break;
                case "4":
                    SimulationParameters = new List<int> { 2, 10, 10, 500, 3, 6, 1000, 25 };
                    break;
            }
            Simulation ThisSimulation = new Simulation(SimulationParameters);
            string Choice;
            do
            {
                DisplayMenu();
                Choice = GetChoice();
                switch (Choice)
                {
                    case "1":
                        Console.WriteLine(ThisSimulation.GetDetails());
                        break;
                    case "2":
                        int StartRow = 0, StartColumn = 0, EndRow = 0, EndColumn = 0;
                        GetCellReference(ref StartRow, ref StartColumn);
                        GetCellReference(ref EndRow, ref EndColumn);
                        Console.WriteLine(ThisSimulation.GetAreaDetails(StartRow, StartColumn, EndRow, EndColumn));
                        break;
                    case "3":
                        int Row = 0, Column = 0;
                        GetCellReference(ref Row, ref Column);
                        Console.WriteLine(ThisSimulation.GetCellDetails(Row, Column));
                        break;
                    case "4":
                        ThisSimulation.AdvanceStage(1);
                        Console.WriteLine($"Simulation moved on one stage{Environment.NewLine}");
                        break;
                    case "5":
                        Console.Write("Enter number of stages to advance by: ");
                        int NumberOfStages = Convert.ToInt32(Console.ReadLine());
                        ThisSimulation.AdvanceStage(NumberOfStages);
                        Console.WriteLine($"Simulation moved on {NumberOfStages} stages{Environment.NewLine}");
                        break;
                }
            } while (Choice != "9");
            Console.ReadLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Display overall details");
            Console.WriteLine("2. Display area details");
            Console.WriteLine("3. Inspect cell");
            Console.WriteLine("4. Advance one stage");
            Console.WriteLine("5. Advance X stages");
            Console.WriteLine("9. Quit");
            Console.WriteLine();
            Console.Write("> ");
        }

        static string GetChoice()
        {
            string Choice = Console.ReadLine();
            return Choice;
        }

        static void GetCellReference(ref int Row, ref int Column)
        {
            Console.WriteLine();
            Console.Write("Enter row number: ");
            Row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column number: ");
            Column = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
    }
}