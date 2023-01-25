
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Veil.Data.Geolocation
{
    /// <summary>
    /// Geolocation Position, based on <see href="https://developer.mozilla.org/en-US/docs/Web/API/GeolocationPosition"/>.
    /// </summary>
    public class GeolocationPosition
    {

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The coordinates defining the current location
        /// </summary>
        public GeolocationCoordinates Coords { get; set; }

        /// <summary>
        /// The time the coordinates were taken, in milliseconds since the Unix epoch.
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> derived from the <see cref="Timestamp"/>, in UTC.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset DateTimeOffset => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp);
    }
}
