using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class AssignServiceSupplyQuerys
    {
        public static string GetAll =
        @"  SELECT	    ass.[AssignServiceSupplyId],ass.[AssignServiceId],ass.[SupplyId],sup.Name as SupplyName,ass.[Quantity],ass.[BilledToId], bil.Name as BilledName,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceSupply] ass
            INNER JOIN  [cfg].[Supplies] sup
			ON			sup.SupplyId = ass.SupplyId
			INNER JOIN  [cfg].[BilledTo] bil
			ON			bil.Id = ass.BilledToId
            ORDER BY    ass.[AssignServiceSupplyId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    ass.[AssignServiceSupplyId],ass.[AssignServiceId],ass.[SupplyId],sup.Name as SupplyName,ass.[Quantity],ass.[BilledToId], bil.Name as BilledName,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceSupply] ass
            INNER JOIN  [cfg].[Supplies] sup
			ON			sup.SupplyId = ass.SupplyId
			INNER JOIN  [cfg].[BilledTo] bil
			ON			bil.Id = ass.BilledToId
            ORDER BY    ass.[AssignServiceSupplyId]";

        public static string GetById =
        @"  SELECT	    ass.[AssignServiceSupplyId],ass.[AssignServiceId],ass.[SupplyId],sup.Name as SupplyName,ass.[Quantity],ass.[BilledToId], bil.Name as BilledName,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceSupply] ass
            INNER JOIN  [cfg].[Supplies] sup
			ON			sup.SupplyId = ass.SupplyId
			INNER JOIN  [cfg].[BilledTo] bil
			ON			bil.Id = ass.BilledToId
            WHERE   ass.[AssignServiceSupplyId] = @AssignServiceSupplyId";

        public static string GetByAssignServiceId =
        @"  SELECT	    ass.[AssignServiceSupplyId],ass.[AssignServiceId],ass.[SupplyId],sup.Name as SupplyName,ass.[Quantity],ass.[BilledToId], bil.Name as BilledName,Count(*) Over() AS TotalRows
            FROM	    [sas].[AssignServiceSupply] ass
            INNER JOIN  [cfg].[Supplies] sup
			ON			sup.SupplyId = ass.SupplyId
			INNER JOIN  [cfg].[BilledTo] bil
			ON			bil.Id = ass.BilledToId
            WHERE   ass.[AssignServiceId] = @AssignServiceId";

        public static string Insert =
        @"  INSERT INTO [sas].[AssignServiceSupply]([AssignServiceId],[SupplyId],[Quantity],[BilledToId])
            VALUES(@AssignServiceId, @SupplyId, @Quantity,@BilledToId);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [sas].[AssignServiceSupply]
            SET     [AssignServiceId] = @AssignServiceId, 
                    [SupplyId] = @SupplyId,
                    [Quantity] = @Quantity,
                    [BilledToId] = @BilledToId
            WHERE   [AssignServiceSupplyId] = @AssignServiceSupplyId";

        public static string Delete =
        @"  DELETE FROM [sas].[AssignServiceSupply]
            WHERE   [AssignServiceSupplyId] = @AssignServiceSupplyId";
    }
}