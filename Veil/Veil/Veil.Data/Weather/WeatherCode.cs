namespace Veil.Data.Weather
{


    public class WeatherCode
    {
        const string ERROR_DESCRIPTION = "Error: No matching weather description was found. Requested weather code was: ";
        static readonly Dictionary<int[], string> WeatherCodeDictionary = new Dictionary<int[], string> 
        {
            {new int[] {0}, "Clear sky" },
            {new int[] {1,2,3}, "Mainly clear, partly cloudy, and overcast" },
            {new int[] {45, 48}, "Fog and depositing rime fog" },
            {new int[] {51, 53, 55}, "Drizzle: Light, moderate, and dense intensity" },
            {new int[] {56, 57}, "Freezing Drizzle: Light and dense intensity" },
            {new int[] {61,63,65}, "Rain: Slight, moderate and heavy intensity" },
            {new int[] {66,67}, "Freezing Rain: Light and heavy intensity" },
            {new int[] {71,73,75}, "Snow fall: Slight, moderate, and heavy intensity" },
            {new int[] {77}, "Snow grains" },
            {new int[] {80,81,82}, "Rain showers: Slight, moderate, and violent" },
            {new int[] {85,86}, "Snow showers slight and heavy" },
            {new int[] {95}, "Thunderstorm: Slight or moderate" },
            {new int[] {96,99}, "Thunderstorm with slight and heavy hail" },
        };

        public int NumericalCode { get; set; }
        public string? Description { get; set; }

        public WeatherCode(int numericalCode)
        {
            NumericalCode = numericalCode;
            Description = GetDescriptionFromNumericalCode(numericalCode);
        }

        public static string GetDescriptionFromNumericalCode(int weatherCode)
        {
            try
            {
                return WeatherCodeDictionary.Single((x) => x.Key.Contains(weatherCode)).Value;
            }
            catch (Exception e)
            {
                return $"{ERROR_DESCRIPTION}{weatherCode}";
            }
        }

    }
}
