using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class NoticeRepository : INoticeRepository
    {
        private readonly IDbConnection connection;

        public NoticeRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        

        public IEnumerable<Notice> GetNotices()
        {
            return connection.Query<Notice>(NoticeQuerys.GetNotices);
        }

        public Notice Insert(Notice entity)
        {
            var id = connection.Query<int>(NoticeQuerys.Insert, entity).Single();
            entity.NoticeId = id;
            return entity;
        }
    }
}
