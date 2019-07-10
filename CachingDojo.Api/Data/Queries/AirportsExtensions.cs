namespace CachingDojo.Data.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;

    /// <summary>
    /// Get Airports
    /// </summary>
    public static partial class AirportsExtensions
    {
        /// <summary>
        /// Gets the by asynchronous.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Airports> Get()
        {
            return CSVExtensions<Airports>.GetByAsync("airports");
        }

    }
}
