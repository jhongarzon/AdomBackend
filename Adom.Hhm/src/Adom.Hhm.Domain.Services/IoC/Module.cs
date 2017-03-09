using Adom.Hhm.Domain.Services.Interface;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(IProfessionalDomainService), typeof(ProfessionalDomainServices));
            dic.Add(typeof(IPatientDomainService), typeof(PatientDomainServices));
            return dic;
        }
    }
}
