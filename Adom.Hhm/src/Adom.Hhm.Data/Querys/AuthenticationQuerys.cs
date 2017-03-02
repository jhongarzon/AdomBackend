using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class AuthenticationQuerys
    {
        public static string ValidCredentials =
        @"  SELECT	[UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email]
            FROM	[sec].[Users]
            WHERE   [Email] = @Email 
            AND     [Password] = @Password
            AND     [State] = 1";


    }
}
