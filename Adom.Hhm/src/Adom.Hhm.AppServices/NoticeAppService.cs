using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;
using System;

namespace Adom.Hhm.AppServices
{
    public class NoticeAppService : INoticeAppService
    {
        private readonly INoticeDomainService service;

        public NoticeAppService(INoticeDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<IEnumerable<Notice>> GetNotices()
        {
            return this.service.GetNotices();
        }

        public ServiceResult<Notice> Insert(Notice entity)
        {
            return this.service.Insert(entity);
        }

        public void Delete(long NoticeId)
        {
            this.service.Delete(NoticeId);
        }
    }
}
