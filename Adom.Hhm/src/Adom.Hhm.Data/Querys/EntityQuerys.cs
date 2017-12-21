using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class EntityQuerys
    {
        public static string GetAll =
        @"  SELECT	    [EntityId],[Nit],[BusinessName],[Code],[Name],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Entities]
            ORDER BY    [EntityId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [EntityId],[Nit],[BusinessName],[Code],[Name]
            FROM	    [cfg].[Entities]";

        public static string GetByName =
        @"  SELECT	    [EntityId],[Nit],[BusinessName],[Code],[Name]
            FROM	    [cfg].[Entities]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [EntityId],[Nit],[BusinessName],[Code],[Name]
            FROM	    [cfg].[Entities]
            WHERE       [EntityId] <> @EntityId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[EntityId],[Nit],[BusinessName],[Code],[Name]
            FROM	[cfg].[Entities]
            WHERE   [EntityId] = @EntityId";

        public static string Insert =
        @"  INSERT INTO [cfg].[Entities]([Nit],[BusinessName],[Code],[Name])
            VALUES(@Nit, UPPER(@BusinessName), @Code,UPPER(@Name));
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Entities]
            SET     [Name] = UPPER(@Name), 
                    [Nit] = @Nit,
                    [BusinessName] = UPPER(@BusinessName),
                    [Code] = @Code
            WHERE   [EntityId] = @EntityId";
    }
}