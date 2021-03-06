﻿namespace Adom.Hhm.Data.Querys
{
    public class PaymentReportQuerys
    {
        public static string GetPaymentReport =
            @"SELECT	    Asd.[ProfessionalId]
		                ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
		                ,Pro.Document ProfessionalDocument
		                ,UPPER(Typ.Description) ServiceType
		                ,Ser.Name ServiceName
		                ,FORMAT(Asd.DateVisit, 'dd-MM-yyyy HH:mm:ss') InitialDate
		                ,UPPER(CASE DATEPART(dw,CONVERT(DATETIME,Asd.DateVisit,120)) 
			                WHEN 2 THEN 'LUNES' 
			                WHEN 3 THEN 'MARTES' 
			                WHEN 4 THEN 'MIERCOLES' 
			                WHEN 5 THEN 'JUEVES' 
			                WHEN 6 THEN 'VIERNES' 
			                WHEN 7 THEN 'SABADO' 
			                WHEN 1 THEN 'DOMINGO' 
			                ELSE '' END ) DayOfWeek
                        ,'NO' IsHoliday
		                ,ser.Value AS Rate
		                ,CASE PaymentType WHEN 1 THEN 'EFECTIVO' WHEN 2 THEN 'PIN' WHEN 3 THEN 'OTRO' ELSE NULL END PaymentType
                        ,asd.Pin
		                ,asd.ReceivedAmount
		                ,asd.OtherAmount		                
		                ,(ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		                ,doc.Name PatientDocumentType
		                ,pat.Document PatientDocument
		                ,ent.Name EntityName
		                ,pl.Name PlanName
                        ,FORMAT(Ags.RecordDate,'dd-MM-yyyy HH:mm:ss') RequestDate
		                ,Ser.HoursToInvest
                        ,CASE Asd.[Verified] WHEN 1 THEN 'SI' ELSE 'NO' END Verified		                
                        ,(ISNULL(cal.FirstName,'') + ' ' + ISNULL(cal.SecondName, '') + ' ' + ISNULL(cal.Surname, '') + ' ' + ISNULL(cal.SecondSurname, '')) AS VerifiedBy  
                        ,CASE WHEN Asd.[VerificationDate] IS NULL THEN '' ELSE CONVERT(VARCHAR(30), Asd.[VerificationDate], 121) END AS [VerificationDate]		                
            FROM [sas].[AssignServiceDetails] Asd
            INNER JOIN [sas].[AssignService] Ags ON Asd.AssignServiceId = Ags.AssignServiceId
            LEFT JOIN [cfg].[Professionals] Pro ON Pro.ProfessionalId = Asd.ProfessionalId
            LEFT JOIN [sec].[Users] usr ON usr.UserId = Pro.UserId
            LEFT JOIN [sec].[Users] cal ON cal.UserId = Asd.VerifiedBy
            INNER JOIN [cfg].[Services] Ser ON Ser.ServiceId = Ags.ServiceId
            INNER JOIN [cfg].[Entities] ent ON ent.EntityId = Ags.EntityId
            INNER JOIN [cfg].[PlansEntity] pl ON pl.PlanEntityId =  Ags.PlanEntityId
            INNER JOIN [cfg].[PlansRates] pr ON pr.PlanEntityId = pl.PlanEntityId AND pr.ServiceId = Ags.ServiceId 
            INNER JOIN [cfg].[ServiceType] Typ ON Ser.ServiceTypeId = Typ.Id
            INNER JOIN [cfg].[ServiceFrecuency] sef ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
            INNER JOIN [cfg].[CoPaymentFrecuency] cpf ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
            INNER JOIN [sas].[StateAssignService] sta ON sta.Id = Ags.StateId
            INNER JOIN [cfg].[PlansEntity] pe ON pe.PlanEntityId = Ags.PlanEntityId
            INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId
            INNER JOIN [cfg].[DocumentType] doc ON doc.Id = pat.DocumentTypeId
            WHERE Asd.StateId = 2 AND Asd.ProfessionalId NOT IN (-1, 0) ";
    }
}
