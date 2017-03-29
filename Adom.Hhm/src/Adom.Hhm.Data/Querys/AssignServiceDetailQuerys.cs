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
                  ,CONVERT(char(10), Ags.[DateVisit],126) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
				  ,sta.Name AS StateName
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
                  ,CONVERT(char(10), Ags.[DateVisit],126) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
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
                  ,Ags.[ProfessionalId]
				  ,(ISNULL(usr.FirstName,'') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondName, '') + ' ' + ISNULL(usr.SecondSurname, '')) AS ProfessionalName
                  ,CONVERT(char(10), Ags.[DateVisit],126) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
				  ,sta.Name AS StateName
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetails] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
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
                  ,CONVERT(char(10), Ags.[DateVisit],126) AS DateVisit
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
                  ,Ags.[Observation]
				  ,sta.Name AS StateName
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
    }
}