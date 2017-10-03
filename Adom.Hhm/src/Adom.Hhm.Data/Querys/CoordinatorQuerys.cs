using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class CoordinatorQuerys
    {
        public static string GetAll =
        @"  SELECT Pro.[CoordinatorId]
            ,Pro.[UserId]
            ,Pro.[Document]
            ,Pro.[DocumentTypeId]
            ,CONVERT(char(10), Pro.[BirthDate],105) AS BirthDate
            ,Pro.[Telephone1]
            ,Pro.[Telephone2]
            ,Pro.[GenderId]
            , Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname, Urs.State
            ,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Coordinators] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            ORDER BY    [CoordinatorId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT Pro.[CoordinatorId]
            ,Pro.[UserId]
            ,Pro.[Document]
            ,Pro.[DocumentTypeId]
            ,CONVERT(char(10), Pro.[BirthDate],105) AS BirthDate
            ,Pro.[Telephone1]
            ,Pro.[Telephone2]
            ,Pro.[GenderId]
            , Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname, Urs.State
            FROM	    [cfg].[Coordinators] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]";

        public static string GetByEmail =
        @"  SELECT	    Pro.*,Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname, Urs.State
            FROM	    [cfg].[Coordinators] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            WHERE       [Urs].[Email] = @Email";

        public static string GetByEmailWithoutId =
        @"  SELECT	    Pro.*,Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname, Urs.State
            FROM	    [cfg].[Coordinators] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            WHERE       [Urs].[Email] = @Email
            AND         [Pro].[CoordinatorId] <> @CoordinatorId";

        public static string GetById =
        @"  SELECT	    Pro.*,Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname, Urs.State
            FROM	    [cfg].[Coordinators] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            WHERE       [Pro].[CoordinatorId] = @CoordinatorId
            AND         [Urs].[State] = 1";

        public static string Insert =
        @"  INSERT INTO [cfg].[Coordinators]
               ([UserId]
               ,[Document]
               ,[BirthDate]
               ,[Telephone1]
               ,[Telephone2]
               ,[GenderId]
               ,[DocumentTypeId])
            VALUES
               (@UserId
               ,@Document
               ,@BirthDate
               ,@Telephone1
               ,@Telephone2
               ,@GenderId
               ,@DocumentTypeId);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Coordinators]
            SET [UserId] = @UserId
              ,[Document] = @Document
              ,[BirthDate] = @BirthDate
              ,[Telephone1] = @Telephone1
              ,[Telephone2] = @Telephone2
              ,[GenderId] = @GenderId
              ,[DocumentTypeId] = @DocumentTypeId
            WHERE   [CoordinatorId] = @CoordinatorId";
    }
}
