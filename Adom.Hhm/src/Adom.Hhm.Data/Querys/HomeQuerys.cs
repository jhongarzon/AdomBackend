namespace Adom.Hhm.Data.Querys
{
    public class HomeQuerys
    {
        public static string GetNursingServiceReport =
            @"SELECT COUNT([asd].[StateId]) Amount,[sas].[Name]
                FROM [sas].[AssignServiceDetails] asd
                INNER JOIN [sas].[StateAssignService] sas ON asd.StateId = sas.Id
                INNER JOIN [sas].[AssignService] ags ON ags.AssignServiceId = asd.AssignServiceId
                INNER JOIN [cfg].[Services] ser ON ser.ServiceId = ags.ServiceId
                WHERE [asd].StateId != 3 AND ser.ServiceTypeId = 2
                GROUP BY [asd].StateId,[sas].[Name]";

        public static string GetTherapyServiceReport =
            @"SELECT COUNT([asd].[StateId]) Amount,[sas].[Name]
                FROM [sas].[AssignServiceDetails] asd
                INNER JOIN [sas].[StateAssignService] sas ON asd.StateId = sas.Id
                INNER JOIN [sas].[AssignService] ags ON ags.AssignServiceId = asd.AssignServiceId
                INNER JOIN [cfg].[Services] ser ON ser.ServiceId = ags.ServiceId
                WHERE ser.ServiceTypeId = 3
                GROUP BY [asd].StateId,[sas].[Name]";

        public static string GetPatientsWithoutProfessional =
            @"SELECT (ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.Surname, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		                ,pat.Document PatientDocument,ags.ServiceId, ser.Name ServiceName
                  FROM [AdomServices].[sas].[AssignService] ags 
                  INNER JOIN [cfg].[Patients] pat ON ags.PatientId = pat.PatientId
                  INNER JOIN [cfg].[Services] ser ON ags.ServiceId= ser.ServiceId";


        public static string GetIrregularServices =
             @"SELECT (ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.Surname, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		                ,pat.Document PatientDocument,ags.ServiceId, ser.Name ServiceName
                  FROM [AdomServices].[sas].[AssignService] ags 
                  INNER JOIN [cfg].[Patients] pat ON ags.PatientId = pat.PatientId
                  INNER JOIN [cfg].[Services] ser ON ags.ServiceId= ser.ServiceId";

        public static string GetProfessionalCopayments =
            @"SELECT ags.ProfessionalId, (ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
		            ,ags.CoPaymentAmount
                FROM [AdomServices].[sas].[AssignService] ags 
                INNER JOIN [cfg].[Professionals] pro ON ags.ProfessionalId = pro.ProfessionalId
                INNER JOIN [sec].[Users] usr ON usr.UserId = pro.UserId";

    }
}
