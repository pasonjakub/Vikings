using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Building : IBattleProperties
    {
        public double MaxHP { get; set; }
        public double HP { get; set; }
        public double Defense { get; set; }
        public double AttackDMG { get; set; }
        public string Type { get; set; }
    }
    class Storage : Building
    {
        public int Wood { get; set; }
        public int WoodenPlanks { get; set; }
        public int Fish { get; set; }
        public double Ropes{ get; set; }
        private Dictionary<string, int> crops = new Dictionary<string, int> { };
        public Storage()
        {
            MaxHP = 3000;
            HP = MaxHP;
            Defense = 60;
            AttackDMG = 0;
            Type = "Storage";
        }
        public void AddCrop(string key, int value)
        {
            if (crops.ContainsKey(key))
                crops[key] += value;
            else
                crops.Add(key, value);
        }
        public int GetCrop(string CropType, int value)
        {
            if (crops[CropType] >= value)
            {
                crops[CropType] -= value;
                return value;
            }
            else
                return 0;

        }
        public string GetStatus()
        {
            string Crops = "";

            foreach (KeyValuePair<string, int> kvp in crops)
                Crops += $"{kvp.Key}:\t\t{kvp.Value}\n";

            return $"Wood:\t\t{Wood}\nWooden planks:\t{WoodenPlanks}\nFish:\t\t{Fish}\nRopes:\t\t{Ropes}\n{Crops}";
        }
    }
    class Shipyard : Building
    {
        public int WoodenPlanks { get; set; }
        public double Ropes { get; set; }

        public Shipyard()
        {
            MaxHP = 4500;
            HP = MaxHP;
            Defense = 60;
            AttackDMG = 0;
            Type = "Shipyard";
        }
    }
    class Harbour : Building
    {
        public List<Boat> Boats = new List<Boat> { };
        public Harbour()
        {
            MaxHP = 6000;
            HP = MaxHP;
            Defense = 60;
            AttackDMG = 0;
            Type = "Harbour";
        }
        public void ToTheSea(Boat boat, Ocean ocean)
        {
            ocean.boats.Add(boat);
        }
        public void RepairFleet()
        {
            foreach (Boat boat in Boats)
                boat.HP = MaxHP;
        }
    }
}
