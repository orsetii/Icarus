using Microsoft.JSInterop;

namespace Veil.Util
{
    public class Geolocation
    {
        public async static Task<double> GetLatitude(IJSRuntime js)
        {
            return await js.InvokeAsync<double>("getLatitude");
        }

        public async static Task<double> GetLongitude(IJSRuntime js)
        {
            return await js.InvokeAsync<double>("getLongitude");
        }
    }
}
