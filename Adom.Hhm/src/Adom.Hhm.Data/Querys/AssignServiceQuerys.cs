using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class AssignServiceQuerys
    {
        public static string GetAll =
        @" SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[Validity]
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,Ags.[Quantity]
                  ,Ags.[InitialDate]
                  ,Ags.[FinalDate]
                  ,Ags.[ServiceFrecuencyId]
				  ,sef.Name as ServiceFrecuencyName
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[CoPaymentAmount]
                  ,Ags.[CoPaymentFrecuencyId]
				  ,cpf.Name AS CoPaymentFrecuencyName
                  ,Ags.[Consultation]
                  ,Ags.[External]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
                  ,sta.Observation
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
			INNER JOIN [cfg].[BilledTo] bil
            ON bil.Id = Ags.BilledToId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            ORDER BY    Ags.[AssignServiceId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[Validity]
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,Ags.[Quantity]
                  ,Ags.[InitialDate]
                  ,Ags.[FinalDate]
                  ,Ags.[ServiceFrecuencyId]
				  ,sef.Name as ServiceFrecuencyName
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[CoPaymentAmount]
                  ,Ags.[CoPaymentFrecuencyId]
				  ,cpf.Name AS CoPaymentFrecuencyName
                  ,Ags.[Consultation]
                  ,Ags.[External]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
                  ,sta.Observation
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
			INNER JOIN [cfg].[BilledTo] bil
            ON bil.Id = Ags.BilledToId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId";

        public static string GetByPateintId =
        @"  SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[Validity]
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,Ags.[Quantity]
                  ,Ags.[InitialDate]
                  ,Ags.[FinalDate]
                  ,Ags.[ServiceFrecuencyId]
				  ,sef.Name as ServiceFrecuencyName
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[CoPaymentAmount]
                  ,Ags.[CoPaymentFrecuencyId]
				  ,cpf.Name AS CoPaymentFrecuencyName
                  ,Ags.[Consultation]
                  ,Ags.[External]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
                  ,sta.Observation
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
			INNER JOIN [cfg].[BilledTo] bil
            ON bil.Id = Ags.BilledToId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            WHERE       Ags.[PatientId] = @PatientId";

        public static string GetById =
        @"  
            SELECT Ags.[AssignServiceId]
                  ,Ags.[PatientId]
                  ,Ags.[AuthorizationNumber]
                  ,Ags.[Validity]
                  ,Ags.[ApplicantName]
                  ,Ags.[ServiceId]
				  ,Ser.Name as ServiceName
                  ,Ags.[Quantity]
                  ,Ags.[InitialDate]
                  ,Ags.[FinalDate]
                  ,Ags.[ServiceFrecuencyId]
				  ,sef.Name as ServiceFrecuencyName
                  ,Ags.[ProfessionalId]
				  ,(usr.FirstName + ' ' + usr.SecondName + ' ' + usr.SecondName + ' ' + usr.SecondSurname) AS ProfessionalName
                  ,Ags.[CoPaymentAmount]
                  ,Ags.[CoPaymentFrecuencyId]
				  ,cpf.Name AS CoPaymentFrecuencyName
                  ,Ags.[Consultation]
                  ,Ags.[External]
                  ,Ags.[StateId]
				  ,sta.Name AS StateName
                  ,sta.Observation
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
			INNER JOIN [cfg].[BilledTo] bil
            ON bil.Id = Ags.BilledToId
			INNER JOIN [sas].[StateAssignService] sta
            ON sta.Id = Ags.StateId
            WHERE   [AssignServiceId] = @AssignServiceId";

        public static string CreateAssignServiceAndDetails =
        @"  [sas].[AssignServices] @PatientId,@AuthorizationNumber,@Validity,@ApplicantName,@ServiceId,@Quantity,@InitialDate,@FinalDate,
            @ServiceFrecuencyId,@ProfessionalId,@CoPaymentAmount,@CoPaymentFrecuencyId,@Consultation,@External,@StateId, @Observation";

        public static string Update =
        @"  UPDATE [cfg].[AssignServices]
               SET [AuthorizationNumber] = @AuthorizationNumber
              ,[CoPaymentAmount] = @CoPaymentAmount
              ,[CoPaymentFrecuencyId] = @CoPaymentFrecuencyId
            WHERE   [AssignServiceId] = @AssignServiceId";
    }
}