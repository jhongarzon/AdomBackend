using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class AuthorizationQuerys
    {
        public static string GetPolicies =
        @"  SELECT 
			            DISTINCT
			             Res.ResourceId as ResourceId
			            ,Res.Name as ResourceName
			            ,Modu.ModuleId as ModuleId
			            ,Modu.Name as ModuleName
			            ,Act.Name as ActionName
			            ,ActRes.Route as Route
                        ,Res.RouteFrontEnd as RouteFrontEnd
            FROM		[sec].[ActionsResources] ActRes
            INNER JOIN  [sec].[Resources] Res
            ON          ActRes.[ResourceId] = Res.[ResourceId]
            INNER JOIN  [sec].[Actions] Act
            ON          ActRes.[ActionId] = Act.[ActionId]
            INNER JOIN  [sec].[Modules] Modu
            ON          Modu.[ModuleId] = Res.[ModuleId]	
            WHERE
			            Modu.[State] = 1
            AND
			            Res.[State] = 1
            AND
			            Act.[State] = 1";

        public static string GetPoliciesByUser =
        @"  SELECT 
			            DISTINCT
			             Res.ResourceId as ResourceId
			            ,Res.Name as ResourceName
			            ,Modu.ModuleId as ModuleId
			            ,Modu.Name as ModuleName
			            ,Act.Name as ActionName
			            ,ActRes.Route as Route
                        ,Res.RouteFrontEnd as RouteFrontEnd
            FROM		[sec].[ActionsResources] ActRes
            INNER JOIN  [sec].[Resources] Res
            ON          ActRes.[ResourceId] = Res.[ResourceId]
            INNER JOIN  [sec].[Actions] Act
            ON          ActRes.[ActionId] = Act.[ActionId]
            INNER JOIN  [sec].[Modules] Modu
            ON          Modu.[ModuleId] = Res.[ModuleId]
            INNER JOIN  [sec].[RolesActionsResources] RolActSec
            ON          ActRes.[ActionResourceId] = RolActSec.[ActionResourceId]	
            INNER JOIN  [sec].[Roles] Rol
            ON          RolActSec.[RoleId] = Rol.[RoleId]	
            INNER JOIN  [sec].[UsersRoles] UserRol
            ON          UserRol.[RoleId] = Rol.[RoleId]			
            WHERE
			            UserRol.[UserId] = @UserId";

        public static string IsAuthorized =
        @"  SELECT 
			            DISTINCT
			             Res.ResourceId as ResourceId
            FROM		[sec].[ActionsResources] ActRes
            INNER JOIN  [sec].[Resources] Res
            ON          ActRes.[ResourceId] = Res.[ResourceId]
            INNER JOIN  [sec].[Actions] Act
            ON          ActRes.[ActionId] = Act.[ActionId]
            INNER JOIN  [sec].[Modules] Modu
            ON          Modu.[ModuleId] = Res.[ModuleId]
            INNER JOIN  [sec].[RolesActionsResources] RolActSec
            ON          ActRes.[ActionResourceId] = RolActSec.[ActionResourceId]	
            INNER JOIN  [sec].[Roles] Rol
            ON          RolActSec.[RoleId] = Rol.[RoleId]	
            INNER JOIN  [sec].[UsersRoles] UserRol
            ON          UserRol.[RoleId] = Rol.[RoleId]			
            WHERE
			            UserRol.[UserId] = @UserId
            AND
			            ActRes.[Route] = @RoutePath ";

    }
}