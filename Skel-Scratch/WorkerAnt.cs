//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System.Collections.Generic;

namespace AntSimCS
{
   
        class WorkerAnt : Ant
        {
            public WorkerAnt(int StartRow, int StartColumn, int NestInRow, int NestInColumn)
                : base(StartRow, StartColumn, NestInRow, NestInColumn)
            {
                TypeOfAnt = "worker";
                FoodCapacity = 30;
            }

            public override string GetDetails()
            {
                return $"{base.GetDetails()}, carrying {AmountOfFoodCarried} food, home nest is at {NestRow} {NestColumn}";
            }

            public override void ChooseCellToMoveTo(List<int> ListOfNeighbours, int IndexOfNeighbourWithStrongestPheromone)
            {
                if (AmountOfFoodCarried > 0)
                {
                    if (Row > NestRow)
                    {
                        Row--;
                    }
                    else if (Row < NestRow)
                    {
                        Row++;
                    }
                    if (Column > NestColumn)
                    {
                        Column--;
                    }
                    else if (Column < NestColumn)
                    {
                        Column++;
                    }
                }
                else if (IndexOfNeighbourWithStrongestPheromone == -1)
                {
                    int IndexToUse = ChooseRandomNeighbour(ListOfNeighbours);
                    ChangeCell(IndexToUse, ref Row, ref Column);
                }
                else
                {
                    int IndexToUse = ListOfNeighbours.IndexOf(IndexOfNeighbourWithStrongestPheromone);
                    ChangeCell(IndexToUse, ref Row, ref Column);
                }
            }
        }
    }
