namespace Veil.Data.Geolocation
{
    /// <summary>
    /// The reason for a Geolocation error, based on <see href="https://developer.mozilla.org/en-US/docs/Web/API/GeolocationPositionError"/>.
    /// </summary>
    public class GeolocationPositionError
    {
        /// <summary>
        /// The <see cref="GeolocationPositionErrorCode"/> for the error.
        /// </summary>
        public GeolocationPositionErrorCode Code { get; set; }

        /// <summary>
        /// Details of the error. Intended for debugging rather than display to the user.
        /// </summary>
        public string Message { get; set; }
    }
    /// <summary>
    /// An enumeration of error codes used by <see cref="GeolocationPositionError"/>.
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/API/GeolocationPositionError/code"/>.
    /// </summary>
    public enum GeolocationPositionErrorCode
    {
        /// <summary>
        /// Geolocation failoed because the device does not support geolocation. Not part of W3C spec.
        /// </summary>
        DEVICE_NOT_SUPPORTED = 0,
        /// <summary>
        /// Geolocation failed because permission to access location was denied.
        /// </summary>
        PERMISSION_DENIED = 1,
        /// <summary>
        /// Geolocation failed because of an internal error on the device.
        /// </summary>
        POSITION_UNAVAILABLE = 2,
        /// <summary>
        /// Geolocation failed because no position was returned in time.
        /// </summary>
        TIMEOUT = 3
    }
}
