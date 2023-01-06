using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace Veil.Data.Geolocation
{
    /// <summary>
    /// NONE OF THIS SHIT WORKS
    /// </summary>
    public class GeolocationService
    {
        /// <summary>
        /// NONE OF THIS SHIT WORKS
        /// </summary>
        public static async Task<GeolocationPosition> GetGeolocationPositionAsync(IJSRuntime jsRuntime, PositionOptions options)
        {
                return await jsRuntime.InvokeAsync<GeolocationPosition>("getCurrentPosition", options);
        }
        public static async Task<GeolocationPosition> GetGeolocationPositionAsync(IJSRuntime jsRuntime)
        {
            return await GetGeolocationPositionAsync(jsRuntime, new PositionOptions());
        }
    }
}
