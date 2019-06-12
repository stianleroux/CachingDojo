using System;
using FluentValidation;
using CachingDojo.Domain.Models;

namespace CachingDojo.Domain.Validation
{
    public partial class CompanyCreateModelValidator
        : AbstractValidator<CompanyCreateModel>
    {
        public CompanyCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.CompanyMember).NotEmpty();
            RuleFor(p => p.CompanyMember).MaximumLength(150);
            #endregion
        }

    }
}
