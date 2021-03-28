using System;

namespace VikingsImproved
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage s = new Storage();
            Console.WriteLine(s.GetStatus());
            s.AddCrop(new Hemp().Type, 10);
            s.AddCrop(new Hemp().Type, 10);
            s.AddCrop(new Hemp().Type, 10);
            s.AddCrop(new Potato().Type, 40);
            s.Ropes = 480;
            s.WoodenPlanks = 240;
            Console.WriteLine(s.GetStatus());
            Weather w = new Weather(15.1,51.9,50,true,true);
            Console.WriteLine(w.CurrentWeather());
            BoatBuilder b = new BoatBuilder();
            Shipyard shipyard = new Shipyard();
            b.VisitStorage(shipyard, s, 200, 200);
            Console.WriteLine(b.BuildLongship(shipyard, new Harbour()));
            Console.WriteLine(s.GetStatus());
            Fisherman f = new Fisherman();
            f.Work();
            f.StoreMaterials(s);
            Console.WriteLine(s.GetStatus());
            Console.WriteLine(s.GetCrop("Hemp", 10));
            Console.WriteLine(s.GetStatus());
        }
    }
}
