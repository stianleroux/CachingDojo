namespace CachingDojo.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;
    using CachingDojo.Data.Queries;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    [Route("api/Runways")]
    public class RunwaysController
    {
        private IMemoryCache cache;

        public RunwaysController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<IEnumerable<Runways>> List(bool caching = false)
        {
            IEnumerable<Runways> listResult;
            if (caching)
            {
                return cache.GetOrCreate<IEnumerable<Runways>>("Runways",
                    cacheEntry => {
                        return RunwaysExtensions.Get();
                    });
            }
            listResult = RunwaysExtensions.Get();
            return listResult;
        }
    }
}