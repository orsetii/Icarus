using ThirdPartyApis;
using Veil.Data.Weather;

namespace Veil.Services
{
    public class WeatherService
    {

        public ForecastResult ForecastResult { get; set; }
        public List<WeatherCode>? DailyWeatherCodes { get; set; }
        public List<WeatherCode>? HourlyWeatherCodes { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public WeatherService(double latitude, double longitude)
        {

            Latitude = latitude;
            Longitude = longitude;
            Task.Run(GetTodaysWeather).Wait();

            if(ForecastResult is null)
            {
                throw new Exception($"Unable to get forecast for location: Lat={Latitude}, Long={Longitude}");
            }

            // Attempt to convert daily and then hourly weather codes into their full classes, giving us 
            // (WMO-matched) descriptions of the weather.
            DailyWeatherCodes = ConvertNumericalWeatherCodeListIntoUsable(ForecastResult.daily.weathercode);
            HourlyWeatherCodes = ConvertNumericalWeatherCodeListIntoUsable(ForecastResult.hourly.weathercode);

        }

        public async Task GetTodaysWeather()
        {
            // TODO check if we recently checked for weather in this (or very close area) recently, if so,
            // do not resend request for update.
            var api = new OpenMeteo();
            ForecastResult = await api.GetForecast(Latitude, Longitude, DateTime.Today, DateTime.Today);
        }

        // TODO, need to attach the timestamp of each weathercode into the class ctor
        private List<WeatherCode> ConvertNumericalWeatherCodeListIntoUsable(List<int> numericalCodeList)
        {
            var FullWeatherCodeList = new List<WeatherCode>() { };
            numericalCodeList.ForEach((x) => FullWeatherCodeList.Add(new WeatherCode(x)));
            return FullWeatherCodeList; 
        }

    }
}