//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System;
using System.Collections.Generic;

namespace AntSimCS
{

    class Simulation
    {
        public static Random RGen = new Random();
        protected List<Cell> Grid = new List<Cell>();
        protected List<Ant> Ants = new List<Ant>();
        protected List<Pheromone> Pheromones = new List<Pheromone>();
        protected List<Nest> Nests = new List<Nest>();
        protected int NumberOfRows, NumberOfColumns, StartingFoodInNest, StartingNumberOfFoodCells, StartingNumberOfNests;
        protected int StartingAntsInNest, NewPheromoneStrength, PheromoneDecay;

        public Simulation(List<int> SimulationParameters)
        {
            StartingNumberOfNests = SimulationParameters[0];
            NumberOfRows = SimulationParameters[1];
            NumberOfColumns = SimulationParameters[2];
            StartingFoodInNest = SimulationParameters[3];
            StartingNumberOfFoodCells = SimulationParameters[4];
            StartingAntsInNest = SimulationParameters[5];
            NewPheromoneStrength = SimulationParameters[6];
            PheromoneDecay = SimulationParameters[7];
            int Row, Column;
            for (Row = 1; Row <= NumberOfRows; Row++)
            {
                for (Column = 1; Column <= NumberOfColumns; Column++)
                {
                    Grid.Add(new Cell(Row, Column));
                }
            }
            SetUpANestAt(2, 4);
            for (int Count = 2; Count <= StartingNumberOfNests; Count++)
            {
                bool Allowed;
                do
                {
                    Allowed = true;
                    Row = RGen.Next(1, NumberOfRows + 1);
                    Column = RGen.Next(1, NumberOfColumns + 1);
                    foreach (Nest N in Nests)
                    {
                        if (N.GetRow() == Row && N.GetColumn() == Column)
                        {
                            Allowed = false;
                        }
                    }
                } while (!Allowed);
                SetUpANestAt(Row, Column);
            }
            for (int Count = 1; Count <= StartingNumberOfFoodCells; Count++)
            {
                bool Allowed;
                do
                {
                    Allowed = true;
                    Row = RGen.Next(1, NumberOfRows + 1);
                    Column = RGen.Next(1, NumberOfColumns + 1);
                    foreach (Nest N in Nests)
                    {
                        if (N.GetRow() == Row && N.GetColumn() == Column)
                        {
                            Allowed = false;
                        }
                    }
                } while (!Allowed);
                AddFoodToCell(Row, Column, 500);
            }
        }

        public void SetUpANestAt(int Row, int Column)
        {
            Nests.Add(new Nest(Row, Column, StartingFoodInNest));
            Ants.Add(new QueenAnt(Row, Column, Row, Column));
            for (int Worker = 2; Worker <= StartingAntsInNest; Worker++)
            {
                Ants.Add(new WorkerAnt(Row, Column, Row, Column));
            }
        }

        public void AddFoodToCell(int Row, int Column, int Quantity)
        {
            Grid[GetIndex(Row, Column)].UpdateFoodInCell(Quantity);
        }

        private int GetIndex(int Row, int Column)
        {
            return (Row - 1) * NumberOfColumns + Column - 1;
        }

        private List<int> GetIndicesOfNeighbours(int Row, int Column)
        {
            List<int> ListOfNeighbours = new List<int>();
            foreach (int RowDirection in new int[] { -1, 0, 1 })
            {
                foreach (int ColumnDirection in new int[] { -1, 0, 1 })
                {
                    int NeighbourRow = Row + RowDirection, NeighbourColumn = Column + ColumnDirection;
                    if ((RowDirection != 0 || ColumnDirection != 0) && NeighbourRow >= 1 && NeighbourRow <= NumberOfRows &&
                        NeighbourColumn >= 1 && NeighbourColumn <= NumberOfColumns)
                    {
                        ListOfNeighbours.Add(GetIndex(NeighbourRow, NeighbourColumn));
                    }
                    else
                    {
                        ListOfNeighbours.Add(-1);
                    }
                }
            }
            return ListOfNeighbours;
        }

