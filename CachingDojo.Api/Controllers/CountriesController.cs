namespace CachingDojo.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CachingDojo.Data.Entities;
    using CachingDojo.Data.Queries;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    [Route("api/Countries")]
    public class CountriesController
    {
        private IMemoryCache cache;

        public CountriesController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<IEnumerable<Countries>> List(bool caching = false)
        {
            IEnumerable<Countries> listResult;
            if (caching)
            {
                return cache.GetOrCreate<IEnumerable<Countries>>("Countries",
                    cacheEntry => {
                        return CountriesExtensions.Get();
                    });
            }
            listResult = CountriesExtensions.Get();
            return listResult;
        }
    }
}