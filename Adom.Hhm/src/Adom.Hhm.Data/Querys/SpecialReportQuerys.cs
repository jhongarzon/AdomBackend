namespace Adom.Hhm.Data.Querys
{
    public class SpecialReportQuerys
    {
        public static string GetSummaryReport =
        @"   SELECT	Ags.[AssignServiceId]
                    ,(ISNULL(pat.FirstName,'') + ' ' + ISNULL(pat.SecondName, '') + ' ' + ISNULL(pat.Surname, '') + ' ' + ISNULL(pat.SecondSurname, '')) AS PatientName
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
                    ,CONVERT(char(10), Ags.[InitialDate],105) AS InitialDate
                    ,CONVERT(char(10), Ags.[FinalDate],105) AS FinalDate
                    ,(SELECT MAX(DateVisit) FROM [sas].AssignServiceDetails where AssignServiceId = Ags.AssignServiceId) RealInitialDate
					,(SELECT MIN(DateVisit) FROM [sas].AssignServiceDetails where AssignServiceId = Ags.AssignServiceId) RealFinalDate
		            ,Ags.Cie10	
		            ,Ags.DescriptionCie10
		            ,pt.Name PatientType			  
		            ,CONCAT(pat.Age, ' ', ut.Name) Age
		            ,pat.BirthDate PatientBirthday
		            ,gen.Name PatientGender 
		            ,pat.Telephone1 PatientPhone1
		            ,pat.Telephone2 PatientPhone2
		            ,pat.Address PatientAddress
		            ,pat.Email PatientEmail
                    ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS AssignedBy
            FROM	    [sas].[AssignService] Ags
            INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId
            INNER JOIN [cfg].[UnitTime] ut ON ut.Id= pat.UnitTimeId
            INNER JOIN [Cfg].[PatientType] pt ON pat.PatientTypeId = pt.Id
            INNER JOIN [cfg].[Gender] gen ON pat.GenderId = gen.Id
            INNER JOIN [cfg].[DocumentType] doc ON doc.Id = pat.DocumentTypeId
            INNER JOIN [cfg].[Services] Ser ON Ser.ServiceId = Ags.ServiceId
            INNER JOIN [cfg].[ServiceFrecuency] sef ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
            INNER JOIN [cfg].[CoPaymentFrecuency] cpf ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
            INNER JOIN [sas].[StateAssignService] sta ON sta.Id = Ags.StateId
            INNER JOIN [cfg].[Entities] ent ON ent.EntityId = Ags.EntityId
            INNER JOIN [cfg].[PlansEntity] pe ON pe.PlanEntityId = Ags.PlanEntityId
            INNER JOIN [cfg].[PlansRates] pr ON pr.PlanEntityId = Ags.PlanEntityId AND pr.ServiceId = Ags.ServiceId
            INNER JOIN [sec].[Users] usr ON usr.UserId = Ags.AssignedBy
			WHERE Ags.[InitialDate] > CONVERT(DATE,ISNULL(@InitialDateIni,'01-01-2000'), 105)
			AND Ags.[InitialDate] < CONVERT(DATE,ISNULL(@InitialDateEnd,GETDATE() + 100),105)
			AND EXISTS(SELECT 1 FROM [sas].[AssignServiceDetails] WHERE DateVisit > CONVERT(DATE,ISNULL(@VisitDateIni,'01-01-2000'), 105)) 
			AND EXISTS(SELECT 1 FROM [sas].[AssignServiceDetails] WHERE DateVisit < CONVERT(DATE,ISNULL(@VisitDateEnd,GETDATE() + 100),105))
			AND EXISTS(SELECT 1 FROM [sas].[AssignServiceDetails] WHERE RecordDate > CONVERT(DATE,ISNULL(@RequestDateIni,'01-01-2000'), 105)) 
			AND EXISTS(SELECT 1 FROM [sas].[AssignServiceDetails] WHERE RecordDate < CONVERT(DATE,ISNULL(@RequestDateEnd,GETDATE() + 100),105)) ";

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
			,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
		    ,Pro.Document ProfessionalDocument
			,Ser.HoursToInvest            
            ,CASE WHEN Asd.QualityCallDate IS NULL THEN '' ELSE CONVERT(VARCHAR(30), Asd.QualityCallDate, 121) END AS QualityCallDate
            ,(ISNULL(qua.FirstName,'') + ' ' + ISNULL(qua.SecondName, '') + ' ' + ISNULL(qua.Surname, '') + ' ' + ISNULL(qua.SecondSurname, '')) AS QualityCallUser 
            ,Asd.[Observation]
            ,CASE Asd.[Verified] WHEN 1 THEN 'SI' ELSE 'NO' END Verified
            ,CASE WHEN Asd.[VerificationDate] IS NULL THEN '' ELSE CONVERT(VARCHAR(30), Asd.[VerificationDate], 121) END AS [VerificationDate]
            ,(ISNULL(cal.FirstName,'') + ' ' + ISNULL(cal.SecondName, '') + ' ' + ISNULL(cal.Surname, '') + ' ' + ISNULL(cal.SecondSurname, '')) AS VerifiedBy  
            FROM [sas].[AssignServiceDetails] Asd
            INNER JOIN [sas].[AssignService] Ags ON Asd.AssignServiceId = Ags.AssignServiceId            
            INNER JOIN [cfg].[Services] Ser ON Ser.ServiceId = Ags.ServiceId
            INNER JOIN [cfg].[Entities] ent ON ent.EntityId = Ags.EntityId
            INNER JOIN [cfg].[PlansEntity] pl ON pl.PlanEntityId =  Ags.PlanEntityId
            INNER JOIN [cfg].[ServiceFrecuency] sef ON sef.ServiceFrecuencyId = Ags.ServiceFrecuencyId
            INNER JOIN [cfg].[CoPaymentFrecuency] cpf ON cpf.CoPaymentFrecuencyId = Ags.CoPaymentFrecuencyId
            INNER JOIN [sas].[StateAssignService] sta ON sta.Id = Ags.StateId
            INNER JOIN [cfg].[PlansEntity] pe ON pe.PlanEntityId = Ags.PlanEntityId
            INNER JOIN [cfg].[Patients] pat ON Ags.PatientId = pat.PatientId
            INNER JOIN [cfg].[DocumentType] doc ON doc.Id = pat.DocumentTypeId
            LEFT JOIN [cfg].[Professionals] Pro ON Pro.ProfessionalId = Asd.ProfessionalId
            LEFT JOIN [sec].[Users] usr ON usr.UserId = Pro.UserId
            LEFT JOIN [sec].[Users] cal ON cal.UserId = Asd.VerifiedBy
            LEFT JOIN [sec].[Users] qua ON qua.UserId = Asd.QualityCallUser
            WHERE Asd.ProfessionalId NOT IN (-1, 0)
			AND Ags.[InitialDate] > CONVERT(DATE,ISNULL(@InitialDateIni,'01-01-2000'), 105)
			AND Ags.[InitialDate] < CONVERT(DATE,ISNULL(@InitialDateEnd,GETDATE() + 100),105)
			AND Asd.[DateVisit] > CONVERT(DATE,ISNULL(@VisitDateIni,'01-01-2000'), 105) 
			AND Asd.[DateVisit] < CONVERT(DATE,ISNULL(@VisitDateEnd,GETDATE() + 100),105)
			AND Asd.[RecordDate] > CONVERT(DATE,ISNULL(@RequestDateIni,'01-01-2000'), 105) 
			AND Asd.[RecordDate] < CONVERT(DATE	,ISNULL(@RequestDateEnd,GETDATE() + 100),105)";
            

        public static string GetAssignedProfessionals =
            @"SELECT pro.[Document] DocumentNumber,  (ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
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
                  FROM [sas].[DetailAnswers]
                  WHERE AssignServiceDetailId = @AssignServiceDetailId";
    }
}
