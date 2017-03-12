using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class SupplyValidator : AbstractValidator<Supply>
    {
        public SupplyValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(MessageValidator.NameSupplyRequired);
            RuleFor(x => x.Presentation).NotNull().WithMessage(MessageValidator.PresentationSupplyRequired);
            RuleFor(x => x.Code).NotNull().WithMessage(MessageValidator.CodeSupplyRequired);
        }
    }
}
