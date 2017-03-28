﻿using System;
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
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            ORDER BY    pat.[PatientId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithoutPagination =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId";

        public static string GetByDocument =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Document] = @Document";

        public static string GetByNamesOrDocument =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Document] like @DataFind
            OR          [pat].[FirstName] like @DataFind
            OR          [pat].[SecondName] like @DataFind
            OR          [pat].[SurName] like @DataFind
            OR          [pat].[SecondSurname] like @DataFind";

        public static string GetByEmail =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Email] = @Email";

        public static string GetByEmailWithoutId =
        @" SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Email] = @Email
            AND         [pat].[PatientId] <> @PatientId";

        public static string GetByDocumentWithoutId =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[Document] = @Document
            AND         [pat].[PatientId] <> @PatientId";

        public static string GetById =
        @"  SELECT pat.[PatientId]
            ,pat.[Document]
            ,pat.[DocumentTypeId]
            ,dt.Name as DocumentTypeName
            ,pat.[BirthDate]
            ,pat.[Age]
            ,pat.[UnitTimeId]
            ,ut.Name as UnitTimeName
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
            ,pat.[CreatedOn],Count(*) Over() AS TotalRows
            FROM	    [cfg].[Patients] pat
            INNER JOIN  [cfg].[Gender] gen
            ON gen.Id = pat.GenderId
            INNER JOIN  [cfg].[UnitTime] ut
            ON ut.Id = pat.UnitTimeId
            INNER JOIN  [cfg].[DocumentType] dt
            ON dt.Id = pat.DocumentTypeId
            WHERE       [pat].[PatientId] = @PatientId
            AND         [pat].[State] = 1";

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
               ,@Neighborhood
               ,@Telephone1
               ,@Telephone2
               ,@AttendantName
               ,@AttendantRelationship
               ,@AttendantPhone
               ,@AttendantEmail
               ,@Profile
               ,getdate());
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
            WHERE   [PatientId] = @PatientId";
    }
}
