namespace Adom.Hhm.Data.Querys
{
    public static class AssignServiceQuerys
    {
        public static string GetAll =
        @" SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[ContractNumber]
                  ,Ags.[EntityId]
                  ,ent.[Name] AS EntityName
                  ,Ags.[PlanEntityId]
                  ,pe.[Name] AS PlanEntityName
                  ,Ags.[Cie10]
                  ,Ags.[DescriptionCie10]
                  ,CONVERT(char(10), Ags.[Validity],105) AS Validity
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3)) AS Quantity
                  ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
                  ,CONVERT(char(10), Ags.[InitialDate],105) AS InitialDate
                  ,CONVERT(char(10), Ags.[FinalDate],105) AS FinalDate
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
                  ,(SELECT COUNT([ServicesLockDate]) 
					FROM [cfg].[AdomInfo]  
					WHERE ProviderCode = 110011114201 AND Ags.[FinalDate] < ServicesLockDate) AllowsUpdate
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
            ORDER BY    Ags.StateId ASC, Ags.[InitialDate] DESC OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @" SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[ContractNumber]
                  ,Ags.[EntityId]
                  ,ent.[Name] AS EntityName
                  ,Ags.[PlanEntityId]
                  ,pe.[Name] AS PlanEntityName
                  ,Ags.[Cie10]
                  ,Ags.[DescriptionCie10]
                  ,CONVERT(char(10), Ags.[Validity],105) AS Validity
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3) AS Quantity
                  ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
                  ,CONVERT(char(10), Ags.[InitialDate],105) AS InitialDate
                  ,CONVERT(char(10), Ags.[FinalDate],105) AS FinalDate
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
                  ,(SELECT COUNT([ServicesLockDate]) 
					FROM [cfg].[AdomInfo]  
					WHERE ProviderCode = 110011114201 AND Ags.[FinalDate] > ServicesLockDate) AllowsUpdate
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
            ORDER BY    Ags.StateId ASC, Ags.[InitialDate] DESC";

        public static string GetByPateintId =
        $@" {UpdateStatesAssignServices} ;
                SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[ContractNumber]
                  ,Ags.[EntityId]
                  ,ent.[Name] AS EntityName
                  ,Ags.[PlanEntityId]
                  ,pe.[Name] AS PlanEntityName
                  ,Ags.[Cie10]
                  ,Ags.[DescriptionCie10]
                  ,CONVERT(char(10), Ags.[Validity],105) AS Validity
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3)) AS Quantity
                  ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
                  ,CONVERT(char(10), Ags.[InitialDate],105) AS InitialDate
                  ,CONVERT(char(10), Ags.[FinalDate],105) AS FinalDate
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
                  ,(SELECT COUNT([ServicesLockDate]) 
					FROM [cfg].[AdomInfo]  
					WHERE ProviderCode = 110011114201 AND Ags.[FinalDate] > ServicesLockDate) AllowsUpdate
				  ,Count(*) Over() AS TotalRows
                  ,CONVERT(char(10), Ags.[RecordDate],105) AS RecordDate
                  ,CASE (SELECT COUNT(*) FROM sas.AssignServiceObservation where [AssignServiceId] = Ags.AssignServiceId) WHEN 0 THEN 0 ELSE 1 END HasObservations
            FROM	    [sas].[AssignService] Ags
			LEFT JOIN  [cfg].[Professionals] Pro
            ON Pro.ProfessionalId = Ags.ProfessionalId
			LEFT JOIN  [sec].[Users] usr
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
            WHERE       Ags.[PatientId] = @PatientId
            ORDER BY    Ags.StateId ASC, Ags.[InitialDate] DESC";

        public static string GetById =
        @"   SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[ContractNumber]
                  ,Ags.[EntityId]
                  ,ent.[Name] AS EntityName
                  ,Ags.[PlanEntityId]
                  ,pe.[Name] AS PlanEntityName
                  ,Ags.[Cie10]
                  ,Ags.[DescriptionCie10]
                  ,CONVERT(char(10), Ags.[Validity],105) AS Validity
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,(Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3)) as Quantity
                  ,(select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2) as QuantityCompleted
                  ,CONVERT(char(10), Ags.[InitialDate],105) AS InitialDate
                  ,CONVERT(char(10), Ags.[FinalDate],105) AS FinalDate
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
                  ,(SELECT COUNT([ServicesLockDate]) 
					FROM [cfg].[AdomInfo]  
					WHERE ProviderCode = 110011114201 AND Ags.[FinalDate] > ServicesLockDate) AllowsUpdate
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
            WHERE   [AssignServiceId] = @AssignServiceId ";

        public static string InsertServiceObservations =
       @"INSERT INTO [sas].[AssignServiceObservation]
               ([AssignServiceId]
               ,[Description]
               ,[RecordDate]
               ,[UserId])
         VALUES
               (@AssignServiceId
               ,UPPER(@Description)
               ,GETDATE()
               ,@UserId) 
        SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string CreateAssignServiceAndDetails =
        @"[sas].[CreateAssignServiceAndDetails]";

        public static string CalculateFinalDateAssignService =
        @"[sas].[CalculateFinalDateAssignService]";

        public static string Update =
        @"  UPDATE [sas].[AssignService]
               SET [AuthorizationNumber] = @AuthorizationNumber
              ,[CoPaymentAmount] = @CoPaymentAmount
              ,[CoPaymentFrecuencyId] = @CoPaymentFrecuencyId
              ,[Observation] = UPPER(@Observation)
            WHERE   [AssignServiceId] = @AssignServiceId";

        public static string UpdateStatesAssignServices =
            @" UPDATE Ags.StateId = 2
                 FROM	    [sas].[AssignService] Ags
			LEFT JOIN  [cfg].[Professionals] Pro
            ON Pro.ProfessionalId = Ags.ProfessionalId
			LEFT JOIN  [sec].[Users] usr
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
            WHERE  Ags.[PatientId] = @PatientId AND ((Ags.[Quantity] - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 3)) - (select count(det.AssignServiceDetailId) from [sas].AssignServiceDetails det WHERE det.AssignServiceId = Ags.AssignServiceId AND det.StateId = 2)) = 0
            ORDER BY    Ags.StateId ASC, Ags.[InitialDate] DESC";

        public static string GetServiceObservations =
            @"SELECT   so.[AssignServiceObservationId]
                      ,so.[AssignServiceId]
                      ,so.[Description]
                      ,FORMAT(so.[RecordDate],'yyyy-MM-dd HH:mm:ss') [RecordDate]
                      ,so.[UserId]
	                  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.Surname, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS UserName
                      ,CASE @userId  WHEN so.UserId THEN 1 ELSE usr2.IsAdmin END AS AllowDelete
                  FROM [sas].[AssignServiceObservation] so
                  INNER JOIN [sec].[Users] usr ON so.UserId = usr.UserId
                  LEFT JOIN [sec].[Users] usr2 ON usr2.UserId = @userId
                WHERE so.[AssignServiceId] = @assignServiceId ORDER BY RecordDate DESC";


        public static string DeleteObservation =
            @"DELETE FROM [sas].[AssignServiceObservation] 
                WHERE [AssignServiceObservationId] = @assignServiceObservationId";
    }
}