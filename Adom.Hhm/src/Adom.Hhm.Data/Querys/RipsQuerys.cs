namespace Adom.Hhm.Data.Querys
{
    public class RipsQuerys
    {
        public static string GetServiceRips =
            @"SELECT Ags.[AssignServiceId]
                    ,Ags.[PatientId]					
				    ,doc.Name DocumentTypeName
                    ,doc.Abbreviation DocumentTypeAbbreviation
				    ,pat.[Document] PatientDocument
				    ,pat.FirstName
				    ,ISNULL(pat.SecondName,'') SecondName
				    ,pat.Surname
				    ,ISNULL(pat.SecondSurname,'') SecondSurname					
		            ,CONCAT(pat.[FirstName],' ', pat.Surname) PatientName		            
				    ,'1' RipsUserType
				    ,ISNULL([dbo].[CALCULATE_AGE] (pat.BirthDate, 1), pat.Age) Age
				    ,ISNULL([dbo].[CALCULATE_AGE] (pat.BirthDate, 1),pat.UnitTimeId) AgeUnit
				    ,CASE pat.GenderId WHEN 1 THEN 'M' WHEN 2 THEN 'F' ELSE '' END AS Gender
				    ,(SELECT TOP (1) [ProviderCode] FROM [AdomServices].[cfg].[AdomInfo]) ProviderCode
				    ,(SELECT TOP (1) [BusinessName] FROM [AdomServices].[cfg].[AdomInfo]) BusinessName
				    ,(SELECT TOP (1) [IdentificationType] FROM [AdomServices].[cfg].[AdomInfo]) AdomIdentificationType
				    ,(SELECT TOP (1) [IdentificationNumber] FROM [AdomServices].[cfg].[AdomInfo]) AdomIdentificationNumber
				    ,(SELECT TOP (1) [DepartmentCode] FROM [AdomServices].[cfg].[AdomInfo]) DepartmentCode
				    ,(SELECT TOP (1) [CityCode] FROM [AdomServices].[cfg].[AdomInfo]) CityCode
				    ,(SELECT TOP (1) [ResidenceArea] FROM [AdomServices].[cfg].[AdomInfo]) ResidenceArea
				    ,ent.[Code] EntityCode
                    ,ent.[Name] AS EntityName
				    ,pe.[Name] AS PlanEntityName
				    ,Ser.Name as ServiceName
				    ,Ser.Code as Cups
				    ,sef.Name as ServiceFrecuencyName
				    ,sta.Name AS StateName					
				    ,Ser.Value ValueToPayToProfessional
				    ,pr.Rate
                    ,Ags.[AuthorizationNumber]
                    ,Ags.[ContractNumber]
                    ,Ags.[EntityId]
				    ,Ags.[ServiceId]
                    ,Ags.[PlanEntityId]                    
                    ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3))  Quantity
                    ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
                    ,CONVERT(char(10), Ags.[InitialDate],126) AS InitialDate
                    ,CONVERT(char(10), Ags.[FinalDate],126) AS FinalDate
                    ,Ags.[ServiceFrecuencyId]		            
                    ,Ags.[ProfessionalId]
		            ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                    ,Ags.[CoPaymentAmount]
                    ,Ags.[CoPaymentFrecuencyId]
		            ,cpf.Name AS CoPaymentFrecuencyName
                    ,Ags.[StateId]	            
                    ,CASE Ags.CopaymentStatus WHEN 0 THEN 'SE' ELSE 'E' END CopaymentStatus
                    ,(select sum(det.ReceivedAmount) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId)  TotalCopaymentReported
		            ,(select sum(det.OtherAmount) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId)  OtherValuesReported                    
                    ,Ags.[TotalCopaymentReceived]
                    ,Ags.[OtherValuesReceived]
                    ,Ags.[OtherValuesReceived]
                    ,Ags.[DeliveredCopayments]
				    ,Ags.Cie10
				    ,Ags.Consultation			
				    ,Ags.[External]
                    ,Ags.[InvoiceNumber]
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
		    INNER JOIN [cfg].[Patients] pat 
		    ON Ags.PatientId = pat.PatientId 
		    INNER JOIN [cfg].[DocumentType] doc
		    ON doc.Id = pat.DocumentTypeId
		    LEFT JOIN [cfg].[PlansRates] pr 
		    ON pr.PlanEntityId = Ags.PlanEntityId AND pr.ServiceId = Ags.ServiceId ";

        public static string GetServiceSupplies =
            @"SELECT    [AssignServiceSupplyId]
                        ,[AssignServiceId]
                        ,asp.[SupplyId]
                        ,sup.Code SupplyCode
                        ,sup.Name SupplyName
                        ,[Quantity]
                        ,[BilledToId]
                        ,[Observation]
                        FROM [AdomServices].[sas].[AssignServiceSupply] asp
            INNER JOIN cfg.[Supplies] sup ON asp.[SupplyId] = sup.SupplyId
            WHERE AssignServiceId = @assignServiceId";

        public static string InsertGeneratedRips =
            @"INSERT INTO [sas].[GeneratedRips]
                   ([InvoiceNumber],[RecordDate])
             VALUES (@invoiceNumber,GETDATE())
                SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string UpdateServiceInvoice =
            @"UPDATE [sas].[AssignService]
                SET [InvoiceNumber] = @invoiceNumber
              WHERE AssignServiceId = @assignServiceId";
    }
}
