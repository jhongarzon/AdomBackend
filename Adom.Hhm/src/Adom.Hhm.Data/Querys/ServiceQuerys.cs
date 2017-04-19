using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class ServiceQuerys
    {
        public static string GetAll =
        @"  SELECT	    ser.[ServiceId],ser.[Value],ser.[Code],ser.[Name],ser.[ClassificationId],cla.name AS ClassificationName,ser.[ServiceTypeId],st.Name as ServiceTypeName,ser.[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Services] ser
            INNER JOIN  [cfg].[Classification] cla
            ON cla.Id = ser.ClassificationId
            INNER JOIN  [cfg].[ServiceType] st
            ON st.Id = ser.ServiceTypeId
            ORDER BY    ser.[ServiceId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    ser.[ServiceId],ser.[Value],ser.[Code],ser.[Name],ser.[ClassificationId],cla.name AS ClassificationName,ser.[ServiceTypeId],st.Name as ServiceTypeName,ser.[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Services] ser
            INNER JOIN  [cfg].[Classification] cla
            ON cla.Id = ser.ClassificationId
            INNER JOIN  [cfg].[ServiceType] st
            ON st.Id = ser.ServiceTypeId";

        public static string GetByName =
        @"  SELECT	    ser.[ServiceId],ser.[Value],ser.[Code],ser.[Name],ser.[ClassificationId],cla.name AS ClassificationName,ser.[ServiceTypeId],st.Name as ServiceTypeName,ser.[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Services] ser
            INNER JOIN  [cfg].[Classification] cla
            ON cla.Id = ser.ClassificationId
            INNER JOIN  [cfg].[ServiceType] st
            ON st.Id = ser.ServiceTypeId
            WHERE       ser.[Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    ser.[ServiceId],ser.[Value],ser.[Code],ser.[Name],ser.[ClassificationId],cla.name AS ClassificationName,ser.[ServiceTypeId],st.Name as ServiceTypeName,ser.[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Services] ser
            INNER JOIN  [cfg].[Classification] cla
            ON cla.Id = ser.ClassificationId
            INNER JOIN  [cfg].[ServiceType] st
            ON st.Id = ser.ServiceTypeId
            WHERE       ser.[ServiceId] <> @ServiceId
            AND         ser.[Name] = @Name";

        public static string GetById =
        @"  SELECT	    ser.[ServiceId],ser.[Value],ser.[Code],ser.[Name],ser.[ClassificationId],cla.name AS ClassificationName,ser.[ServiceTypeId],st.Name as ServiceTypeName,ser.[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Services] ser
            INNER JOIN  [cfg].[Classification] cla
            ON cla.Id = ser.ClassificationId
            INNER JOIN  [cfg].[ServiceType] st
            ON st.Id = ser.ServiceTypeId
            WHERE   ser.[ServiceId] = @ServiceId";

        public static string GetByPlanEntityId =
        @"  SELECT	    ser.[ServiceId],ser.[Value],ser.[Code],ser.[Name],ser.[ClassificationId],cla.name AS ClassificationName,ser.[ServiceTypeId],st.Name as ServiceTypeName,ser.[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN	    [cfg].[Services] ser
            ON pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[Classification] cla
            ON cla.Id = ser.ClassificationId
            INNER JOIN  [cfg].[ServiceType] st
            ON st.Id = ser.ServiceTypeId
            WHERE   pr.[PlanEntityId] = @PlanEntityId";

        public static string Insert =
        @"  INSERT INTO [cfg].[Services]([Value],[Code],[Name],[ClassificationId],[ServiceTypeId],[HoursToInvest])
            VALUES(@Value,@Code,@Name,@ClassificationId,@ServiceTypeId,@HoursToInvest);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Services]
            SET     [Name] = @Name, 
                    [Value] = @Value,
                    [Code] = @Code,
                    [ClassificationId] = @ClassificationId,
                    [ServiceTypeId] = @ServiceTypeId,
                    [HoursToInvest] = @HoursToInvest
            WHERE   [ServiceId] = @ServiceId";
    }
}