using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class NoticeQuerys
    {
        public static string GetNotices =
        @"  SELECT [NoticeId]
              ,[NoticeTitle]
              ,[NoticeText]
              ,N.[UserId]
              ,[CreationDate],
           U.FirstName +' '+U.SecondName+' ' +U.Surname + ' '+U.SecondSurname as CreationUserName
        FROM [cfg].[Notice] N INNER JOIN [sec].[Users] U
        On N.UserId = U.UserId WHERE N.State = 1 ORDER by N.CreationDate desc";

        public static string Insert =
      @"  INSERT INTO [cfg].[Notice]([NoticeTitle],[NoticeText],[UserId],[CreationDate])
            VALUES(UPPER(@NoticeTitle), UPPER(@NoticeText),@UserId,getdate());
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Delete =
     @"  UPDATE [cfg].[Notice] SET State = 0 WHERE NoticeId=@NoticeId";

    }
}