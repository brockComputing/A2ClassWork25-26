//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System;

namespace AntSimCS
{

    class Cell : Entity
    {
        protected int AmountOfFood;

        public Cell(int StartRow, int StartColumn) : base(StartRow, StartColumn)
        {
            AmountOfFood = 0;
        }

        public int GetAmountOfFood()
        {
            return AmountOfFood;
        }

        public override string GetDetails()
        {
            return $"{base.GetDetails()}{AmountOfFood} food present{Environment.NewLine}{Environment.NewLine}";
        }

        public void UpdateFoodInCell(int Change)
        {
            AmountOfFood += Change;
        }
    }
}
