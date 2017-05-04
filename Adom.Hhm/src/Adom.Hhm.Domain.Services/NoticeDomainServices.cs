using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;
using System;

namespace Adom.Hhm.Domain.Services
{
    public class NoticeDomainServices : INoticeDomainService
    {
        private readonly INoticeRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public NoticeDomainServices(IConfigurationRoot configuration, INoticeRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }


        public ServiceResult<IEnumerable<Notice>> GetNotices()
        {
            var getNotices = this.repository.GetNotices();
            return new ServiceResult<IEnumerable<Notice>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getNotices
            };
        }

        public ServiceResult<Notice> Insert(Notice entity)
        {
            var insert = this.repository.Insert(entity);

            return new ServiceResult<Notice>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = insert
            };
        }

        public void Delete(long NoticeId)
        {
            this.repository.Delete(NoticeId);

        }
    }
}
