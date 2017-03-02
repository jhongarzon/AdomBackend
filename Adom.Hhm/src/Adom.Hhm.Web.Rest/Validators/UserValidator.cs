using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(MessageValidator.EmailRequired);
            RuleFor(x => x.FirstName).NotNull().WithMessage(MessageValidator.FirstNameRequired);
            RuleFor(x => x.Surname).NotNull().WithMessage(MessageValidator.SurnameRequired);
        }
    }
}
