using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CachingDojo.Data;
using CachingDojo.Domain.Models;
using Microsoft.AspNet.OData;

namespace CachingDojo.Controllers
{
    [Route("api/Company")]
    public class CompaniesController : EntityControllerBase<Data.Entities.Company, CompanyReadModel, CompanyCreateModel, CompanyUpdateModel>
    {
        public CompaniesController(CachingDojoContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyReadModel>> Get(CancellationToken cancellationToken, int id)
        {
            var readModel = await ReadModel(id, cancellationToken);

            if (readModel == null)
                return NotFound();

            return readModel;
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IReadOnlyList<CompanyReadModel>>> List(CancellationToken cancellationToken)
        {
            var listResult = await QueryModel(null, cancellationToken);
            return Ok(listResult);
        }

        [HttpPost("")]
        public async Task<ActionResult<CompanyReadModel>> Create(CancellationToken cancellationToken, CompanyCreateModel createModel)
        {
            var readModel = await CreateModel(createModel, cancellationToken);

            return readModel;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyReadModel>> Update(CancellationToken cancellationToken, int id, CompanyUpdateModel updateModel)
        {
            var readModel = await UpdateModel(id, updateModel, cancellationToken);
            if (readModel == null)
                return NotFound();

            return readModel;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyReadModel>> Delete(CancellationToken cancellationToken, int id)
        {
            var readModel = await DeleteModel(id, cancellationToken);
            if (readModel == null)
                return NotFound();

            return readModel;
        }
    }
}