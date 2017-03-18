using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class ServiceFrecuencyQuerys
    {
        public static string GetAll =
        @"  SELECT	    [ServiceFrecuencyId],[Name],Count(*) Over() AS TotalRows
            FROM	    [cfg].[ServiceFrecuency]
            ORDER BY    [ServiceFrecuencyId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [ServiceFrecuencyId],[Name]
            FROM	    [cfg].[ServiceFrecuency]";

        public static string GetByName =
        @"  SELECT	    [ServiceFrecuencyId],[Name]
            FROM	    [cfg].[ServiceFrecuency]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [ServiceFrecuencyId],[Name]
            FROM	    [cfg].[ServiceFrecuency]
            WHERE       [ServiceFrecuencyId] <> @ServiceFrecuencyId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[ServiceFrecuencyId],[Name]
            FROM	[cfg].[ServiceFrecuency]
            WHERE   [ServiceFrecuencyId] = @ServiceFrecuencyId";

        public static string Insert =
        @"  INSERT INTO [cfg].[ServiceFrecuency]([Name])
            VALUES(@[Name]);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[ServiceFrecuency]
            SET     [Name] = @Name
            WHERE   [ServiceFrecuencyId] = @ServiceFrecuencyId";
    }
}