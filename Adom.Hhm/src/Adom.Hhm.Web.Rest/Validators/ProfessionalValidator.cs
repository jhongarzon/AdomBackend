using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class ProfessionalValidator : AbstractValidator<Professional>
    {
        public ProfessionalValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(MessageValidator.EmailRequired);
            RuleFor(x => x.FirstName).NotNull().WithMessage(MessageValidator.FirstNameRequired);
            RuleFor(x => x.Surname).NotNull().WithMessage(MessageValidator.SurnameRequired);
            RuleFor(x => x.DocumentTypeId).NotEqual(-1).WithMessage(MessageValidator.DocumentTypeIdRequired);
            RuleFor(x => x.Document).NotNull().WithMessage(MessageValidator.DocumentRequired);
            RuleFor(x => x.GenderId).NotEqual(-1).WithMessage(MessageValidator.GenderRequired);
            RuleFor(x => x.SpecialtyId).NotEqual(-1).WithMessage(MessageValidator.SpecialtyRequired);
            RuleFor(x => x.Telephone1).NotNull().WithMessage(MessageValidator.Telephone1Required);
            RuleFor(x => x.CodeBank).NotNull().WithMessage(MessageValidator.BankRequired);
            RuleFor(x => x.AccountNumber).NotNull().WithMessage(MessageValidator.AccountRequired);
            RuleFor(x => x.AccountTypeId).NotEqual(-1).WithMessage(MessageValidator.AccountTypeRequired);
        }
    }
}
