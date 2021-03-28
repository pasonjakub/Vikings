using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Thrall : Viking
    {
        abstract public void StoreMaterials(Storage storage);
        abstract public void Work();
        protected Thrall()
        {
            MaxHP = 120;
            HP = MaxHP;
        }
    }
    class Woodcutter : Thrall
    {
        private int wood;
        public override void StoreMaterials(Storage storage)
        {
            storage.Wood += wood;
            wood = 0;
        }

        public override void Work()
        {
            wood += 100;
        }
    }
    class Carpenter : Thrall
    {
        private int woodenPlanks;
        private int wood;
        public Carpenter() : base()
        {
            Defense = 8;
            AttackDMG = 3;
            Type = "Carpenter";
        }
        public override void StoreMaterials(Storage storage)
        {
            storage.WoodenPlanks += woodenPlanks;
            woodenPlanks = 0;
        }

        public override void Work()
        {
            if(wood > 80)
            {
                woodenPlanks += 120;
                wood -= 80;
            }
        }
        public void GetMaterials(Storage storage, int Wood)
        {
            if (storage.Wood >= Wood)
            {
                this.wood += storage.Wood;
                storage.Wood -= Wood;
            }
        }
    }
    class Fisherman : Thrall
    {
        private int fish;
        public Fisherman() : base()
        {
            Defense = 6;
            AttackDMG = 3;
            Type = "Fisherman";
        }
        public override void StoreMaterials(Storage storage)
        {
            storage.Fish += fish;
            fish = 0;
        }
        public override void Work()
        {
            fish += 30;
        }
    }
    class Ropemaker : Thrall
    {
        private double ropes;
        private int hemp;
        public Ropemaker() : base()
        {
            Defense = 9;
            AttackDMG = 4;
            Type = "Ropemaker";
        }
        public override void StoreMaterials(Storage storage)
        {
            storage.Ropes += ropes;
            ropes = 0;
        }

        public override void Work()
        {
            if (this.hemp >= 60)
            {
                ropes += 240;
                hemp -= 60;
            }
        }
        public void GetMaterials(Storage storage, int hemp)
        {
            this.hemp += storage.GetCrop("Hemp", hemp);
        }
    }
    class Farmer : Thrall
    {
        private Dictionary<string, int> crops = new Dictionary<string, int> { };
        private Island island;
        public Farmer(Island island) : base()
        {
            Defense = 7;
            AttackDMG = 5;
            Type = "Farmer";
            this.island = island;
        }
        public override void StoreMaterials(Storage storage)
        {
            foreach (KeyValuePair<string, int> kvp in crops)
            {
                storage.AddCrop(kvp.Key, kvp.Value);
                crops[kvp.Key] = 0;
            }
        }
        public override void Work()
        {

            foreach (string cropType in island.Crops)
            {
                if (!crops.ContainsKey(cropType))
                    crops.Add(cropType, 80);
                else
                    crops[cropType] += 80;
            }
        }
    }
}
