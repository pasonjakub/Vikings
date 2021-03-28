using System;
using System.Collections.Generic;
using System.Text;

namespace VikingsImproved
{
    class Ocean
    {
        public List<Boat> boats = new List<Boat> { };
        public List<Island> islands = new List<Island> { };
        public List<Weather> weathers = new List<Weather> { };
        public Ocean(List<Boat> boats, List<Island> islands, List<Weather> weathers)
        {
            this.boats = boats;
            this.islands = islands;
            if (weathers.Count == 0)
                this.weathers.Add(new Weather());
            else
                this.weathers = weathers;
        }
    }
    class Island
    {
        public double LandArea { get; set; }
        public List<string> Crops = new List<string> { };
        public bool IsFreshWater { get; set; }
        public bool IsInhabited { get; set; }
        public Island(List<string> Crops, double LandArea, bool IsFreshWater, bool IsInhabited)
        {
            foreach (string crop in Crops)
                if(!Crops.Contains(crop))
                    this.Crops.Add(crop);
            this.LandArea = LandArea;
            this.IsFreshWater = IsFreshWater;
            this.IsInhabited = IsInhabited;
        }
    }
    class Weather
    {
        private double temperature;
        private double humidity;
        private double wind;
        private bool isRain;
        private bool isStorm;
        public Weather()
        {
            temperature = 21;
            humidity = 30;
            wind = 15;
            isRain = false;
            isStorm = false;
        }
        public Weather(double temperature, double humidity, double wind, bool isRain, bool isStorm)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.wind = wind;
            this.isRain = isRain;
            this.isStorm = isStorm;
        }
        public string CurrentWeather()
        {
            return $"Temperature:\t{temperature}\nHumidity:\t{humidity}%\nWind:\t\t{wind}km/h\nIs raining:\t{isRain}\nIs storm:\t{isStorm}";
        }
    }

}