        private int GetIndexOfNeighbourWithStrongestPheromone(int Row, int Column)
        {
            int StrongestPheromone = 0, IndexOfStrongestPheromone = -1;
            foreach (int Index in GetIndicesOfNeighbours(Row, Column))
            {
                if (Index != -1 && GetStrongestPheromoneInCell(Grid[Index]) > StrongestPheromone)
                {
                    IndexOfStrongestPheromone = Index;
                    StrongestPheromone = GetStrongestPheromoneInCell(Grid[Index]);
                }
            }
            return IndexOfStrongestPheromone;
        }

        public Nest GetNestInCell(Cell C)
        {
            foreach (Nest N in Nests)
            {
                if (N.InSameLocation(C))
                {
                    return N;
                }
            }
            return null;
        }

        public void UpdateAntsPheromoneInCell(Ant A)
        {
            foreach (Pheromone P in Pheromones)
            {
                if (P.InSameLocation(A) && P.GetBelongsTo() == A.GetID())
                {
                    P.UpdateStrength(NewPheromoneStrength);
                    return;
                }
            }
            Pheromones.Add(new Pheromone(A.GetRow(), A.GetColumn(), A.GetID(), NewPheromoneStrength, PheromoneDecay));
        }

        public int GetNumberOfAntsInCell(Cell C)
        {
            int Count = 0;
            foreach (Ant A in Ants)
            {
                if (A.InSameLocation(C))
                {
                    Count++;
                }
            }
            return Count;
        }

        public int GetNumberOfPheromonesInCell(Cell C)
        {
            int Count = 0;
            foreach (Pheromone P in Pheromones)
            {
                if (P.InSameLocation(C))
                {
                    Count++;
                }
            }
            return Count;
        }

        public int GetStrongestPheromoneInCell(Cell C)
        {
            int Strongest = 0;
            foreach (Pheromone P in Pheromones)
            {
                if (P.InSameLocation(C))
                {
                    if (P.GetStrength() > Strongest)
                    {
                        Strongest = P.GetStrength();
                    }
                }
            }
            return Strongest;
        }

        public string GetDetails()
        {
            string Details = "";
            for (int Row = 1; Row <= NumberOfRows; Row++)
            {
                for (int Column = 1; Column <= NumberOfColumns; Column++)
                {
                    Details += $"{Row}, {Column}: ";
                    Cell TempCell = Grid[GetIndex(Row, Column)];
                    if (GetNestInCell(TempCell) != null)
                    {
                        Details += "| Nest |  ";
                    }
                    int NumberOfAnts = GetNumberOfAntsInCell(TempCell);
                    if (NumberOfAnts > 0)
                    {
                        Details += $"| Ants: {NumberOfAnts} |  ";
                    }
                    int NumberOfPheromones = GetNumberOfPheromonesInCell(TempCell);
                    if (NumberOfPheromones > 0)
                    {
                        Details += $"| Pheromones: {NumberOfPheromones} |  ";
                    }
                    int AmountOfFood = TempCell.GetAmountOfFood();
                    if (AmountOfFood > 0)
                    {
                        Details += $"| {AmountOfFood} food |  ";
                    }
                    Details += Environment.NewLine;
                }
            }
            return Details;
        }

        public string GetAreaDetails(int StartRow, int StartColumn, int EndRow, int EndColumn)
        {
            string Details = "";
            for (int Row = StartRow; Row <= EndRow; Row++)
            {
                for (int Column = StartColumn; Column <= EndColumn; Column++)
                {
                    Details += $"{Row}, {Column}: ";
                    Cell TempCell = Grid[GetIndex(Row, Column)];
                    if (GetNestInCell(TempCell) != null)
                    {
                        Details += "| Nest |  ";
                    }
                    int NumberOfAnts = GetNumberOfAntsInCell(TempCell);
                    if (NumberOfAnts > 0)
                    {
                        Details += $"| Ants: {NumberOfAnts} |  ";
                    }
                    int NumberOfPheromones = GetNumberOfPheromonesInCell(TempCell);
                    if (NumberOfPheromones > 0)
                    {
                        Details += $"| Pheromones: {NumberOfPheromones} |  ";
                    }
                    int AmountOfFood = TempCell.GetAmountOfFood();
                    if (AmountOfFood > 0)
                    {
                        Details += $"| {AmountOfFood} food |  ";
                    }
                    Details += Environment.NewLine;
                }
            }
            return Details;
        }

