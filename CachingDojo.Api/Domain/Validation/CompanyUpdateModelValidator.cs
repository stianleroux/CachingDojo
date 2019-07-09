using System;
using FluentValidation;
using CachingDojo.Domain.Models;

namespace CachingDojo.Domain.Validation
{
    public partial class CompanyUpdateModelValidator
        : AbstractValidator<CompanyUpdateModel>
    {
        public CompanyUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.CompanyMember).NotEmpty();
            RuleFor(p => p.CompanyMember).MaximumLength(150);
            #endregion
        }

    }
}
