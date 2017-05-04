using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface INoticeRepository
    {

        IEnumerable<Notice> GetNotices();
        Notice Insert(Notice entity);
        void Delete(long NoticeId);

    }
}
