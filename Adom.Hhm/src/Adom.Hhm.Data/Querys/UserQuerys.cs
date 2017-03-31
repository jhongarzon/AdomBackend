using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Data.Querys
{
    public static class UserQuerys
    {
        public static string GetAll =
        @"  SELECT	    [UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email],[State],Count(*) Over() AS TotalRows
            FROM	    [sec].[Users]
            ORDER BY    [UserId] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";

        public static string GetAllWithouPagination =
       @"  SELECT	    [UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email],[State],Count(*) Over() AS TotalRows
            FROM	    [sec].[Users]
            ORDER BY    [FirstName],[Surname],[State] DESC";

        public static string GetByEmail =
        @"  SELECT	    [UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email],[State]
            FROM	    [sec].[Users]
            WHERE       [Email] = @Email";

        public static string GetByEmailWithoutId =
        @"  SELECT	    [UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email],[State]
            FROM	    [sec].[Users]
            WHERE       [UserId] <> @UserId
            AND         [Email] = @Email";

        public static string GetById =
        @"  SELECT	[UserId],[FirstName],[SecondName],[Surname],[SecondSurname],[Email],[State]
            FROM	[sec].[Users]
            WHERE   [UserId] = @UserId
            AND     [State] = 1";

        public static string Insert =
        @"  INSERT INTO [sec].[Users]([FirstName],[SecondName],[Surname],[SecondSurname],[Email],[Password])
            VALUES(@FirstName,@SecondName,@Surname,@SecondSurname,@Email,@Password);
            SELECT CAST(SCOPE_IDENTITY() as int)";

        public static string Update =
        @"  UPDATE [sec].[Users]
            SET     [FirstName] = @FirstName, 
                    [SecondName] = @SecondName, 
                    [Surname] = @Surname, 
                    [SecondSurname] = @SecondSurname, 
                    [Email] = @Email,
                    [State] = @State
            WHERE   [UserId] = @UserId";

        public static string ChangePassword =
        @"  UPDATE [sec].[Users]
            SET     [Password] = @Password
            WHERE   [UserId] = @UserId";

        public static string RecoverPassword =
        @"  SELECT	[UserId],[Password],[FirstName],[SecondName],[Surname],[SecondSurname],[Email]
            FROM	[sec].[Users]
            WHERE   [Email] = @Email
            AND     [State] = 1";
    }
}
