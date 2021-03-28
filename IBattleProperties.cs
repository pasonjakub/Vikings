using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    interface IBattleProperties
    {
        double MaxHP { get; set; }
        double HP { get; set; }
        double Defense { get; set; }
        double AttackDMG { get; set; }
        string Type { get; set; }
    }
}
