using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class PlanRateQuerys
    {
        public static string GetAllWithoutPagination =
        @"  SELECT	    pr.[PlanRateId],pr.[PlanEntityId],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],105) AS Validity,ser.Name as ServiceName,Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[PlansEntity] pe
            ON          pe.PlanEntityId = pr.PlanEntityId
            WHERE       pe.PlanEntityId = @PlanEntityId
            ORDER BY    pr.[PlanRateId]";

        public static string GetById =
        @"  SELECT	    pr.[PlanRateId],pr.[PlanEntityId],pr.[ServiceId],pr.[Rate],CONVERT(char(10), pr.[Validity],105) AS Validity,ser.Name as ServiceName,Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansRates] pr
            INNER JOIN  [cfg].[Services] ser
            ON          pr.ServiceId = ser.ServiceId
            INNER JOIN  [cfg].[PlansEntity] pe
            ON          pe.PlanEntityId = pr.PlanEntityId
            WHERE       pr.[PlanRateId] = @PlanRateId";

        public static string Insert =
        @"  INSERT INTO [cfg].[PlansRates]([PlanEntityId],[ServiceId],[Rate],[Validity])
            VALUES(@PlanEntityId,@ServiceId,@Rate,CONVERT(DATETIME,@Validity,105));
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Delete =
        @"  DELETE FROM [cfg].[PlansRates]
            WHERE   [PlanRateId] = @PlanRateId";
    }
}