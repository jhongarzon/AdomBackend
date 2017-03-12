using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class ServiceQuerys
    {
        public static string GetAll =
        @"  SELECT	    [ServiceId],[Value],[Code],[Name],[ClassificationId],[ServiceTypeId],[HoursToInvest],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Services]
            ORDER BY    [ServiceId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [ServiceId],[Value],[Code],[Name],[ClassificationId],[ServiceTypeId],[HoursToInvest]
            FROM	    [cfg].[Services]";

        public static string GetByName =
        @"  SELECT	    [ServiceId],[Value],[Code],[Name],[ClassificationId],[ServiceTypeId],[HoursToInvest]
            FROM	    [cfg].[Services]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [ServiceId],[Value],[Code],[Name],[ClassificationId],[ServiceTypeId],[HoursToInvest]
            FROM	    [cfg].[Services]
            WHERE       [ServiceId] <> @ServiceId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[ServiceId],[Value],[Code],[Name],[ClassificationId],[ServiceTypeId],[HoursToInvest]
            FROM	[cfg].[Services]
            WHERE   [ServiceId] = @ServiceId";

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