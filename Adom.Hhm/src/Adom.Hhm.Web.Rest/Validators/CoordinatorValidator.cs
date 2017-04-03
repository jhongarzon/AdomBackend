using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class CoordinatorValidator : AbstractValidator<Coordinator>
    {
        public CoordinatorValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(MessageValidator.EmailRequired);
            RuleFor(x => x.FirstName).NotNull().WithMessage(MessageValidator.FirstNameRequired);
            RuleFor(x => x.Surname).NotNull().WithMessage(MessageValidator.SurnameRequired);
            RuleFor(x => x.DocumentTypeId).NotEqual(-1).WithMessage(MessageValidator.DocumentTypeIdRequired);
            RuleFor(x => x.Document).NotNull().WithMessage(MessageValidator.DocumentRequired);
            RuleFor(x => x.GenderId).NotEqual(-1).WithMessage(MessageValidator.GenderRequired);
            RuleFor(x => x.Telephone1).NotNull().WithMessage(MessageValidator.Telephone1Required);
        }
    }
}
