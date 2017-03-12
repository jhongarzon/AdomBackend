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
            return dic;
        }
    }
}
