namespace Adom.Hhm.Data.Querys
{
    public class LockServicesQuerys
    {

        public static string UpdateLockDate =
            @"UPDATE [cfg].[AdomInfo]
                SET [ServicesLockDate] = CONVERT(DATETIME,@LockDate, 105)
                WHERE ProviderCode = @ProviderCode";
    }
}
