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
            return dic;
        }
    }
}
