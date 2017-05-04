using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface INoticeDomainService
    {
        ServiceResult<IEnumerable<Notice>> GetNotices();
        ServiceResult<Notice> Insert(Notice entity);

        void Delete(long NoticeId);

    }
}
