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
            FROM	    [cfg].[PlansEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.EntityId = @EntityId
            ORDER BY    pe.[PlanEntityId]";

        public static string GetByName =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.EntityId = @EntityId
            AND         pe.[Name] = @Name";

        public static string GetByNameWithoutId =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.EntityId = @EntityId
            AND         pe.[PlanEntityId] <> @PlanEntityId
            AND         pe.[Name] = @Name";

        public static string GetById =
        @"  SELECT	    pe.[PlanEntityId],pe.[Name],pe.[EntityId],pe.[State],ent.Name AS EntityName,Count(*) Over() AS TotalRows
            FROM	    [cfg].[PlansEntity] pe
            INNER JOIN  [cfg].[Entities] ent
            ON          pe.EntityId = ent.EntityId
            WHERE       pe.EntityId = @EntityId";

        public static string Insert =
        @"  INSERT INTO [cfg].[PlansEntity]([Name],[EntityId],[State])
            VALUES(UPPER(@Name),@EntityId,1);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[PlansEntity]
            SET     [Name] = UPPER(@Name), 
                    [State] = @State
            WHERE   [PlanEntityId] = @PlanEntityId";
    }
}