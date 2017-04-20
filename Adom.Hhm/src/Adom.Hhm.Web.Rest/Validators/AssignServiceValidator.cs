﻿using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class AssignServiceValidator : AbstractValidator<AssignService>
    {
        public AssignServiceValidator()
        {
            RuleFor(x => x.AuthorizationNumber).NotNull().WithMessage(MessageValidator.AuthorizationNumberAssignServiceRequired);
            RuleFor(x => x.Validity).NotNull().WithMessage(MessageValidator.ValidityAssignServiceRequired);
            RuleFor(x => x.ApplicantName).NotNull().WithMessage(MessageValidator.ApplicantNameAssignServiceRequired);
            RuleFor(x => x.ServiceId).NotNull().WithMessage(MessageValidator.ServiceIdAssignServiceRequired);
            RuleFor(x => x.Quantity).NotEqual(0).WithMessage(MessageValidator.QuantityAssignServiceRequired);
            RuleFor(x => x.InitialDate).NotNull().WithMessage(MessageValidator.InitialDateAssignServiceRequired);
            RuleFor(x => x.FinalDate).NotNull().WithMessage(MessageValidator.FinalDateAssignServiceRequired);
            RuleFor(x => x.ServiceFrecuencyId).NotEqual(-1).WithMessage(MessageValidator.ServiceFrecuencyIdAssignServiceRequired);
            RuleFor(x => x.ProfessionalId).NotNull().WithMessage(MessageValidator.ProfessionalIdAssignServiceRequired);
            RuleFor(x => x.CoPaymentAmount).NotNull().WithMessage(MessageValidator.CoPaymentAmountAssignServiceRequired);
            RuleFor(x => x.Consultation).NotNull().WithMessage(MessageValidator.ConsultationAssignServiceRequired);
            RuleFor(x => x.External).NotNull().WithMessage(MessageValidator.ExternalAssignServiceRequired);
        }
    }
}
