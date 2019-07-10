namespace CachingDojo.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;
    using CachingDojo.Data.Queries;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    [Route("api/Airports")]
    public class AirportsController
    {
        private IMemoryCache cache;

        public AirportsController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<IEnumerable<Airports>> List(bool caching = false)
        {
            IEnumerable<Airports> listResult;
            if (caching)
            {
                return cache.GetOrCreate<IEnumerable<Airports>>("Airports",
                    cacheEntry => {
                        return AirportsExtensions.Get();
                    });
            }
            listResult = AirportsExtensions.Get();
            return listResult;
        }
    }
}