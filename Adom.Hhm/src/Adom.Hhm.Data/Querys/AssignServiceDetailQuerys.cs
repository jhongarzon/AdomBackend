using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class AssignServiceDetailQuerys
    {
        public static string GetAll =
        @" SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                  ,CONVERT(char(10), Ags.[DateVisit],105) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
				  ,sta.Name AS StateName
                  ,Pin
                  ,Verified
                  ,VerifiedBy
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetails] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            ORDER BY    Ags.[AssignServiceDetailId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                  ,CONVERT(char(10), Ags.[DateVisit],105) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
                  ,Pin
                  ,Verified
                  ,VerifiedBy
				  ,sta.Name AS StateName
            FROM	    [sas].[AssignServiceDetails] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId";

        public static string GetByAssignServiceId =
        @"  SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,ser.Name ServiceName
                  ,Asig.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                  ,CONVERT(char(10), Ags.[DateVisit],105) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
				  ,sta.Name AS StateName
				  ,Ags.PaymentType
				  ,Ags.ReceivedAmount
				  ,OtherAmount
				  ,CASE PaymentType WHEN 1 THEN 'Efectivo' WHEN 2 THEN 'PIN' WHEN 3 THEN 'OTRO' ELSE NULL END PaymentName
                  ,Pin
                  ,Verified
                  ,VerifiedBy
                  ,(SELECT TOP 1 ISNULL(1,0) FROM [sas].[DetailAnswers] WHERE AssignServiceDetailId = Ags.AssignServiceDetailId) [IsQualityTestDone]
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetails] Ags
            LEFT JOIN  [sas].[AssignService]  Asig
            ON Asig.AssignServiceId = ags.AssignServiceId
            LEFT JOIN  [cfg].[Services]  ser
            ON Asig.ServiceId = ser.ServiceId
			LEFT JOIN  [cfg].[Professionals] Pro
            ON Pro.ProfessionalId = Ags.ProfessionalId
			LEFT JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            WHERE       Ags.[AssignServiceId] = @AssignServiceId
            ORDER BY    Ags.[Consecutive]";

        public static string GetById =
        @"  
            SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                  ,CONVERT(char(10), Ags.[DateVisit],105) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
				  ,sta.Name AS StateName
                  ,Pin
                  ,Verified
                  ,VerifiedBy
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetails] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            WHERE   [AssignServiceDetailId] = @AssignServiceDetailId";

        public static string Update =
        @"[sas].[UpdateAssignServiceDetails]";

        public static string GetQuestions =
            @"SELECT [QuestionId],[IdServiceType],[QuestionText],[RecordDate], -1 AS[AnswerId]
                  FROM [cfg].[QualityQuestions] 
                  WHERE [IdServiceType] = (SELECT ServiceTypeId FROM [cfg].[Services] WHERE ServiceId = @ServiceId)";

        public static string SaveQuestion =
            @"INSERT INTO [sas].[DetailAnswers] ([QuestionId],[AnswerId],[AssignServiceDetailId]) 
                VALUES	(@QuestionId,@AnswerId, @AssignServiceDetailId)";

        public static string UpdateQualityCall =
            "UPDATE sas.AssignServiceDetails SET QualityCallDate = GETDATE(), QualityCallUser = @QualityCallUser WHERE AssignServiceDetailId = @AssignServiceDetailId";
    }
}