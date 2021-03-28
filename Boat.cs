using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Boat : IBattleProperties
    {
        public double MaxHP { get; set; }
        public double HP { get; set; }
        public double Defense { get; set; }
        public double AttackDMG { get; set; }
        public string Type { get; set; }
        public int PassengerCap { get; set; }
        public int LoadCap { get; set; }
        public double Speed { get; set; }
        public List<Viking> Crew { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public double Move(char direction, int distance)
        {
            if (Crew.Count > PassengerCap/10)
            {
                if (direction == 'n')
                    YPos += distance;
                else if (direction == 's')
                    YPos -= distance;
                else if (direction == 'e')
                    XPos += distance;
                else if (direction == 'w')
                    XPos -= distance;
                return distance / Speed;
            }
            return 0;
        }
    }
    class Longship : Boat
    {
        public Longship()
        {
            MaxHP = 2500;
            HP = MaxHP;
            Defense = 40;
            AttackDMG = 0;
            Type = "Longship";
            PassengerCap = 32;
            Speed = 50;
            XPos = 0;
            YPos = 0;
        }
    }
}
