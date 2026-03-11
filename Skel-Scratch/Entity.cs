//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System.Collections.Generic;

namespace AntSimCS
{

    class Entity
    {
        protected int Row, Column, ID;

        public Entity(int StartRow, int StartColumn)
        {
            Row = StartRow;
            Column = StartColumn;
        }

        public bool InSameLocation(Entity E)
        {
            return E.GetRow() == Row && E.GetColumn() == Column;
        }

        public int GetRow()
        {
            return Row;
        }

        public int GetColumn()
        {
            return Column;
        }

        public int GetID()
        {
            return ID;
        }

        public virtual void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
        }

        public virtual string GetDetails()
        {
            return "";
        }
    }
}
