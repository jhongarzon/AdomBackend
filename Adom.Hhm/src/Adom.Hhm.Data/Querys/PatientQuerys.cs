using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class PatientQuerys
    {
        public static string GetAll =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            ORDER BY    pat.[PatientId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId";

        public static string GetByDocument =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Document] = @Document";

        public static string GetByNamesOrDocument =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[NameCompleted] like @DataFind 
            OR          [pat].[Document] like @DataFind";

        public static string GetByDocumentType =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Document] = RTRIM(LTRIM(@DataFind))
            AND         [pat].[DocumentTypeId] = @DocumentTypeId";

        public static string GetByEmail =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Email] = @Email";

        public static string GetByEmailWithoutId =
        @" SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Email] = @Email
            AND         [pat].[PatientId] <> @PatientId";

        public static string GetByDocumentWithoutId =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Document] = @Document
            AND         [pat].[PatientId] <> @PatientId 
            AND         [pat].[DocumentTypeId] = @DocumentTypeId";

        public static string GetById =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,CONVERT(char(10), pat.[BirthDate],126) AS BirthDate
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
            ,pat.[PatientTypeId] as PatientTypeId
            ,pt.Name as PatientTypeName
            ,pat.[NameCompleted]
            ,pat.[FirstName]
            ,pat.[SecondName]
            ,pat.[Surname]
            ,pat.[SecondSurname]
            ,pat.[Email]
            ,pat.[GenderId]
            ,gen.Name as GenderName
            ,pat.[Occupation]
            ,pat.[Address]
            ,pat.[Telephone1]
            ,pat.[Telephone2]
            ,pat.[AttendantName]
            ,pat.[AttendantRelationship]
            ,pat.[AttendantPhone]
            ,pat.[AttendantEmail]
            ,pat.[Profile]
            ,pat.[Neighborhood]
            ,CONVERT(char(10), pat.[CreatedOn],126) AS CreatedOn,Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[PatientType] pt
            ON pt.Id = pat.PatientTypeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[PatientId] = @PatientId";

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
               ,[Neighborhood]
               ,[Telephone1]
               ,[Telephone2]
               ,[AttendantName]
               ,[AttendantRelationship]
               ,[AttendantPhone]
               ,[AttendantEmail]
               ,[Profile]
               ,[CreatedOn]
               ,[PatientTypeId]
               ,[NameCompleted])
         VALUES
               (RTRIM(LTRIM(@Document))
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
               ,@Neighborhood
               ,@Telephone1
               ,@Telephone2
               ,@AttendantName
               ,@AttendantRelationship
               ,@AttendantPhone
               ,@AttendantEmail
               ,@Profile
               ,getdate()
               ,@PatientTypeId
               ,@NameCompleted) 
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
                ,[Neighborhood] = @Neighborhood
                ,[Telephone1] = @Telephone1
                ,[Telephone2] = @Telephone2
                ,[AttendantName] = @AttendantName
                ,[AttendantRelationship] = @AttendantRelationship
                ,[AttendantPhone] = @AttendantPhone
                ,[AttendantEmail] = @AttendantEmail
                ,[Profile] = @Profile
                ,[PatientTypeId] = @PatientTypeId
                ,[NameCompleted] = @NameCompleted
            WHERE   [PatientId] = @PatientId";
    }
}
