using Adom.Hhm.AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.AppServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(IProfessionalAppService), typeof(ProfessionalAppService));
            dic.Add(typeof(IPatientAppService), typeof(PatientAppService));
            dic.Add(typeof(IParameterAppService), typeof(ParameterAppService));
            dic.Add(typeof(ICoordinatorAppService), typeof(CoordinatorAppService));
            dic.Add(typeof(IEntityAppService), typeof(EntityAppService));
            dic.Add(typeof(ISupplyAppService), typeof(SupplyAppService));
            dic.Add(typeof(IServiceAppService), typeof(ServiceAppService));
            dic.Add(typeof(IServiceFrecuencyAppService), typeof(ServiceFrecuencyAppService));
            dic.Add(typeof(ICoPaymentFrecuencyAppService), typeof(CoPaymentFrecuencyAppService));
            dic.Add(typeof(IPlanRateAppService), typeof(PlanRateAppService));
            dic.Add(typeof(IAssignServiceAppService), typeof(AssignServiceAppService));
            dic.Add(typeof(IAssignServiceDetailAppService), typeof(AssignServiceDetailAppService));
            dic.Add(typeof(IAssignServiceSupplyAppService), typeof(AssignServiceSupplyAppService));
            dic.Add(typeof(IPlanEntityAppService), typeof(PlanEntityAppService));
            dic.Add(typeof(INoticeAppService), typeof(NoticeAppService));
            return dic;
        }
    }
}
