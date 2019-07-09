using System;
using AutoMapper;
using CachingDojo.Data.Entities;
using CachingDojo.Domain.Models;

namespace CachingDojo.Domain.Mapping
{
    public partial class PersonProfile
        : AutoMapper.Profile
    {
        public PersonProfile()
        {
            CreateMap<CachingDojo.Data.Entities.Person, CachingDojo.Domain.Models.PersonReadModel>();
            CreateMap<CachingDojo.Domain.Models.PersonCreateModel, CachingDojo.Data.Entities.Person>();
            CreateMap<CachingDojo.Data.Entities.Person, CachingDojo.Domain.Models.PersonUpdateModel>();
            CreateMap<CachingDojo.Domain.Models.PersonUpdateModel, CachingDojo.Data.Entities.Person>();
        }

    }
}
