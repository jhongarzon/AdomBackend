using Adom.Hhm.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Services.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                {typeof (IHomeDomainService), typeof (HomeDomainService)},
                {typeof (IProfessionalDomainService), typeof (ProfessionalDomainServices)},
                {typeof (IPatientDomainService), typeof (PatientDomainServices)},
                {typeof (IParameterDomainService), typeof (ParameterDomainServices)},
                {typeof (ICoordinatorDomainService), typeof (CoordinatorDomainServices)},
                {typeof (IEntityDomainService), typeof (EntityDomainServices)},
                {typeof (ISupplyDomainService), typeof (SupplyDomainServices)},
                {typeof (IServiceDomainService), typeof (ServiceDomainServices)},
                {typeof (IServiceFrecuencyDomainService), typeof (ServiceFrecuencyDomainServices)},
                {typeof (ICoPaymentFrecuencyDomainService), typeof (CoPaymentFrecuencyDomainServices)},
                {typeof (IPlanRateDomainService), typeof (PlanRateDomainServices)},
                {typeof (IAssignServiceDomainService), typeof (AssignServiceDomainServices)},
                {typeof (IAssignServiceDetailDomainService), typeof (AssignServiceDetailDomainServices)},
                {typeof (IAssignServiceSupplyDomainService), typeof (AssignServiceSupplyDomainServices)},
                {typeof (IPlanEntityDomainService), typeof (PlanEntityDomainServices)},
                {typeof (INoticeDomainService), typeof (NoticeDomainServices)},
                {typeof (IProfessionalAssignedDomainService), typeof (ProfessionalAssignedDomainService)},
                {typeof (ICopaymentDomainService), typeof (CopaymentDomainService)},
                {typeof (IRipsDomainService), typeof (RipsDomainService)},
                {typeof (IRipsGenerator), typeof (RipsGenerator)},
                {typeof (IExcelReportService), typeof (ExcelReportService)},
                {typeof (ISpecialReportService), typeof (SpecialReportService)},
                {typeof (IPaymentReportService), typeof (PaymentReportService)},
                {typeof (ICopaymentReportService), typeof (CopaymentReportService)},
                {typeof (IMailService), typeof (MailService)},
                {typeof (ILockDateDomainService), typeof (LockDateDomainService)}

            };
            return dic;
        }
    }
}