        public void AddFoodToNest(int Food, int Row, int Column)
        {
            foreach (Nest N in Nests)
            {
                if (N.GetRow() == Row && N.GetColumn() == Column)
                {
                    N.ChangeFood(Food);
                    break;
                }
            }
        }

        public string GetCellDetails(int Row, int Column)
        {
            Cell CurrentCell = Grid[GetIndex(Row, Column)];
            string Details = CurrentCell.GetDetails();
            Nest N = GetNestInCell(CurrentCell);
            if (N != null)
            {
                Details += $"Nest present ({N.GetFoodLevel()} food){Environment.NewLine}{Environment.NewLine}";
            }
            if (GetNumberOfAntsInCell(CurrentCell) > 0)
            {
                Details += $"ANTS{Environment.NewLine}";
                foreach (Ant A in Ants)
                {
                    if (A.InSameLocation(CurrentCell))
                    {
                        Details += $"{A.GetDetails()}{Environment.NewLine}";
                    }
                }
                Details += Environment.NewLine + Environment.NewLine;
            }
            if (GetNumberOfPheromonesInCell(CurrentCell) > 0)
            {
                Details += $"PHEROMONES{Environment.NewLine}";
                foreach (Pheromone P in Pheromones)
                {
                    if (P.InSameLocation(CurrentCell))
                    {
                        Details += $"Ant {P.GetBelongsTo()} with strength of {P.GetStrength()}{Environment.NewLine}{Environment.NewLine}";
                    }
                }
                Details += Environment.NewLine + Environment.NewLine;
            }
            return Details;
        }

        public void AdvanceStage(int NumberOfStages)
        {
            for (int Count = 1; Count <= NumberOfStages; Count++)
            {
                List<Pheromone> PheromonesToDelete = new List<Pheromone>();
                foreach (Pheromone P in Pheromones)
                {
                    P.AdvanceStage(Nests, Ants, Pheromones);
                    if (P.GetStrength() == 0)
                    {
                        PheromonesToDelete.Add(P);
                    }
                }
                foreach (Pheromone P in PheromonesToDelete)
                {
                    Pheromones.Remove(P);
                }
                foreach (Ant A in Ants)
                {
                    A.AdvanceStage(Nests, Ants, Pheromones);
                    Cell CurrentCell = Grid[GetIndex(A.GetRow(), A.GetColumn())];
                    if (A.GetFoodCarried() > 0 && A.IsAtOwnNest())
                    {
                        AddFoodToNest(A.GetFoodCarried(), A.GetRow(), A.GetColumn());
                        A.UpdateFoodCarried(-A.GetFoodCarried());
                    }
                    else if (CurrentCell.GetAmountOfFood() > 0 && A.GetFoodCarried() == 0 && A.GetFoodCapacity() > 0)
                    {
                        int FoodObtained;
                        do
                        {
                            FoodObtained = RGen.Next(1, A.GetFoodCapacity() + 1);
                        } while (FoodObtained > CurrentCell.GetAmountOfFood() || (A.GetFoodCarried() + FoodObtained) > A.GetFoodCapacity());
                        CurrentCell.UpdateFoodInCell(-FoodObtained);
                        A.UpdateFoodCarried(FoodObtained);
                    }
                    else
                    {
                        if (A.GetFoodCarried() > 0)
                        {
                            UpdateAntsPheromoneInCell(A);
                        }
                        A.ChooseCellToMoveTo(GetIndicesOfNeighbours(A.GetRow(), A.GetColumn()),
                                             GetIndexOfNeighbourWithStrongestPheromone(A.GetRow(), A.GetColumn()));
                    }
                }
                foreach (Nest N in Nests)
                {
                    N.AdvanceStage(Nests, Ants, Pheromones);
                }
            }
        }
    }
}
