using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class AssignServiceSupplyValidator : AbstractValidator<AssignServiceSupply>
    {
        public AssignServiceSupplyValidator()
        {
            RuleFor(x => x.AssignServiceSupplyId).NotNull().WithMessage(MessageValidator.IdSuAssignServiceSupplyRequired);
            RuleFor(x => x.AssignServiceId).NotNull().WithMessage(MessageValidator.IdAssignServiceSupplyRequired);
            RuleFor(x => x.BilledToId).NotEmpty().WithMessage(MessageValidator.BilledIdAssignServiceSupplyRequired);
            RuleFor(x => x.Quantity).NotNull().WithMessage(MessageValidator.QuantityAssignServiceSupplyRequired);
            RuleFor(x => x.SupplyId).NotEmpty().WithMessage(MessageValidator.SupplyIdAssignServiceSupplyRequired);
        }
    }
}
