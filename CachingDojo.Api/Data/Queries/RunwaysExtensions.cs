namespace CachingDojo.Data.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;

    /// <summary>
    /// Get Runways
    /// </summary>
    public static partial class RunwaysExtensions
    {
        /// <summary>
        /// Gets the by asynchronous.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Runways> Get()
        {
            return CSVExtensions<Runways>.GetByAsync("runways");
        }

    }
}
