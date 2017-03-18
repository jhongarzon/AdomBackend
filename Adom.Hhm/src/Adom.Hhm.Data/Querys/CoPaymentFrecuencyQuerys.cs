using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class CoPaymentFrecuencyQuerys
    {
        public static string GetAll =
        @"  SELECT	    [CoPaymentFrecuencyId],[Name],Count(*) Over() AS TotalRows
            FROM	    [cfg].[CoPaymentFrecuency]
            ORDER BY    [CoPaymentFrecuencyId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [CoPaymentFrecuencyId],[Name]
            FROM	    [cfg].[CoPaymentFrecuency]";

        public static string GetByName =
        @"  SELECT	    [CoPaymentFrecuencyId],[Name]
            FROM	    [cfg].[CoPaymentFrecuency]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [CoPaymentFrecuencyId],[Name]
            FROM	    [cfg].[CoPaymentFrecuency]
            WHERE       [CoPaymentFrecuencyId] <> @CoPaymentFrecuencyId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[CoPaymentFrecuencyId],[Name]
            FROM	[cfg].[CoPaymentFrecuency]
            WHERE   [CoPaymentFrecuencyId] = @CoPaymentFrecuencyId";

        public static string Insert =
        @"  INSERT INTO [cfg].[CoPaymentFrecuency]([Name])
            VALUES(@[Name]);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[CoPaymentFrecuency]
            SET     [Name] = @Name
            WHERE   [CoPaymentFrecuencyId] = @CoPaymentFrecuencyId";
    }
}