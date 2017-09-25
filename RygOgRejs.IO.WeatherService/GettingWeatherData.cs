﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.IO.WeatherService
{
    class GettingWeatherData
    {
        //thanks to dude from StackOverFlow for this
        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Sys
        {
            public int Type { get; set; }
            public int Id { get; set; }
            public double Message { get; set; }
            public string Country { get; set; }
            public int Sunrise { get; set; }
            public int Sunset { get; set; }
        }

        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double Humidity { get; set; }
            public double Pressure { get; set; }
            public double Temp_min { get; set; }
            public double Temp_max { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public double Gust { get; set; }
            public int Deg { get; set; }
        }



        public class Clouds
        {
            public int All { get; set; }
        }

        public class Root
        {
            public Coord Coord { get; set; }
            public Sys Sys { get; set; }
            public List<Weather> Weather { get; set; }
            public string Base { get; set; }
            public Main Main { get; set; }
            public Wind Wind { get; set; }
            public Dictionary<string, double> Rain { get; set; }
            public Clouds Clouds { get; set; }
            public int Dt { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Cod { get; set; }
        }
    }
}
