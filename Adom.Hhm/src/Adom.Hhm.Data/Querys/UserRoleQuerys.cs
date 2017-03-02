using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class UserRoleQuerys
    {
        public static string GetRolesByUserId =
        @"  SELECT		Users.UserId, Rol.RoleId, Rol.Name RoleName, 1 AS HasRole
            FROM		[sec].[Roles] Rol
            INNER JOIN	[sec].[UsersRoles] UserRole
            ON			UserRole.RoleId = Rol.RoleId
            INNER JOIN	[sec].[Users] Users
            ON			UserRole.UserId = Users.UserId
            WHERE		Users.UserId = @UserId
            AND			Rol.[State] = 1";

        public static string GetUserRolByUserIdRoleID =
        @"  SELECT		Users.UserId, Rol.RoleId, Rol.Name RoleName, 1 AS HasRole
            FROM		[sec].[Roles] Rol
            INNER JOIN	[sec].[UsersRoles] UserRole
            ON			UserRole.RoleId = Rol.RoleId
            INNER JOIN	[sec].[Users] Users
            ON			UserRole.UserId = Users.UserId
            WHERE		Users.UserId = @UserId
            AND			Rol.[RoleId] = @RoleId
            AND			Rol.[State] = 1";


        public static string Insert =
        @"  INSERT INTO [sec].[UsersRoles]([UserId], [RoleId])
            VALUES(@UserId, @RoleId)";

        public static string Delete =
        @"  DELETE FROM [sec].[UsersRoles]
            WHERE   [UserId] = @UserId
            AND     [RoleId] = @RoleId";
    }
}
