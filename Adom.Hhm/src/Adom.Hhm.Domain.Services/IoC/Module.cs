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
            dic.Add(typeof(IParameterDomainService), typeof(ParameterDomainServices));
            dic.Add(typeof(ICoordinatorDomainService), typeof(CoordinatorDomainServices));
            dic.Add(typeof(IEntityDomainService), typeof(EntityDomainServices));
            dic.Add(typeof(ISupplyDomainService), typeof(SupplyDomainServices));
            dic.Add(typeof(IServiceDomainService), typeof(ServiceDomainServices));
            dic.Add(typeof(IServiceFrecuencyDomainService), typeof(ServiceFrecuencyDomainServices));
            dic.Add(typeof(ICoPaymentFrecuencyDomainService), typeof(CoPaymentFrecuencyDomainServices));
            dic.Add(typeof(IPlanRateDomainService), typeof(PlanRateDomainServices));
            dic.Add(typeof(IAssignServiceDomainService), typeof(AssignServiceDomainServices));
            dic.Add(typeof(IAssignServiceDetailDomainService), typeof(AssignServiceDetailDomainServices));
            dic.Add(typeof(IAssignServiceSupplyDomainService), typeof(AssignServiceSupplyDomainServices));
            dic.Add(typeof(IPlanEntityDomainService), typeof(PlanEntityDomainServices));
            return dic;
        }
    }
}
