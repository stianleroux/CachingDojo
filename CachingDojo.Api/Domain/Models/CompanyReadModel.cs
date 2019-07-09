using CachingDojo.Data.Entities;
using System;
using System.Collections.Generic;

namespace CachingDojo.Domain.Models
{
    public partial class CompanyReadModel
    {
        #region Generated Properties
        public int Id { get; set; }

        public string CompanyMember { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Active { get; set; }

        #endregion

    }
}
