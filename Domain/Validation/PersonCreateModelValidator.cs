using System;
using FluentValidation;
using CachingDojo.Domain.Models;

namespace CachingDojo.Domain.Validation
{
    public partial class PersonCreateModelValidator
        : AbstractValidator<PersonCreateModel>
    {
        public PersonCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(150);
            RuleFor(p => p.Surname).NotEmpty();
            RuleFor(p => p.Surname).MaximumLength(150);
            #endregion
        }

    }
}
