using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class ParameterQuerys
    {
        public static string GetDocumentType =
        @"  SELECT   [Id]
                    ,[Name]
            FROM	    [cfg].[DocumentType]
            ORDER BY [Name]";

        public static string GetSpecialties =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[Specialty]
            ORDER BY [Name]";

        public static string GetZones =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[Zone]";

        public static string GetGender =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[Gender]";

        public static string GetAccountType =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[AccountType]
            ORDER BY [Name]";

        public static string GetServiceType =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[ServiceType]
            ORDER BY [Name]";

        public static string GetClassification =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[Classification]
            ORDER BY [Name]";

        public static string GetUnitTime =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[UnitTime]";

        public static string GetStateAssignService =
        @"  SELECT   [Id]
                    ,[Name]
            FROM	    [sas].[StateAssignService]";

        public static string GetBilledTo =
        @"  SELECT   [Id]
                    ,[Name]
            FROM	    [cfg].[BilledTo]";

        public static string GetPatientType =
        @"  SELECT   [Id]
                    ,[Name]
            FROM	    [cfg].[PatientType]
            ORDER BY [Name]";
    }
}
