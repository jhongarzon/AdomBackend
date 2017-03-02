using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.RoleName).NotNull().WithMessage(MessageValidator.NameRoleRequired);
            RuleFor(x => x.UserId).NotNull().WithMessage(MessageValidator.UserIdRequired);
            RuleFor(x => x.RoleId).NotNull().WithMessage(MessageValidator.RoleIdRequired);
            RuleFor(x => x.HasRole).NotNull().WithMessage(MessageValidator.RoleIdRequired);
        }
    }
}
