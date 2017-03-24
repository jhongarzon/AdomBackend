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
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[DateVisit]
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetail] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignServiceDetail] sta
            ON sta.Id = Ags.StateId
            ORDER BY    Ags.[AssignServiceDetailId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[DateVisit]
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
            FROM	    [sas].[AssignServiceDetail] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignServiceDetail] sta
            ON sta.Id = Ags.StateId";

        public static string GetByAssignServiceId =
        @"  SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[DateVisit]
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetail] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignServiceDetail] sta
            ON sta.Id = Ags.StateId
            WHERE       Ags.[AssignServiceId] = @AssignServiceId";

        public static string GetById =
        @"  
            SELECT Ags.[AssignServiceDetailId]
                  ,Ags.[AssignServiceId]
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[DateVisit]
                  ,Ags.[Consecutive]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
				  ,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceDetail] Ags
			INNER JOIN  [cfg].[Professionals] Pro
            ON Ags.ProfessionalId = Pro.ProfessionalId
			INNER JOIN  [sec].[Users] usr
            ON usr.UserId = Pro.UserId
			INNER JOIN [sas].[StateAssignServiceDetail] sta
            ON sta.Id = Ags.StateId
            WHERE   [AssignServiceDetailId] = @AssignServiceDetailId";

        public static string Update =
        @" [sas].[UpdateAssignServiceDetails] @AssignServiceId,@AssignServiceDetailId,@StateAssignServiceDetailId,@ProfessionalId,@DateVisit";
    }
}