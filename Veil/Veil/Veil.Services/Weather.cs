using ThirdPartyApis;

namespace Veil.Services
{
    public class Weather
    {

        public async static Task<ForecastResult> GetTodaysWeather(double Latitude, double Longitude)
        {
            var api = new OpenMeteo();
            return await api.GetForecast(Latitude, Longitude, DateTime.Today, DateTime.Today);
        }

    }
}