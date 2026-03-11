//Skeleton Program code for the AQA A Level Paper 1 Summer 2026 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
//Version 2

using System.Collections.Generic;

namespace AntSimCS
{

    class Pheromone : Entity
    {
        protected int Strength, PheromoneDecay, BelongsTo;

        public Pheromone(int Row, int Column, int BelongsToAnt, int InitialStrength, int Decay)
            : base(Row, Column)
        {
            BelongsTo = BelongsToAnt;
            Strength = InitialStrength;
            PheromoneDecay = Decay;
        }

        public override void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
            Strength -= PheromoneDecay;
            if (Strength < 0)
            {
                Strength = 0;
            }
        }

        public void UpdateStrength(int Change)
        {
            Strength += Change;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetBelongsTo()
        {
            return BelongsTo;
        }
    }
}
