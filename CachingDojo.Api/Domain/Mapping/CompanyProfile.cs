using System;
using AutoMapper;
using CachingDojo.Data.Entities;
using CachingDojo.Domain.Models;

namespace CachingDojo.Domain.Mapping
{
    public partial class CompanyProfile
        : AutoMapper.Profile
    {
        public CompanyProfile()
        {
            CreateMap<CachingDojo.Data.Entities.Company, CachingDojo.Domain.Models.CompanyReadModel>();
            CreateMap<CachingDojo.Domain.Models.CompanyCreateModel, CachingDojo.Data.Entities.Company>();
            CreateMap<CachingDojo.Data.Entities.Company, CachingDojo.Domain.Models.CompanyUpdateModel>();
            CreateMap<CachingDojo.Domain.Models.CompanyUpdateModel, CachingDojo.Data.Entities.Company>();
        }

    }
}
