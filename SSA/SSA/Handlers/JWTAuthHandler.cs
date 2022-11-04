

using System.Security.Claims;

namespace SSA.Handlers
{
    public class JWTAuthHandler : IAuthHandler
    {
        private readonly byte[] key = null;
        private readonly IAuthenticationManager manager = null;

        public JWTAuthHandler(IAuthenticationManager manager)
        {
            this.manager = manager;
            this.key = Encoding.ASCII.GetBytes(GlobalConstant.EncryptionKey);
        }
        public async Task<string> AuthenticateAsync(UserCredentialModel credentials)
        {

            try
            {
                if (credentials == null)
                {
                    return await Task.FromResult<string>(null);
                }
                if (credentials.UserName == null || credentials.Password == null)
                {
                    return await Task.FromResult<string>(null);
                }

                var user = await manager.GetUser(credentials.UserName,credentials.Password);
                if (user != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var tokenKey = this.key;

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,credentials.UserName)
                    };
                    claims.Add( new Claim(ClaimTypes.Role, user.Role.Name));
                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(15),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                                SecurityAlgorithms.HmacSha256Signature)

                    };

                    var tokenObj = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenData = tokenHandler.WriteToken(tokenObj);
                    return await Task.FromResult<string>(tokenData);
                }
                return await Task.FromResult<string>(null);

            }
            catch (Exception ex)
            {
                return await Task.FromResult<string>(null);
            }
        }
    }
}
