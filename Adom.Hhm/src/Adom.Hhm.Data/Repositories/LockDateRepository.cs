using System.Data;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class LockDateRepository : ILockDateRepository
    {
        private readonly IDbConnection _dbConnection;
        public LockDateRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public bool UpdateLockDate(string lockDate)
        {
            var rows = _dbConnection.Execute(LockServicesQuerys.UpdateLockDate, new { @LockDate = lockDate, @ProviderCode = 110011114201 });
            return rows > 0;
        }
    }
}
