using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class PlanEntityQuerys
    {
        public static string GetAllWithoutPagination =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [sec].[PlanEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.[State] = 1 AND pe.EntityId = @EntityId
            ORDER BY    pe.[PlanEntityId]";

        public static string GetByName =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [sec].[PlanEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.[State] = 1 AND pe.EntityId = @EntityId
            AND         pe.[Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [sec].[PlanEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.[State] = 1 AND pe.EntityId = @EntityId
            WHERE       [PlanEntityId] <> @PlanEntityId
            AND         [Name] = @Name";

        public static string GetById =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [sec].[PlanEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.[State] = 1 AND pe.EntityId = @EntityId
            AND         pe.[PlanEntityId] <> @PlanEntityId";

        public static string Insert =
        @"  INSERT INTO [sec].[PlanEntity]([Name],[EntityId],[State])
            VALUES(@Name,@EntityId,1);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [sec].[PlanEntity]
            SET     [Name] = @Name, 
                    [EntityId] = @EntityId
                    [State] = 0
            WHERE   [PlanEntityId] = @PlanEntityId";
    }
}