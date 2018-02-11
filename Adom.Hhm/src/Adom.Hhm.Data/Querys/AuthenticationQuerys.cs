using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class AuthenticationQuerys
    {
        public static string ValidCredentials =
        @"  SELECT	[UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email],[State]
            FROM	[sec].[Users]
            WHERE   [Email] = @Email 
            AND     [Password] = @Password";


    }
}
