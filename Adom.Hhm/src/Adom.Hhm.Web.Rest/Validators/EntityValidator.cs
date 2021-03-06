﻿using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Web.Rest.Validators
{
    public class EntityValidator : AbstractValidator<Entity>
    {
        public EntityValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(MessageValidator.NameEntityRequired);
            RuleFor(x => x.BusinessName).NotNull().WithMessage(MessageValidator.BusinessEntityRequired);
            RuleFor(x => x.Code).NotNull().WithMessage(MessageValidator.CodeEntityRequired);
            RuleFor(x => x.Nit).NotNull().WithMessage(MessageValidator.NitEntityRequired);
        }
    }
}
