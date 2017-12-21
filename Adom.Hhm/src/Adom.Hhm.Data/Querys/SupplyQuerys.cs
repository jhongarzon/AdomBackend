using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class SupplyQuerys
    {
        public static string GetAll =
        @"  SELECT	    [SupplyId],[Presentation],[Code],[Name],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Supplies]
            ORDER BY    [SupplyId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [SupplyId],[Presentation],[Code],[Name]
            FROM	    [cfg].[Supplies]";

        public static string GetByName =
        @"  SELECT	    [SupplyId],[Presentation],[Code],[Name]
            FROM	    [cfg].[Supplies]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [SupplyId],[Presentation],[Code],[Name]
            FROM	    [cfg].[Supplies]
            WHERE       [SupplyId] <> @SupplyId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[SupplyId],[Presentation],[Code],[Name]
            FROM	[cfg].[Supplies]
            WHERE   [SupplyId] = @SupplyId";

        public static string Insert =
        @"  INSERT INTO [cfg].[Supplies]([Presentation],[Code],[Name])
            VALUES(UPPER(@Presentation),UPPER(@Code),UPPER(@Name));
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Supplies]
            SET     [Name] = UPPER(@Name), 
                    [Presentation] = UPPER(@Presentation),
                    [Code] = UPPER(@Code)
            WHERE   [SupplyId] = @SupplyId";
    }
}