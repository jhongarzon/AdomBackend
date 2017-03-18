using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class PlanRateQuerys
    {
        public static string GetAll =
        @"  SELECT	    [PlanRateId],[EntityId],[PlanName],[ServiceId],[Rate],[Validity],Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansRates]
            ORDER BY    [PlanRateId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [PlanRateId],[EntityId],[PlanName],[ServiceId],[Rate],[Validity]
            FROM	    [cfg].[PlansRates]";

        public static string GetByName =
        @"  SELECT	    [PlanRateId],[EntityId],[PlanName],[ServiceId],[Rate],[Validity]
            FROM	    [cfg].[PlansRates]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [PlanRateId],[EntityId],[PlanName],[ServiceId],[Rate],[Validity]
            FROM	    [cfg].[PlansRates]
            WHERE       [PlanRateId] <> @PlanRateId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[PlanRateId],[EntityId],[PlanName],[ServiceId],[Rate],[Validity]
            FROM	[cfg].[PlansRates]
            WHERE   [PlanRateId] = @PlanRateId";

        public static string Insert =
        @"  INSERT INTO [cfg].[PlansRates]([PlanName],[ServiceId],[Rate],[Validity])
            VALUES(@EntityId,@PlanName,@ServiceId,@Rate,@Validity);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[PlansRates]
            SET     [PlanName] = @PlanName, 
                    [ServiceId] = @ServiceId,
                    [Rate] = @Rate,
                    [Validity] = @Validity
            WHERE   [PlanRateId] = @PlanRateId";
    }
}