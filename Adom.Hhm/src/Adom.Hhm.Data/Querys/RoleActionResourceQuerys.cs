using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class RoleActionResourceQuerys
    {
        public static string GetActionsResources =
        @"  SELECT		ActRes.ActionResourceId, ActRes.ActionId, Act.NameLabel ActionName, ActRes.ResourceId, Res.Name ResourceName, Modu.ModuleId, Modu.Name ModuleName
			FROM		[sec].[ActionsResources]  ActRes
			INNER JOIN	[sec].[Actions] Act
			ON			ActRes.ActionId = Act.ActionId
			INNER JOIN  [sec].[Resources] Res
			ON			ActRes.ResourceId = res.ResourceId
			INNER JOIN	[sec].[Modules] Modu
			ON			Res.ModuleId = Modu.ModuleId
			AND			res.[State] = 1
			AND			modu.[State] = 1
			ORDER BY	Modu.ModuleId, ActRes.ResourceId,ActRes.ActionId";

        public static string GeRoleActionResourceByRoleId =
        @"  SELECT		ActRes.ActionResourceId, ActRes.ActionId, Act.NameLabel ActionName, ActRes.ResourceId, Res.Name ResourceName, Modu.ModuleId, Modu.Name ModuleName, RolActRes.RoleId, 1 AS HasRole
			FROM		[sec].[ActionsResources]  ActRes
			INNER JOIN	[sec].[RolesActionsResources] RolActRes
			ON			RolActRes.ActionResourceId = ActRes.ActionResourceId
			INNER JOIN	[sec].[Actions] Act
			ON			ActRes.ActionId = Act.ActionId
			INNER JOIN  [sec].[Resources] Res
			ON			ActRes.ResourceId = res.ResourceId
			INNER JOIN	[sec].[Modules] Modu
			ON			Res.ModuleId = Modu.ModuleId
			WHERE		RolActRes.RoleId = @RoleId
			AND			res.[State] = 1
			AND			modu.[State] = 1
			ORDER BY	Modu.ModuleId, ActRes.ResourceId,ActRes.ActionId";

        public static string GeRoleActionResource =
        @"  SELECT		ActRes.ActionResourceId, ActRes.ActionId, Act.NameLabel ActionName, ActRes.ResourceId, Res.Name ResourceName, Modu.ModuleId, Modu.Name ModuleName, RolActRes.RoleId, 1 AS HasRole
			FROM		[sec].[ActionsResources]  ActRes
			INNER JOIN	[sec].[RolesActionsResources] RolActRes
			ON			RolActRes.ActionResourceId = ActRes.ActionResourceId
			INNER JOIN	[sec].[Actions] Act
			ON			ActRes.ActionId = Act.ActionId
			INNER JOIN  [sec].[Resources] Res
			ON			ActRes.ResourceId = res.ResourceId
			INNER JOIN	[sec].[Modules] Modu
			ON			Res.ModuleId = Modu.ModuleId
			WHERE		RolActRes.RoleId = @RoleId
            AND			ActRes.[ActionResourceId] = @ActionResourceId
			AND			res.[State] = 1
			AND			modu.[State] = 1
			ORDER BY	Modu.ModuleId, ActRes.ResourceId,ActRes.ActionId";


        public static string Insert =
        @"  INSERT INTO [sec].[RolesActionsResources]([RoleId], [ActionResourceId])
            VALUES(@RoleId, @ActionResourceId)";

        public static string Delete =
        @"  DELETE FROM [sec].[RolesActionsResources]
            WHERE   [ActionResourceId] = @ActionResourceId
            AND     [RoleId] = @RoleId";
    }
}
