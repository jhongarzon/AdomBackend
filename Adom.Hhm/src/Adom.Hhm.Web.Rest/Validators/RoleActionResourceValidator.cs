using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class RoleActionResourceValidator : AbstractValidator<RoleActionResource>
    {
        public RoleActionResourceValidator()
        {
            RuleFor(x => x.ActionId).NotNull().WithMessage(MessageValidator.ActionIdRequired);
            RuleFor(x => x.ResourceId).NotNull().WithMessage(MessageValidator.ActionIdRequired);
            RuleFor(x => x.HasRole).NotNull().WithMessage(MessageValidator.HasRoleIdRequired);
            RuleFor(x => x.RoleId).NotNull().WithMessage(MessageValidator.RoleIdRequired);
        }
    }
}
