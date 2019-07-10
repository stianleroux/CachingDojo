namespace CachingDojo.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;
    using CachingDojo.Data.Queries;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    [Route("api/AirportFrequencies")]
    public class AirportFrequenciesController
    {
        private IMemoryCache cache;

        public AirportFrequenciesController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<IEnumerable<AirportFrequencies>> List(bool caching = false)
        {
            IEnumerable<AirportFrequencies> listResult;
            if (caching)
            {
                return cache.GetOrCreate<IEnumerable<AirportFrequencies>>("AirportFrequencies",
                    cacheEntry => {
                        return AirportFrequenciesExtensions.Get();
                    });
            }
            listResult = AirportFrequenciesExtensions.Get();
            return listResult;
        }
    }
}