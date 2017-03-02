using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Utility
{
    public class TokenJWT
    {
        public static int GetUserByToken(string token)
        {
            JwtSecurityToken jsonPayload = new JwtSecurityTokenHandler().ReadJwtToken(token.Replace("Bearer ", ""));
            return int.Parse((from c in jsonPayload.Claims
                       where c.Type.Equals("UserId")
                       select c.Value).FirstOrDefault());
        }
    }
}
