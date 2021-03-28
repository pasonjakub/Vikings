using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    class Earl : Owner
    {
        public Earl()
        {
            Type = "Earl";
            MaxHP = 250;
            HP = MaxHP;
            Defense = 25;
            AttackDMG = 16;
        }
        public void Command(Karl karl, IBattleProperties battleProperties)
        {
            karl.Fight(battleProperties);
        }
        public void GiveLand(Karl Karl, double LandArea)
        {
            if(this.LandArea >= LandArea)
            {
                Karl.LandArea += LandArea;
                this.LandArea -= LandArea;
            }
        }
    }
}
