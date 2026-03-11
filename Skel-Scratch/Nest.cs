//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System;
using System.Collections.Generic;

namespace AntSimCS
{

    class Nest : Entity
    {
        public static Random RGen = new Random();
        protected int FoodLevel, NumberOfQueens;
        protected static int NextNestID = 1;

        public Nest(int StartRow, int StartColumn, int StartFood) : base(StartRow, StartColumn)
        {
            FoodLevel = StartFood;
            NumberOfQueens = 1;
            ID = NextNestID;
            NextNestID++;
        }

        public void ChangeFood(int Change)
        {
            FoodLevel += Change;
            if (FoodLevel < 0)
            {
                FoodLevel = 0;
            }
        }

        public int GetFoodLevel()
        {
            return FoodLevel;
        }

        public override void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
            if (Ants == null)
            {
                return;
            }
            int AntsToCull = 0;
            int Count = 0;
            int AntsInNestCount = 0;
            foreach (Ant A in Ants)
            {
                if (A.GetNestRow() == Row && A.GetNestColumn() == Column)
                {
                    if (A.GetTypeOfAnt() == "queen")
                    {
                        Count += 10;
                    }
                    else
                    {
                        Count += 2;
                        AntsInNestCount++;
                    }
                }
            }
            ChangeFood(-Count);
            if (FoodLevel == 0 && AntsInNestCount > 0)
            {
                AntsToCull++;
            }
            if (FoodLevel < AntsInNestCount)
            {
                AntsToCull++;
            }
            if (FoodLevel < AntsInNestCount * 5)
            {
                AntsToCull++;
                if (AntsToCull > AntsInNestCount)
                {
                    AntsToCull = AntsInNestCount;
                }
                for (int A = 1; A <= AntsToCull; A++)
                {
                    int RPos;
                    do
                    {
                        RPos = RGen.Next(0, Ants.Count);
                    } while (!(Ants[RPos].GetNestRow() == Row && Ants[RPos].GetNestColumn() == Column));
                    if (Ants[RPos].GetTypeOfAnt() == "queen")
                    {
                        NumberOfQueens--;
                    }
                    Ants.RemoveAt(RPos);
                }
            }
            else
            {
                for (int A = 1; A <= NumberOfQueens; A++)
                {
                    int RNo1 = RGen.Next(0, 100);
                    if (RNo1 < 50)
                    {
                        int RNo2 = RGen.Next(0, 100);
                        if (RNo2 < 2)
                        {
                            Ants.Add(new QueenAnt(Row, Column, Row, Column));
                            NumberOfQueens++;
                        }
                        else
                        {
                            Ants.Add(new WorkerAnt(Row, Column, Row, Column));
                        }
                    }
                }
            }
        }
    }
}
