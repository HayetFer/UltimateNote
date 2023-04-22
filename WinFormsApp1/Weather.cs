using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeatherMapDemo
{
    public class Weather
    {
        private const string API_KEY = "";
        private const string API_URL = "https://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid={2}";

        public async Task<string> GetWeatherMainAsync(string cityName, string countryCode)
        {
            HttpClient client = new HttpClient();
            string url = string.Format(API_URL, cityName, countryCode, API_KEY);
            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseBody);
            return weatherResponse.WeatherData.Main;
        }
    }

    public class WeatherResponse
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
        public WindData Wind { get; set; }
        public WeatherData[] Weather { get; set; }
        public WeatherData WeatherData => Weather != null && Weather.Length > 0 ? Weather[0] : null;
    }

    public class MainData
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class WindData
    {
        public double Speed { get; set; }
    }

    public class WeatherData
    {
        public string Main { get; set; }
    }
}
