using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                {typeof (IAuthenticationRepository), typeof (AuthenticationRepository)},
                {typeof (IAuthorizationRepository), typeof (AuthorizationRepository)},
                {typeof (IUserRepository), typeof (UserRepository)},
                {typeof (IRoleRepository), typeof (RoleRepository)},
                {typeof (IUserRoleRepository), typeof (UserRoleRepository)},
                {typeof (IRoleActionResourceRepository), typeof (RoleActionResourceRepository)},
                {typeof (IProfessionalRepository), typeof (ProfessionalRepository)},
                {typeof (IParameterRepository), typeof (ParameterRepository)},
                {typeof (IPatientRepository), typeof (PatientRepository)},
                {typeof (ICoordinatorRepository), typeof (CoordinatorRepository)},
                {typeof (IEntityRepository), typeof (EntityRepository)},
                {typeof (ISupplyRepository), typeof (SupplyRepository)},
                {typeof (IServiceFrecuencyRepository), typeof (ServiceFrecuencyRepository)},
                {typeof (ICoPaymentFrecuencyRepository), typeof (CoPaymentFrecuencyRepository)},
                {typeof (IPlanRateRepository), typeof (PlanRateRepository)},
                {typeof (IAssignServiceRepository), typeof (AssignServiceRepository)},
                {typeof (IAssignServiceDetailRepository), typeof (AssignServiceDetailRepository)},
                {typeof (IAssignServiceSupplyRepository), typeof (AssignServiceSupplyRepository)},
                {typeof (IServiceRepository), typeof (ServiceRepository)},
                {typeof (IPlanEntityRepository), typeof (PlanEntityRepository)},
                {typeof (INoticeRepository), typeof (NoticeRepository)},
                {typeof (IProfessionalAssignedRepository), typeof (ProfessionalAssignedRepository)},
                {typeof (ICopaymentRepository), typeof (CopaymentRepository)},
                {typeof (IRipsRepository), typeof (RipsRepository)}
            };
            return dic;
        }
    }
}
