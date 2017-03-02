using Adom.Hhm.AppServices.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Services.Security.Interface;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Adom.Hhm.AppServices.Security
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IAuthenticationDomainService service;
        private readonly IAuthorizationDomainServices serviceAuthorization;
        private readonly JwtIssuerOptions jwtOptions;
        private readonly IConfigurationRoot configuration;
        private readonly JsonSerializerSettings serializerSettings;

        public AuthenticationAppService(IConfigurationRoot configuration, IAuthenticationDomainService service, IAuthorizationDomainServices serviceAuthorization, IOptions<JwtIssuerOptions> jwtOptions)
        {
            this.configuration = configuration;
            this.service = service;
            this.serviceAuthorization = serviceAuthorization;
            this.jwtOptions = jwtOptions.Value;
            this.jwtOptions.ValidFor = TimeSpan.FromSeconds(double.Parse(this.configuration["ExpirationJWT"]));
            this.ThrowIfInvalidOptions(this.jwtOptions);

            this.serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public async Task<object> GetNewToken(User user)
        {
            string token = string.Empty;
            IEnumerable<Policy> policiesByUser = this.serviceAuthorization.GetPoliciesByUser(user);
            List<Claim> claims = await this.ConvertPolicyToClaims(policiesByUser, user);


            var jwt = new JwtSecurityToken(
             issuer: this.jwtOptions.Issuer,
             audience: this.jwtOptions.Audience,
             claims: claims,
             notBefore: this.jwtOptions.NotBefore,
             expires: this.jwtOptions.Expiration,
             signingCredentials: this.jwtOptions.SigningCredentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = token,
                userId = user.UserId,
                email = user.Email,
                firstName = user.FirstName,
                secondname = user.SecondName,
                surname = user.Surname,
                secondSurname = user.SecondSurname,
                permissions = policiesByUser
            };

            var json = JsonConvert.SerializeObject(response, serializerSettings);

            return json;
        }

        private void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private async Task<List<Claim>> ConvertPolicyToClaims(IEnumerable<Policy> policiesByUser, User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, await this.jwtOptions.JtiGenerator()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, this.ToUnixEpochDate(this.jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64));
            claims.Add(new Claim("UserId", user.UserId.ToString()));

            foreach (var policy in policiesByUser)
            {
                claims.Add(new Claim(policy.ResourceName, policy.ActionName));
            }

            return claims;
        }

        public User ValidCredentials(string email, string password)
        {
            return this.service.ValidCredentials(email, password);
        }
    }
}
