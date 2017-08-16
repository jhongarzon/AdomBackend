﻿namespace Adom.Hhm.Data.Querys
{
    public class PaymentReportQuerys
    {
        public static string GetPaymentReport =
            @"SELECT	    Asd.[ProfessionalId]
		                ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
		                ,Pro.Document ProfessionalDocument
		                ,UPPER(Typ.Description) ServiceType
		                ,Ser.Name ServiceName
		                ,CONVERT(VARCHAR,Ags.InitialDate, 120) InitialDate
		                ,UPPER(CASE DATEPART(dw,CONVERT(DATETIME,Ags.InitialDate,120)) 
			                WHEN 2 THEN 'Lunes' 
			                WHEN 3 THEN 'Martes' 
			                WHEN 4 THEN 'Miercoles' 
			                WHEN 5 THEN 'Jueves' 
			                WHEN 6 THEN 'Viernes' 
			                WHEN 7 THEN 'Sabado' 
			                WHEN 1 THEN 'Domingo' 
			                ELSE '' END ) DayOfWeek
                        ,'NO' IsHoliday
		                ,pr.Rate
		                ,CASE PaymentType WHEN 1 THEN 'Efectivo' WHEN 2 THEN 'PIN' WHEN 3 THEN 'OTRO' ELSE NULL END PaymentType
                        ,asd.Pin
		                ,asd.ReceivedAmount
		                ,asd.OtherAmount		                
		                ,(ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		                ,doc.Name PatientDocumentType
		                ,pat.Document PatientDocument
		                ,ent.Name EntityName
		                ,pl.Name PlanName
		                ,Ser.HoursToInvest
		                --Verificado SI/NO
		                --Verificado Por 
		                --Fecha Verificado
            FROM [sas].[AssignServiceDetails] Asd
            INNER JOIN [sas].[AssignService] Ags ON Asd.AssignServiceId = Ags.AssignServiceId
            LEFT JOIN [cfg].[Professionals] Pro ON Pro.ProfessionalId = Asd.ProfessionalId
            LEFT JOIN [sec].[Users] usr ON usr.UserId = Pro.UserId
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
            WHERE Asd.StateId = 3 AND Asd.ProfessionalId NOT IN (-1, 0)
            ORDER BY    Asd.AssignServiceDetailId DESC";
    }
}
