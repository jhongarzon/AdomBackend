using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class RoleQuerys
    {
        public static string GetAll =
        @"  SELECT	    [RoleId],[Name],[State],Count(*) Over() AS TotalRows
            FROM	    [sec].[Roles]
            WHERE       [State] = 1
            ORDER BY    [RoleId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT	    [RoleId],[Name],[State]
            FROM	    [sec].[Roles]
            WHERE       [State] = 1";

        public static string GetByName =
        @"  SELECT	    [RoleId],[Name],[State]
            FROM	    [sec].[Roles]
            WHERE       [Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    [RoleId],[Name],[State]
            FROM	    [sec].[Roles]
            WHERE       [RoleId] <> @RoleId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	[RoleId],[Name],[State]
            FROM	[sec].[Roles]
            WHERE   [RoleId] = @RoleId
            AND     [State] = 1";

        public static string Insert =
        @"  INSERT INTO [sec].[Roles]([Name])
            VALUES(@Name);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [sec].[Roles]
            SET     [Name] = @Name, 
                    [State] = @State
            WHERE   [RoleId] = @RoleId";
    }
}