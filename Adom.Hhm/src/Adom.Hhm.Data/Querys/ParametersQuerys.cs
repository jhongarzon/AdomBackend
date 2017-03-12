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
            FROM	    [cfg].[DocumentType]";

        public static string GetSpecialties =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[Specialty]";

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
            FROM	    [cfg].[AccountType]";

        public static string GetServiceType =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[ServiceType]";

        public static string GetClassification =
        @"  SELECT [Id]
                   ,[Name]
            FROM	    [cfg].[Classification]";
    }
}
