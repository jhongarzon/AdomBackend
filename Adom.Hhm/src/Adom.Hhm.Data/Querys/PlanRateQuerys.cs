using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class PlanRateQuerys
    {
        public static string GetAll =
        @"  SELECT	    pr.[PlanRateId],pr.[EntityId],pr.[PlanName],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],126) AS Validity,ser.[Name] AS ServiceName,ent.[Name] AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[Entities] ent
            ON          pr.EntityId = ent.EntityId
            ORDER BY    pr.[PlanRateId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    pr.[PlanRateId],pr.[EntityId],pr.[PlanName],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],126) AS Validity,ser.[Name] AS ServiceName,ent.[Name] AS EntityName
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[Entities] ent
            ON          pr.EntityId = ent.EntityId";

        public static string GetByName =
        @"  SELECT	    pr.[PlanRateId],pr.[EntityId],pr.[PlanName],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],126) AS Validity,ser.[Name] AS ServiceName,ent.[Name] AS EntityName
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[Entities] ent
            ON          pr.EntityId = ent.EntityId
            WHERE       pr.[PlanName] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    pr.[PlanRateId],pr.[EntityId],pr.[PlanName],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],126) AS Validity,ser.[Name] AS ServiceName,ent.[Name] AS EntityName
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[Entities] ent
            ON          pr.EntityId = ent.EntityId
            WHERE       pr.[PlanRateId] <> @PlanRateId
            AND         pr.[PlanName] = @Name";

        public static string GetById =
        @"  SELECT  pr.[PlanRateId],pr.[EntityId],pr.[PlanName],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],126) AS Validity,ser.[Name] AS ServiceName,ent.[Name] AS EntityName
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[Entities] ent
            ON          pr.EntityId = ent.EntityId
            WHERE       pr.[PlanRateId] = @PlanRateId";

        public static string Insert =
        @"  INSERT INTO [cfg].[PlansRates]([EntityId],[PlanName],[ServiceId],[Rate],[Validity])
            VALUES(@EntityId,@PlanName,@ServiceId,@Rate,@Validity);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[PlansRates]
            SET     [EntityId] = @EntityId
                    [PlanName] = @PlanName, 
                    [ServiceId] = @ServiceId,
                    [Rate] = @Rate,
                    [Validity] = @Validity
            WHERE   [PlanRateId] = @PlanRateId";
    }
}