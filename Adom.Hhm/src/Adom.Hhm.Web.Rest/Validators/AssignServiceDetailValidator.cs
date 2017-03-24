using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class AssignServiceDetailValidator : AbstractValidator<AssignServiceDetail>
    {
        public AssignServiceDetailValidator()
        {
            RuleFor(x => x.AssignServiceDetailId).NotNull().WithMessage(MessageValidator.IdDetailAssignServiceDetailRequired);
            RuleFor(x => x.AssignServiceId).NotNull().WithMessage(MessageValidator.IdAssignServiceDetailRequired);
            RuleFor(x => x.Consecutive).NotNull().WithMessage(MessageValidator.ConsecutiveAssignServiceDetailRequired);
            RuleFor(x => x.DateVisit).NotNull().WithMessage(MessageValidator.DateVisitAssignServiceDetailRequired);
            RuleFor(x => x.ProfessionalId).NotNull().WithMessage(MessageValidator.ProfessionalIdAssignServiceDetailRequired);
        }
    }
}
