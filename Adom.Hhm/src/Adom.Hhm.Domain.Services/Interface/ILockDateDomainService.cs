using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface ILockDateDomainService
    {
        ServiceResult<bool> UpdateLockDate(string lockDate);
    }
}
