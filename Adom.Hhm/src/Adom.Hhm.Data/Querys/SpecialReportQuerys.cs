namespace Adom.Hhm.Data.Querys
{
    public class SpecialReportQuerys
    {
        public static string GetSummaryReport =
        @"   SELECT	Ags.[AssignServiceId]
                    ,(ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		            ,doc.Name PatientDocumentType
		            ,pat.Document PatientDocument
		            ,ent.Name EntityName
		            ,pe.Name PlanEntityName
		            ,Ags.[AuthorizationNumber]
                    ,Ags.[ContractNumber]
                    ,Ser.Name as ServiceName
		            ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3)) AS ProgrammedSessions
                    ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as CompletedSessions
		            ,sef.Name as ServiceFrecuency
		            ,sta.Name AS ServiceStatus
		            ,pr.Rate
		            ,Ags.CoPaymentAmount
		            ,cpf.Name CopaymentFrecuency
		            ,CASE Ags.CopaymentStatus WHEN 0 THEN 'ENTREGADO' ELSE 'SIN ENTREGAR' END CopaymentStatus
		            ,Ags.RecordDate RequestDate
                    ,CONVERT(char(10), Ags.[InitialDate],126) AS InitialDate
                    ,CONVERT(char(10), Ags.[FinalDate],126) AS FinalDate
		            ,Ags.Cie10	
		            ,Ags.DescriptionCie10
		            ,pt.Name PatientType			  
		            ,pat.Age
		            ,pat.BirthDate PatientBirthday
		            ,gen.Name PatientGender 
		            ,pat.Telephone1 PatientPhone1
		            ,pat.Telephone2 PatientPhone2
		            ,pat.Address PatientAddress
		            ,pat.Email PatientEmail
            FROM	    [sas].[AssignService] Ags
            INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId
            INNER JOIN [Cfg].[PatientType] pt ON pat.PatientTypeId = pt.Id
            INNER JOIN [cfg].[Gender] gen ON pat.GenderId = gen.Id
            INNER JOIN [cfg].[DocumentType] doc ON doc.Id = pat.DocumentTypeId
            INNER JOIN [cfg].[Services] Ser ON Ser.ServiceId = Ags.ServiceId
            INNER JOIN [cfg].[ServiceFrecuency] sef ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
            INNER JOIN [cfg].[CoPaymentFrecuency] cpf ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
            INNER JOIN [sas].[StateAssignService] sta ON sta.Id = Ags.StateId
            INNER JOIN [cfg].[Entities] ent ON ent.EntityId = Ags.EntityId
            INNER JOIN [cfg].[PlansEntity] pe ON pe.PlanEntityId = Ags.PlanEntityId
            INNER JOIN [cfg].[PlansRates] pr ON pr.PlanEntityId = Ags.PlanEntityId AND pr.ServiceId = Ags.ServiceId";

        public static string GetDetailedReport =
            @"SELECT	  AssignServiceDetailId
            ,(ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
		    ,doc.Name PatientDocumentType
		    ,pat.Document PatientDocument
			,ent.Name EntityName
		    ,pl.Name PlanName
			,Ags.AuthorizationNumber
			,Ags.ContractNumber
			,Ser.Name ServiceName
			,Sef.Name ServiceFrecuency
			,Ags.Cie10
			,Sta.Name VisitStatus
			,Ags.RecordDate RequestDate
			,Asd.DateVisit
			,cpf.Name CopaymentFrecuency
			,Asd.ReceivedAmount
			,Asd.Pin
			,Asd.OtherAmount
			,Asd.RecordDate
			,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
		    ,Pro.Document ProfessionalDocument
			,Ser.HoursToInvest
		    ---Aca va todo lo de llamada de calidad
            FROM [sas].[AssignServiceDetails] Asd
            INNER JOIN [sas].[AssignService] Ags ON Asd.AssignServiceId = Ags.AssignServiceId
            LEFT JOIN [cfg].[Professionals] Pro ON Pro.ProfessionalId = Asd.ProfessionalId
            LEFT JOIN [sec].[Users] usr ON usr.UserId = Pro.UserId
            INNER JOIN [cfg].[Services] Ser ON Ser.ServiceId = Ags.ServiceId
            INNER JOIN [cfg].[Entities] ent ON ent.EntityId = Ags.EntityId
            INNER JOIN [cfg].[PlansEntity] pl ON pl.PlanEntityId =  Ags.PlanEntityId
            INNER JOIN [cfg].[ServiceFrecuency] sef ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
            INNER JOIN [cfg].[CoPaymentFrecuency] cpf ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
            INNER JOIN [sas].[StateAssignService] sta ON sta.Id = Ags.StateId
            INNER JOIN [cfg].[PlansEntity] pe ON pe.PlanEntityId = Ags.PlanEntityId
            INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId
            INNER JOIN [cfg].[DocumentType] doc ON doc.Id = pat.DocumentTypeId
            WHERE Asd.ProfessionalId NOT IN (-1, 0)
            ORDER BY    Asd.AssignServiceDetailId DESC";

        public static string GetAssignedProfessionals =
            @"SELECT pro.[Document] DocumentNumber,  (ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
			    FROM [cfg].[Professionals] pro
			    INNER JOIN  [sec].[Users] usr
                ON usr.UserId = Pro.UserId
			    WHERE ProfessionalId IN(
				    (	
					    SELECT DISTINCT(ProfessionalId)
					    FROM   [sas].[AssignServiceDetails]
					    WHERE  AssignServiceId = @AssignServiceId
				    )				
			    )";

        public static string GetQualityQuestions =
            @"SELECT   [DetailAnswerId]
                      ,[AnswerId]
                      ,[QuestionId]
                      ,[AssignServiceDetailId]
                      ,[RecordDate]
                  FROM [AdomServices].[sas].[DetailAnswers]
                  WHERE AssignServiceDetailId = @AssignServiceDetailId";
    }
}
