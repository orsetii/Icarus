using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ThirdPartyApis
{
    public class OpenMeteo
    {
        const string API_URL = "https://api.open-meteo.com/v1/";
        const string HOURLY_INFORMATION = "temperature_2m,relativehumidity_2m,dewpoint_2m,apparent_temperature,precipitation,rain,showers,snowfall,snow_depth,freezinglevel_height,weathercode,surface_pressure,cloudcover,visibility,evapotranspiration,et0_fao_evapotranspiration,windspeed_10m,winddirection_10m,windgusts_10m,soil_temperature_0cm,soil_moisture_0_1cm";
        const string DAILY_INFORMATION = "weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,precipitation_sum,rain_sum,showers_sum,snowfall_sum,precipitation_hours,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant,shortwave_radiation_sum,et0_fao_evapotranspiration";

        const string DEFAULT_TIMEZONE = "Europe/London";
        static HttpClient client = new HttpClient();
        public OpenMeteo()
        {

        }



        /// <summary>
        /// Retreives the weather forecast at a given location for
        /// </summary>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        /// <returns></returns>
        public async Task<ForecastResult> GetForecast(double Latitude, double Longitude, DateTime dateFrom, DateTime dateTo)
        {
            var paramDictionary = GetForecastParameters(Latitude, Longitude, dateFrom, dateTo);


            return await DoCall<ForecastResult>(ApiCallType.Forecast, paramDictionary);
        }

        private Dictionary<string, string> GetForecastParameters(double Latitude, double Longitude, DateTime dateFrom, DateTime dateTo)
        {
            var paramDict = new Dictionary<string, string>() { };
            paramDict.Add("latitude", Latitude.ToString());
            paramDict.Add("longitude", Longitude.ToString());


            // Note, parameters are added in a comma delimited list for either hourly or daily. Therefore,
            // TODO we should create a file for the system to be able to add/remove parameters, and seperate
            // them by either daily or hourly to easily add them into the api call.

            paramDict.Add("hourly", HOURLY_INFORMATION);
            paramDict.Add("daily", DAILY_INFORMATION);

            paramDict.Add("timezone", DEFAULT_TIMEZONE);

            paramDict.Add("start_date", dateFrom.ToString("yyyy-MM-dd"));
            paramDict.Add("end_date", dateTo.ToString("yyyy-MM-dd"));




            return paramDict;
        }

        private static async Task<T> DoCall<T>(ApiCallType callType, Dictionary<string, string> paramDictionary)
        {
            var url = API_URL + callType.ToString().ToLower();
            var FinalApiURL = new Uri(QueryHelpers.AddQueryString(url, paramDictionary));

            var response = await client.GetAsync(FinalApiURL.ToString());
            var responseBody = await response.Content.ReadAsStringAsync();


            var bob = JsonConvert.DeserializeObject<T>(responseBody) 
                           ?? throw new Exception("No Forecast Result could be processed");
            return bob;

        }

        public enum ApiCallType
        {
            Forecast
        }
    }
        public class ForecastResult
        {
            [Key]
            public int Id { get; set; }
            public Daily daily { get; set; }
            public DailyUnits daily_units { get; set; }
            public double elevation { get; set; }
            public double generationtime_ms { get; set; }
            public Hourly hourly { get; set; }
            public HourlyUnits hourly_units { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string timezone { get; set; }
            public string timezone_abbreviation { get; set; }
            public int utc_offset_seconds { get; set; }
        public DateTime dt_retreived { get; set; } = DateTime.Now;
        }

        public class Daily
        {
        [Key]
        public int Id { get; set; }
            public List<double> apparent_temperature_max { get; set; }
            public List<double> apparent_temperature_min { get; set; }
            public List<double> et0_fao_evapotranspiration { get; set; }
            public List<double> precipitation_hours { get; set; }
            public List<double> precipitation_sum { get; set; }
            public List<double> rain_sum { get; set; }
            public List<double> shortwave_radiation_sum { get; set; }
            public List<double> showers_sum { get; set; }
            public List<double> snowfall_sum { get; set; }
            public List<string> sunrise { get; set; }
            public List<string> sunset { get; set; }
            public List<double> temperature_2m_max { get; set; }
            public List<double> temperature_2m_min { get; set; }
            public List<string> time { get; set; }
            public List<int> weathercode { get; set; }
            public List<int> winddirection_10m_dominant { get; set; }
            public List<double> windgusts_10m_max { get; set; }
            public List<double> windspeed_10m_max { get; set; }
        }

        public class DailyUnits
        {
        [Key]
        public int Id { get; set; }
            public string apparent_temperature_max { get; set; }
            public string apparent_temperature_min { get; set; }
            public string et0_fao_evapotranspiration { get; set; }
            public string precipitation_hours { get; set; }
            public string precipitation_sum { get; set; }
            public string rain_sum { get; set; }
            public string shortwave_radiation_sum { get; set; }
            public string showers_sum { get; set; }
            public string snowfall_sum { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public string temperature_2m_max { get; set; }
            public string temperature_2m_min { get; set; }
            public string time { get; set; }
            public string weathercode { get; set; }
            public string winddirection_10m_dominant { get; set; }
            public string windgusts_10m_max { get; set; }
            public string windspeed_10m_max { get; set; }
        }

        public class Hourly
        {
        [Key]
        public int Id { get; set; }
            public List<double> apparent_temperature { get; set; }
            public List<int> cloudcover { get; set; }
            public List<double> dewpoint_2m { get; set; }
            public List<double> et0_fao_evapotranspiration { get; set; }
            public List<double> evapotranspiration { get; set; }
            public List<double> freezinglevel_height { get; set; }
            public List<double> precipitation { get; set; }
            public List<double> rain { get; set; }
            public List<int> relativehumidity_2m { get; set; }
            public List<double> showers { get; set; }
            public List<double> snow_depth { get; set; }
            public List<double> snowfall { get; set; }
            public List<double> soil_moisture_0_1cm { get; set; }
            public List<double> soil_temperature_0cm { get; set; }
            public List<double> surface_pressure { get; set; }
            public List<double> temperature_2m { get; set; }
            public List<string> time { get; set; }
            public List<double> visibility { get; set; }
            public List<int> weathercode { get; set; }
            public List<int> winddirection_10m { get; set; }
            public List<double> windgusts_10m { get; set; }
            public List<double> windspeed_10m { get; set; }
        }

        public class HourlyUnits
        {
        [Key]
        public int Id { get; set; }
            public string apparent_temperature { get; set; }
            public string cloudcover { get; set; }
            public string dewpoint_2m { get; set; }
            public string et0_fao_evapotranspiration { get; set; }
            public string evapotranspiration { get; set; }
            public string freezinglevel_height { get; set; }
            public string precipitation { get; set; }
            public string rain { get; set; }
            public string relativehumidity_2m { get; set; }
            public string showers { get; set; }
            public string snow_depth { get; set; }
            public string snowfall { get; set; }
            public string soil_moisture_0_1cm { get; set; }
            public string soil_temperature_0cm { get; set; }
            public string surface_pressure { get; set; }
            public string temperature_2m { get; set; }
            public string time { get; set; }
            public string visibility { get; set; }
            public string weathercode { get; set; }
            public string winddirection_10m { get; set; }
            public string windgusts_10m { get; set; }
            public string windspeed_10m { get; set; }
        }


}