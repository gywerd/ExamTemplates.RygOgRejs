using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;
using RygOgRejs.IO.DataAccess.App;
using RygOgRejs.Bizz.App;
namespace RygOgRejs.IO.WeatherService
{
    public class WeatherAPI
    {
        AppBizz CRB;
        #region Fields
        private const string APP_ID = "4e3fd7f40537fe7b10f305007684b7a3"; //Emil Api
        private const int MAX_FORECAST_DAYS = 5;
        private HttpClient client;
        private Label weather;
        private DestinationsEnquiries priceEnquiries = new DestinationsEnquiries();
        #endregion

        #region Constructors
        public WeatherAPI(Label weatherName, AppBizz mainBizz)
        {
            CRB = mainBizz;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            weather = weatherName;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public async void GetCityNameAsync()
        {
            //I would like to optimize this if you have any idea plz tell :P
            List<string> tempLoc = new List<string>();
            List<string> locations = new List<string>();
            tempLoc = CRB.DestinationList;
            string RemoveDest = "";
            foreach(string Destination in tempLoc)
            {
                RemoveDest = Destination.Remove(0, 7);
                if (!Destination.Contains("Spain"))
                    RemoveDest = RemoveDest.Remove(RemoveDest.Length - 9);
                else
                    RemoveDest = RemoveDest.Remove(RemoveDest.Length - 7);
                if (RemoveDest.Contains(" "))
                    RemoveDest = RemoveDest.Replace(" ", string.Empty);
                locations.Add(RemoveDest);
            }
            while (true)
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
        #endregion
    }
}
