using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;

namespace RygOgRejs.IO.WeatherService
{
    public class WeatherAPI
    {
        private const string APP_ID = "4e3fd7f40537fe7b10f305007684b7a3"; //Emil Api
        private const int MAX_FORECAST_DAYS = 5;
        private HttpClient client;
        private Label weather;
        public WeatherAPI(Label weatherName)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            weather = weatherName;
        }

        public async void GetCityNameAsync() //had int day here, but i removed it
        {
            //for now gonna fetch this from the database when its made ;P
            List<string> locations = new List<string>()
            {
                 "Billlund",
                 "Copehangen",
                 "PalmaDeMallorca"
            };
            while(true)
            {
                try
                {
                    foreach(string location in locations)
                    {
                        string query = $"weather?q={location}&mode=json&appid={APP_ID}";
                        HttpResponseMessage test = await client.GetAsync(query);

                        string s = await test.Content.ReadAsStringAsync();

                        GettingWeatherData.Root weatherRoot = JsonConvert.DeserializeObject<GettingWeatherData.Root>(s);
                        double temp = weatherRoot.Main.Temp - 273;
                        weather.Content = $"{location} Temperatur er lige nu {temp} °C";
                        await Task.Delay(11000);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
    }
}
