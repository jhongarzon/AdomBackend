using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Notice
    {
        public long NoticeId { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeText { get; set; }
        public int UserId { get; set; }
        public string CreationUserName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
