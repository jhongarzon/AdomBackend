using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class ProfessionalQuerys
    {
        public static string GetAll =
        @"  SELECT Pro.[ProfessionalId]
            ,Pro.[UserId]
            ,Pro.[Document]
            ,Pro.[BirthDate]
            ,Pro.[DateAdmission]
            ,Pro.[Neighborhood]
            ,Pro.[Availability]
            ,Pro.[Address]
            ,Pro.[Telephone1]
            ,Pro.[Telephone2]
            ,Pro.[AccountNumber]
            ,Pro.[CodeBank]
            ,Pro.[GenderId]
            ,Pro.[SpecialtyId]
            ,Pro.[FamilyName]
            ,Pro.[FamilyRelationship]
            ,Pro.[FamilyPhone]
            ,Pro.[Coverage]
            ,Pro.[AccountTypeId]
            , Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname,Urs.State
            ,Pro.[DocumentTypeId],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            ORDER BY Urs.Firstname, Urs.Surname, Urs.State DESC OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT Pro.[ProfessionalId]
            ,Pro.[UserId]
            ,Pro.[Document]
            ,CONVERT(VARCHAR(10),Pro.[BirthDate],105) [BirthDate]
            ,CONVERT(VARCHAR(10),Pro.[DateAdmission],105) DateAdmission
            ,Pro.[Neighborhood]
            ,Pro.[Availability]
            ,Pro.[Address]
            ,Pro.[Telephone1]
            ,Pro.[Telephone2]
            ,Pro.[AccountNumber]
            ,Pro.[CodeBank]
            ,Pro.[GenderId]
            ,Pro.[SpecialtyId]
            ,Pro.[FamilyName]
            ,Pro.[FamilyRelationship]
            ,Pro.[FamilyPhone]
            ,Pro.[Coverage]
            ,Pro.[AccountTypeId]
            , Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname,Urs.State
            ,Pro.[DocumentTypeId]
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            ORDER BY Urs.Firstname, Urs.Surname, Urs.State DESC";

        public static string GetByEmail =
        @"  SELECT	    Pro.*,Urs.State
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            WHERE       [Urs].[Email] = @Email
            ORDER BY Urs.Firstname, Urs.Surname, Urs.State DESC";

        public static string GetByEmailWithoutId =
        @"  SELECT	    Pro.*,Urs.State
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            WHERE       [Urs].[Email] = @Email
            AND         [Pro].[ProfessionalId] <> @ProfessionalId";

        public static string GetById =
        @"  SELECT	    Pro.*, Urs.Email, Urs.Firstname,Urs.SecondName,Urs.Surname,Urs.SecondSurname,Urs.State
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [Pro].[UserId]
            WHERE       [Pro].[ProfessionalId] = @ProfessionalId
            AND         [Urs].[State] = 1";

        public static string Insert =
        @"  INSERT INTO [cfg].[Professionals]
               ([UserId]
               ,[Document]
               ,[BirthDate]
               ,[DateAdmission]
               ,[Availability]
               ,[Neighborhood]
               ,[Address]
               ,[Telephone1]
               ,[Telephone2]
               ,[AccountNumber]
               ,[CodeBank]
               ,[GenderId]
               ,[SpecialtyId]
               ,[DocumentTypeId]
               ,[FamilyName]
               ,[FamilyRelationship]
               ,[FamilyPhone]
               ,[Coverage]
               ,[AccountTypeId])
            VALUES
               (@UserId
               ,@Document
               ,CONVERT(DATETIME,@BirthDate,105)
               ,CONVERT(DATETIME,@DateAdmission,105)
               ,@Availability
               ,@Neighborhood
               ,@Address
               ,@Telephone1
               ,@Telephone2
               ,@AccountNumber
               ,@CodeBank
               ,@GenderId
               ,@SpecialtyId
               ,@DocumentTypeId
               ,@FamilyName
               ,@FamilyRelationship
               ,@FamilyPhone
               ,@Coverage
               ,@AccountTypeId);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Professionals]
            SET [UserId] = @UserId
              ,[Document] = @Document
              ,[BirthDate] = CONVERT(DATETIME,@BirthDate,105)
              ,[DateAdmission] = CONVERT(DATETIME,@DateAdmission,105)
              ,[Availability] = @Availability
              ,[Neighborhood] = @Neighborhood
              ,[Address] = @Address
              ,[Telephone1] = @Telephone1
              ,[Telephone2] = @Telephone2
              ,[AccountNumber] = @AccountNumber
              ,[CodeBank] = @CodeBank
              ,[GenderId] = @GenderId
              ,[SpecialtyId] = @SpecialtyId
              ,[DocumentTypeId] = @DocumentTypeId
              ,[Coverage] = @Coverage
              ,[FamilyName] = @FamilyName
              ,[FamilyRelationship] = @FamilyRelationship
              ,[FamilyPhone] = @FamilyPhone
              ,[AccountTypeId] = @AccountTypeId
            WHERE   [ProfessionalId] = @ProfessionalId;
            UPDATE [sec].Users
            SET    [State] = @State
            WHERE  [UserId] = @UserId";
    }
}
