using CachingDojo.Definitions;
using System;
using System.Collections.Generic;

namespace CachingDojo.Data.Entities
{
    public partial class Company : IHaveIdentifier
    {
        public Company()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string CompanyMember { get; set; }

        public int PersonId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Active { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        #endregion

    }
}
