//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

namespace AntSimCS
{
   
        class QueenAnt : Ant
        {
            public QueenAnt(int StartRow, int StartColumn, int NestInRow, int NestInColumn)
                : base(StartRow, StartColumn, NestInRow, NestInColumn)
            {
                TypeOfAnt = "queen";
            }
        }
    }