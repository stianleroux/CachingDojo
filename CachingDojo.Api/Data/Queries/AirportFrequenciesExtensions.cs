namespace CachingDojo.Data.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;

    /// <summary>
    /// Get Airport Frequencies
    /// </summary>
    public static partial class AirportFrequenciesExtensions
    {
        /// <summary>
        /// Gets the by asynchronous.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<AirportFrequencies> Get()
        {
            return CSVExtensions<AirportFrequencies>.GetByAsync("airport-frequencies");
        }

    }
}
