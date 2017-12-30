namespace Adom.Hhm.Data.Querys
{
    public class HomeQuerys
    {
        public static string GetNursingServiceReport =
           @"[sas].[GetChartData]";

        public static string GetTherapyServiceReport =
            @"[sas].[GetChartData]";

        public static string GetPatientsWithoutProfessional =
            @"SELECT	(ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.Surname, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		                ,pat.PatientId PatientId,ags.ServiceId, ser.Name ServiceName,ags.AssignServiceId
                FROM [sas].[AssignService] ags 
                INNER JOIN [sas].[AssignServiceDetails] asd ON ags.AssignServiceId = asd.AssignServiceId
                INNER JOIN [cfg].[Patients] pat ON ags.PatientId = pat.PatientId
                INNER JOIN [cfg].[Services] ser ON ags.ServiceId= ser.ServiceId
                WHERE asd.ProfessionalId = -1 ";


        public static string GetIrregularServices =
             @"[sas].[GetIrregularServices]";

        public static string GetProfessionalCopayments =
            @"SELECT	(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + 
		                ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName,
		                a.ReceivedAmount	
                 FROM 
                (	SELECT asd.[ProfessionalId],SUM([ReceivedAmount]) ReceivedAmount
	                FROM [sas].[AssignServiceDetails] asd
	                INNER JOIN [sas].AssignService ags ON ags.AssignServiceId = asd.AssignServiceId
	                WHERE PaymentType = 1 AND asd.professionalId <> -1 AND CopaymentStatus = 0
	                GROUP BY asd.ProfessionalId) a 
                INNER JOIN [cfg].[Professionals] prof ON prof.ProfessionalId = a.ProfessionalId
                INNER JOIN [sec].[Users] usr ON usr.UserId = prof.UserId
                WHERE ReceivedAmount > 200000 ";

    }
}
