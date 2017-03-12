using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(MessageValidator.NameServiceRequired);
            RuleFor(x => x.Value).NotNull().WithMessage(MessageValidator.ValueServiceRequired);
            RuleFor(x => x.Value).GreaterThan(0).WithMessage(MessageValidator.ValueGreaterServiceRequired);
            RuleFor(x => x.Code).NotNull().WithMessage(MessageValidator.CodeServiceRequired);
            RuleFor(x => x.ClassificationId).NotEqual(-1).WithMessage(MessageValidator.ClassificationServiceRequired);
            RuleFor(x => x.ServiceTypeId).NotEqual(-1).WithMessage(MessageValidator.ServiceTypeServiceRequired);
        }
    }
}
