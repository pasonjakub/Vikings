using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Viking : IBattleProperties
    {
        public double MaxHP { get; set; }
        public double HP { get; set; }
        public double Defense { get; set; }
        public double AttackDMG { get; set; }
        public string Type { get; set; } 
        virtual public double Fight(IBattleProperties battleProperties)
        {
            if (battleProperties.HP > 0)
            {
                double damageDealt = AttackDMG * (battleProperties.Defense / 100);
                battleProperties.HP -= damageDealt;
                return damageDealt;
            }
            else
                return -1;
        }
    }
}
