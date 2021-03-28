using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Karl : Owner
    {
        protected Karl()
        {
            MaxHP = 150;
            HP = MaxHP;
        }
    }
    class Shieldbearer : Karl
    {
        public Shieldbearer() : base()
        {
            Type = "Shieldbearer";
            Defense = 15;
            AttackDMG = 12;
        }
    }
    class Bowman : Karl
    {
        public int Arrows { get; set; }
        public Bowman() : base()
        {
            Type = "Shieldbearer";
            Defense = 12;
            AttackDMG = 10;
            Arrows = 100;
        }
        override public string Fight(IBattleProperties battleProperties)
        {
            if (battleProperties.HP > 0 && Arrows > 0)
            {
                double damageDealt = AttackDMG * (battleProperties.Defense / 100);
                battleProperties.HP -= damageDealt;
                Arrows--;
                return $"Damage dealt {damageDealt}, left {battleProperties.HP} HP";
            }
            else
                return $"{battleProperties.Type} has no health and is dead";
        }
    }
    class BoatBuilder : Karl
    {
        public BoatBuilder() : base()
        {
            Type = "BoatBuilder";
            Defense = 15;
            AttackDMG = 15;
        }
        public void VisitStorage(Shipyard currentShipyard, Storage storage, int WoodenPlanks, double Ropes)
        {
            if (storage.WoodenPlanks >= WoodenPlanks && storage.Ropes >= Ropes)
            {
                currentShipyard.WoodenPlanks += WoodenPlanks;
                storage.WoodenPlanks -= WoodenPlanks;
                currentShipyard.Ropes += Ropes;
                storage.Ropes -= Ropes;
            }
        }
        public string BuildLongship(Shipyard currentShipyard, Harbour harbour)
        {
            int WoodenPlanks = 200;
            double Ropes = 120;
            if (currentShipyard.WoodenPlanks >= WoodenPlanks && currentShipyard.Ropes >= Ropes)
            {
                harbour.Boats.Add(new Longship());
                currentShipyard.WoodenPlanks -= WoodenPlanks;
                currentShipyard.Ropes -= Ropes;
                return "Successfully built longship";
            }
            else
                return "Not enough materials!";
        }
    }
}
