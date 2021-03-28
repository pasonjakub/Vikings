using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    abstract class Owner : Viking
    {
        public double LandArea { get; set; }
        virtual public void Command(Thrall thrall)
        {
            thrall.Work();
        }
    }
}
