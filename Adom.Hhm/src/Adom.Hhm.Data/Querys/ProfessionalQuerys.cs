using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class ProfessionalQuerys
    {
        public static string GetAll =
        @"  SELECT [ProfessionalId]
            ,[UserId]
            ,[Document]
            ,[BirthDate]
            ,[DateAdmission]
            ,[Neighborhood]
            ,[Availability]
            ,[Address]
            ,[Telephone1]
            ,[Telephone2]
            ,[AccountNumber]
            ,[CodeBank]
            ,[GenderId]
            ,[SpecialtyId]
            ,[ZoneId]
            ,[FamilyName]
            ,[FamilyRelationship]
            ,[FamilyPhone]
            ,[Coverage]
            ,[DocumentTypeId],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Professionals]
            ORDER BY    [ProfessionalId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetByEmail =
        @"  SELECT	    Pro.*
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [sec].[UserId]
            WHERE       [Urs].[Email] = @Email";

        public static string GetByEmailWithoutId =
        @"  SELECT	    Pro.*
            FROM	    [cfg].[Professionals] Pro
            INNER JOIN  [sec].[Users] Urs
            ON          [Urs].[UserId] = [sec].[UserId]
            WHERE       [Urs].[Email] = @Email
            AND         [Pro].[ProfessionalId] <> @ProfessionalId";

        public static string GetById =
        @"  SELECT	    Pro.*
            FROM	    [cfg].[Professionals] Pro
            WHERE       [Pro].[ProfessionalId] = @ProfessionalId
            AND         [Pro].[State] = 1";

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
               ,[ZoneId]
               ,[DocumentTypeId]
               ,[FamilyName]
               ,[FamilyRelationship]
               ,[FamilyPhone]
               ,[Coverage])
            VALUES
               (@UserId
               ,@Document
               ,@BirthDate
               ,@DateAdmission
               ,@Availability
               ,@Neighborhood
               ,@Address
               ,@Telephone1
               ,@Telephone2
               ,@AccountNumber
               ,@CodeBank
               ,@GenderId
               ,@SpecialtyId
               ,@ZoneId
               ,@DocumentTypeId
               ,@FamilyName
               ,@FamilyRelationship
               ,@FamilyPhone
               ,@Coverage);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Professionals]
            SET [UserId] = @UserId
              ,[Document] = @Document
              ,[BirthDate] = @BirthDate
              ,[DateAdmission] = @DateAdmission
              ,[Availability] = @Availability
              ,[Neighborhood] = @Neighborhood
              ,[Address] = @Address
              ,[Telephone1] = @Telephone1
              ,[Telephone2] = @Telephone2
              ,[AccountNumber] = @AccountNumber
              ,[CodeBank] = @CodeBank
              ,[GenderId] = @GenderId
              ,[SpecialtyId] = @SpecialtyId
              ,[ZoneId] = @ZoneId
              ,[DocumentTypeId] = @DocumentTypeId
              ,[Coverage] = @Coverage
              ,[FamilyName] = @FamilyName
              ,[FamilyRelationship] = @FamilyRelationship
              ,[FamilyPhone] = @FamilyPhone
            WHERE   [ProfessionalId] = @ProfessionalId";
    }
}
