using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public class CopaymentQuerys
    {
        public static string GetCopayment =
            @" SELECT Ags.[AssignServiceId]
                    ,Ags.[PatientId]
		            ,CONCAT(pat.[FirstName],' ', pat.Surname) PatientName
		            ,pat.[Document] PatientDocument
                    ,Ags.[AuthorizationNumber]
                    ,Ags.[ContractNumber]
                    ,Ags.[EntityId]
                    ,ent.[Name] AS EntityName
                    ,Ags.[PlanEntityId]
                    ,pe.[Name] AS PlanEntityName
                    ,Ags.[ServiceId]
		            ,Ser.Name as ServiceName
                    ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3))  Quantity
                    ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
                    ,CONVERT(char(10), Ags.[InitialDate],126) AS InitialDate
                    ,CONVERT(char(10), Ags.[FinalDate],126) AS FinalDate
                    ,Ags.[ServiceFrecuencyId]
		            ,sef.Name as ServiceFrecuencyName
                    ,Ags.[ProfessionalId]
		            ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                    ,Ags.[CoPaymentAmount]
                    ,Ags.[CoPaymentFrecuencyId]
		            ,cpf.Name AS CoPaymentFrecuencyName
                    ,Ags.[External]
                    ,Ags.[StateId]
		            ,sta.Name AS StateName
                    ,CASE Ags.CopaymentStatus WHEN 0 THEN 'SE' ELSE 'E' END CopaymentStatus
                    ,(select sum(det.ReceivedAmount) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId)  TotalCopaymentReported
		            ,(select sum(det.OtherAmount) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId)  OtherValuesReported
                    ,Ser.Value ValueToPayToProfessional
                    ,Ags.[TotalCopaymentReceived]
                    ,Ags.[OtherValuesReceived]
                    ,Ags.[OtherValuesReceived]
                    ,Ags.[DeliveredCopayments]
		            ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignService] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
            INNER JOIN  [cfg].[Services] Ser
            ON Ser.ServiceId = Ags.ServiceId
			INNER JOIN [cfg].[ServiceFrecuency] sef
            ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
			INNER JOIN [cfg].[CoPaymentFrecuency] cpf
            ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            INNER JOIN [cfg].[Entities] ent
            ON ent.EntityId = Ags.EntityId
            INNER JOIN [cfg].[PlansEntity] pe
            ON pe.PlanEntityId = Ags.PlanEntityId
			INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId 
			WHERE pro.ProfessionalId =  @ProfessionalId AND Ags.StateId = @ServiceStatusId
            ORDER BY    Ags.StateId ASC, Ags.[InitialDate] DESC";

        public static string UpdateCopayment =
            @"UPDATE [sas].[AssignService]
                    SET  [CopaymentStatus] = 1
                        ,[TotalCopaymentReceived] = @TotalCopaymentReceived
                        ,[OtherValuesReceived] = @OtherValuesReceived
                        ,[DeliveredCopayments] = @DeliveredCopayments
                        ,[Discounts] = @Discounts
                    WHERE [AssignServiceId] = @AssignServiceId";
    }
}
