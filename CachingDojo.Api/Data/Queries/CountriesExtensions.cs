namespace CachingDojo.Data.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;

    /// <summary>
    /// Get Countries
    /// </summary>
    public static partial class CountriesExtensions
    {
        /// <summary>
        /// Gets the by asynchronous.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Countries> Get()
        {
            return CSVExtensions<Countries>.GetByAsync("countries");
        }

    }
}
