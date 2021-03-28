using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Crop
    {
        public double GrowthTime { get; set; }
        public string Type { get; set; }
    }
    class Hemp : Crop
    {
        public Hemp()
        {
            GrowthTime = 3;
            Type = "Hemp";
        }
    }
    class Potato : Crop
    {
        public Potato()
        {
            GrowthTime = 5;
            Type = "Potato";
        }
    }
}
