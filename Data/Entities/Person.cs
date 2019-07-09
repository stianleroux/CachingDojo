using CachingDojo.Definitions;
using System;
using System.Collections.Generic;

namespace CachingDojo.Data.Entities
{
    public partial class Person : IHaveIdentifier
    {
        public Person()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Active { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Company Company { get; set; }

        #endregion

    }
}
