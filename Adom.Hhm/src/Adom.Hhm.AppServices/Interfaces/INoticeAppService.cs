using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface INoticeAppService
    {
        ServiceResult<IEnumerable<Notice>> GetNotices();
        ServiceResult<Notice> Insert(Notice entity);
    }
}
