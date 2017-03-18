using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class CoPaymentFrecuencyValidator : AbstractValidator<CoPaymentFrecuency>
    {
        public CoPaymentFrecuencyValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(MessageValidator.NameCoPaymentFrecuencyRequired);
        }
    }
}
