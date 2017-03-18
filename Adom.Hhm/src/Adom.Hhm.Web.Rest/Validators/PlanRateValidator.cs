﻿using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class PlanRateValidator : AbstractValidator<PlanRate>
    {
        public PlanRateValidator()
        {
            RuleFor(x => x.PlanName).NotNull().WithMessage(MessageValidator.NamePlanRateRequired);
            RuleFor(x => x.EntityId).NotEqual(-1).WithMessage(MessageValidator.EntityIdEntityRequired);
            RuleFor(x => x.ServiceId).NotEqual(-1).WithMessage(MessageValidator.ServiceRequired);
            RuleFor(x => x.Rate).NotNull().WithMessage(MessageValidator.RateRequired);
            RuleFor(x => x.Validity).NotNull().WithMessage(MessageValidator.ValidityRequired);
        }
    }
}
