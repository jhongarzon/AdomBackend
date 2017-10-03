using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public class CopaymentReportQuerys
    {
        public static string GetCopaymentReport =
            @"SELECT 	(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
		        ,pro.Document
		        ,Ser.Name as ServiceName
		        ,CONVERT(char(10), Ags.[InitialDate],105) AS InitialDate
		        ,CONVERT(char(10), Ags.[FinalDate],105) AS FinalDate
		        ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
		        ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3))  QuantityProgrammed
		        ,sta.Name AS StateName
		        ,Ags.CoPaymentAmount
                ,cpf.Name CopaymentFrecuency
		        ,pr.Rate
		        ,CASE Ags.CopaymentStatus WHEN 0 THEN 'SE' ELSE 'E' END CopaymentStatus
		        ,(SELECT SUM(Asd.ReceivedAmount) FROM [sas].[AssignServiceDetails] asd WHERE asd.AssignServiceId = Ags.AssignServiceId) ReportedAmount
		        ,(SELECT SUM(Asd.OtherAmount) FROM [sas].[AssignServiceDetails] asd WHERE asd.AssignServiceId = Ags.AssignServiceId) OtherAmount		        
		        ,0 TotalReceivedVerified--Efectivo Recibido (Verificado)
		        ,Ags.DeliveredCopayments --Efectivo Entregado
		        ,0 OtherReceived--Otros recibidos
                ,0 OtherDelivered--Otros recibidos
		        ,Ags.Discounts
		        ,Ser.Value ValueToPayToProfessional
		        ,'Recicido Por'  ReceivedBy
		        ,CONVERT(VARCHAR(10),GETDATE(),120) ReceivedDateTime
		        ,CONCAT(pat.[FirstName],' ', pat.Surname) PatientName
		        ,doc.Name PatientDocumentType
		        ,pat.[Document] PatientDocument
		        ,ent.[Name] AS EntityName                 
		        ,pe.[Name] AS PlanEntityName
		        ,Ags.RecordDate
        FROM	    [sas].[AssignService] Ags
        INNER JOIN  [cfg].[Professionals] Pro ON Ags.ProfessionalId = Pro.ProfessionalId
        INNER JOIN [cfg].[PlansEntity] pl ON pl.PlanEntityId =  Ags.PlanEntityId
        INNER JOIN [cfg].[PlansRates] pr ON pr.PlanEntityId = pl.PlanEntityId AND pr.ServiceId = Ags.ServiceId 
        INNER JOIN  [sec].[Users] usr ON usr.UserId = Pro.UserId
        INNER JOIN  [cfg].[Services] Ser  ON Ser.ServiceId = Ags.ServiceId
        INNER JOIN [cfg].[ServiceFrecuency] sef ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
        INNER JOIN [cfg].[CoPaymentFrecuency] cpf ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
        INNER JOIN [sas].[StateAssignService] sta ON sta.Id = Ags.StateId
        INNER JOIN [cfg].[Entities] ent ON ent.EntityId = Ags.EntityId
        INNER JOIN [cfg].[PlansEntity] pe ON pe.PlanEntityId = Ags.PlanEntityId
        INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId 
        INNER JOIN [cfg].[DocumentType] doc ON Pat.DocumentTypeId = doc.Id 
        WHERE Ags.[InitialDate] > CONVERT(DATE,ISNULL(@InitialDateIni,'01-01-2000'), 105)
		AND Ags.[InitialDate] < CONVERT(DATE,ISNULL(@InitialDateEnd,GETDATE() + 100),105)
		AND Ags.[FinalDate] > CONVERT(DATE,ISNULL(@FinalDateIni,'01-01-2000'), 105)
		AND Ags.[FinalDate] < CONVERT(DATE,ISNULL(@FinalDateEnd,GETDATE() + 100),105)
		AND Ags.[RecordDate] > CONVERT(DATE,ISNULL(@DeliverDateIni,'01-01-2000'), 105)
		AND Ags.[RecordDate] < CONVERT(DATE,ISNULL(@DeliverDateEnd,GETDATE() + 100),105) ";
    }
}
