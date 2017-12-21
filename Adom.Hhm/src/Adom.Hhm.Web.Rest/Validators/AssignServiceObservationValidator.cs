using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class AssignServiceObservationValidator : AbstractValidator<ServiceObservation>
    {
        public AssignServiceObservationValidator()
        {
            RuleFor(x => x.AssignServiceId).NotEqual(0).WithMessage(MessageValidator.ServiceAssignServiceRequired);
            RuleFor(x => x.Description).NotNull().WithMessage(MessageValidator.ServiceObservationRequired);
            RuleFor(x => x.UserId).NotEqual(0).WithMessage(MessageValidator.UserIdRequired);
        }
    }
}
