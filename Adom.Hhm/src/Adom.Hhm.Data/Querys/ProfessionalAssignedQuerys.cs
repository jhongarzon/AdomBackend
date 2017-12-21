namespace Adom.Hhm.Data.Querys
{
    public class ProfessionalAssignedQuerys
    {
        public static string GetByProfessionalId =
        @"  SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
				  ,CONCAT(pat.[FirstName],' ', pat.Surname) PatientName
				  ,pat.[Document] PatientDocument
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[ContractNumber]
                  ,Ags.[EntityId]
                  ,ent.[Name] AS EntityName
                  ,Ags.[PlanEntityId]
                  ,pe.[Name] AS PlanEntityName
                  ,Ags.[Cie10]
                  ,Ags.[DescriptionCie10]
                  ,CONVERT(char(10), Ags.[Validity],126) AS Validity
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId and det.ProfessionalId <> @ProfessionalId))  Quantity
                  ,(SELECT count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2 and det.ProfessionalId = @ProfessionalId) as QuantityCompleted                  
                  ,CONVERT(char(10), Ags.[InitialDate],126) AS InitialDate
                  ,CONVERT(char(10), Ags.[FinalDate],126) AS FinalDate
                  ,Ags.[ServiceFrecuencyId]
				  ,sef.Name as ServiceFrecuencyName
                  ,Ags.[ProfessionalId]
				  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                  ,Ags.[CoPaymentAmount]
                  ,Ags.[CoPaymentFrecuencyId]
				  ,cpf.Name AS CoPaymentFrecuencyName
                  ,Ags.[Consultation]
                  ,Ags.[External]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
                  ,Ags.Observation
                  ,(select sum(det.ReceivedAmount) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId)  TotalReceived
				  ,Count(*) Over() AS TotalRows
                  ,CONVERT(char(10), Ags.[RecordDate],126) AS RecordDate
                  
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
			WHERE AssignServiceId IN(	SELECT DISTINCT([AssignServiceId]) 
										FROM [sas].[AssignServiceDetails]
										WHERE professionalId=  @ProfessionalId AND StateId = @StatusId)
			AND Ags.StateId = @StatusId 
			ORDER BY    Ags.StateId ASC, Ags.[InitialDate] DESC";
    }
}
