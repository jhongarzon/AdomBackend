using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class PatientQuerys
    {
        public static string GetAll =
        @"  SELECT [PatientId]
            ,[Document]
            ,[DocumentTypeId]
            ,[BirthDate]
            ,[Age]
            ,[UnitTimeId]
            ,[FirstName]
            ,[SecondName]
            ,[Surname]
            ,[SecondSurname]
            ,[Email]
            ,[GenderId]
            ,[Occupation]
            ,[Address]
            ,[Telephone1]
            ,[Telephone2]
            ,[AttendantName]
            ,[AttendantRelationship]
            ,[AttendantPhone]
            ,[AttendantEmail]
            ,[Profile]
            ,[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients]
            ORDER BY    [PatientId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetByDocument =
        @"  SELECT	    Pat.*
            FROM	    [cfg].[Patients] Pat
            WHERE       [Pat].[Document] = @Document";

        public static string GetByEmail =
        @"  SELECT	    Pat.*
            FROM	    [cfg].[Patients] Pat
            WHERE       [Pat].[Email] = @Email";

        public static string GetByEmailWithoutId =
        @"  SELECT	    Pat.*
            FROM	    [cfg].[Patients] Pat
            WHERE       [Pat].[Email] = @Email
            AND         [Pat].[PatientId] <> @PatientId";

        public static string GetByDocumentWithoutId =
        @"  SELECT	    Pat.*
            FROM	    [cfg].[Patients] Pat
            WHERE       [Pat].[Document] = @Document
            AND         [Pat].[PatientId] <> @PatientId";

        public static string GetById =
        @"  SELECT	    Pat.*
            FROM	    [cfg].[Patients] Pat
            WHERE       [Pat].[PatientId] = @PatientId
            AND         [Pat].[State] = 1";

        public static string Insert =
        @"  INSERT INTO [cfg].[Patients]
               ([Document]
               ,[DocumentTypeId]
               ,[BirthDate]
               ,[Age]
               ,[UnitTimeId]
               ,[FirstName]
               ,[SecondName]
               ,[Surname]
               ,[SecondSurname]
               ,[Email]
               ,[GenderId]
               ,[Occupation]
               ,[Address]
               ,[Telephone1]
               ,[Telephone2]
               ,[AttendantName]
               ,[AttendantRelationship]
               ,[AttendantPhone]
               ,[AttendantEmail]
               ,[Profile]
               ,[CreatedOn])
         VALUES
               (@Document
               ,@DocumentTypeId
               ,@BirthDate
               ,@Age
               ,@UnitTimeId
               ,@FirstName
               ,@SecondName
               ,@Surname
               ,@SecondSurname
               ,@Email
               ,@GenderId
               ,@Occupation
               ,@Address
               ,@Telephone1
               ,@Telephone2
               ,@AttendantName
               ,@AttendantRelationship
               ,@AttendantPhone
               ,@AttendantEmail
               ,@Profile);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [cfg].[Patients]
            SET [Document] = @Document
                ,[DocumentTypeId] = @DocumentTypeId
                ,[BirthDate] = @BirthDate
                ,[Age] = @Age
                ,[UnitTimeId] = @UnitTimeId
                ,[FirstName] = @FirstName
                ,[SecondName] = @SecondName
                ,[Surname] = @Surname
                ,[SecondSurname] = @SecondSurname
                ,[Email] = @Email
                ,[GenderId] = @GenderId
                ,[Occupation] = @Occupation
                ,[Address] = @Address
                ,[Telephone1] = @Telephone1
                ,[Telephone2] = @Telephone2
                ,[AttendantName] = @AttendantName
                ,[AttendantRelationship] = @AttendantRelationship
                ,[AttendantPhone] = @AttendantPhone
                ,[AttendantEmail] = @AttendantEmail
                ,[Profile] = @Profile
                ,[CreatedOn] = @CreatedOn
            WHERE   [PatientId] = @PatientId";
    }
}
