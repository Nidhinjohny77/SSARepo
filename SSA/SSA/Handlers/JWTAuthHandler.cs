

using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SSA.Handlers
{
    public class JWTAuthHandler : IAuthHandler
    {
        private readonly byte[] key = null;
        private readonly IAuthenticationManager manager = null;
        private readonly IDistributedCache cache = null;
        public JWTAuthHandler(IAuthenticationManager manager,IDistributedCache cache)
        {
            this.manager = manager;
            this.key = Encoding.ASCII.GetBytes(GlobalConstant.SigningKey);
            this.cache = cache;
        }
        public async Task<TokenModel> AuthenticateAsync(UserCredentialModel credentials)
        {

            try
            {
                if (credentials == null)
                {
                    return await Task.FromResult<TokenModel>(null);
                }
                if (credentials.UserName == null || credentials.Password == null)
                {
                    return await Task.FromResult<TokenModel>(null);
                }

                var user = await manager.GetUserAsync(credentials.UserName,credentials.Password);
                var tokenModel=await GenerateTokenAsync(user);
                return await Task.FromResult<TokenModel>(tokenModel);

            }
            catch (Exception ex)
            {
                return await Task.FromResult<TokenModel>(null);
            }
        }

        public async Task<TokenModel> RefreshTokenAsync(TokenModel expiredToken)
        {
            try
            {
                UserModel userModel= GetUserFromToken(expiredToken.AccessToken);
                if (userModel != null)
                {
                    if (IsRefreshTokenValid(userModel.UserName, expiredToken.RefreshToken))
                    {
                        return await GenerateTokenAsync(userModel);
                    }
                }
                return await Task.FromResult<TokenModel>(null);
            }
            catch (Exception ex)
            {
                return await Task.FromResult<TokenModel>(null);
            }
        }

        public async Task<bool> RemoveTokenAsync(TokenModel token)
        {
            UserModel userModel = GetUserFromToken(token.AccessToken);
            if (userModel != null)
            {
                return await RemoveTokenAsync(userModel, token);
            }
            return await Task.FromResult<bool>(false);    
        }

        public async Task<bool> IsTokenValid(string token)
        {
            try
            {
                
                if (!string.IsNullOrEmpty(token))
                {
                    var userModel = GetUserFromToken(token);
                    if(userModel != null)
                    {
                        var isValid = IsRefreshTokenAvailable(userModel.UserName);
                        return await Task.FromResult<bool>(isValid);
                    }
                }
                return await Task.FromResult<bool>(true);
            }
            catch(Exception ex)
            {
                return await Task.FromResult<bool>(false);
            }            
        }

        private bool IsRefreshTokenAvailable(string key)
        {
            var cachedRefreshToken = this.cache.GetString(key);
            return !string.IsNullOrEmpty(cachedRefreshToken);
        }

        private bool IsRefreshTokenValid(string key,string refreshToken)
        {
            var cachedRefreshToken=this.cache.GetString(key);
            return !string.IsNullOrEmpty(cachedRefreshToken) && !string.IsNullOrEmpty(refreshToken)
                && string.Compare(cachedRefreshToken, refreshToken, ignoreCase: false) == 0;
        }

        private async Task<bool> RemoveTokenAsync(UserModel user, TokenModel token)
        {
             await this.cache.RemoveAsync(user.UserName);
            var cachedRefreshToken = this.cache.GetString(user.UserName);
            return await Task.FromResult<bool>(string.IsNullOrEmpty(cachedRefreshToken));
        }

        private UserModel GetUserFromToken(string token)
        {
            var orginalTokenValidationParameters=StartUp.StartUp.GetConfiguredTokenValidationParameters();
            var tokenValidationParameters = orginalTokenValidationParameters.Clone();
            tokenValidationParameters.ValidateLifetime = false;
            var tokenHandler=new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters ,out SecurityToken securityToken);
            var jwtSecurityToken= securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || jwtSecurityToken.Header.Alg.Equals(GlobalConstant.SigningAlgorithm, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }
            if (principal != null)
            {
                var model = new UserModel()
                {
                    UserName = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
                    Role = new RoleModel()
                    {
                        Name = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value
                    }
                };
                return model;
            }
            return null;
        }

        private async Task<TokenModel> GenerateTokenAsync(UserModel user)
        {
            
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenKey = this.key;

                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(GlobalConstant.AccessTokenExpirationInMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                            GlobalConstant.SigningAlgorithm)

                };

                var tokenObj = tokenHandler.CreateToken(tokenDescriptor);
                var tokenData = tokenHandler.WriteToken(tokenObj);
                var refreshToken = GenerateRefreshToken(user);
                if(!string.IsNullOrEmpty(refreshToken)&& !string.IsNullOrEmpty(tokenData))
                {
                    var model = new TokenModel()
                    {
                        AccessToken = tokenData,
                        RefreshToken = refreshToken
                    };
                    //var refreshTokenBytes=Encoding.ASCII.GetBytes(tokenModel.RefreshToken);
                    var cacheExpirationTimeInMinutes = GetRefreshTokenCacheExpirationInMinutes();
                    var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(cacheExpirationTimeInMinutes));
                    this.cache.SetString(user.UserName, model.RefreshToken, options);
                    return await Task.FromResult(model);
                }
                

            }
            return await Task.FromResult<TokenModel>(null);
        }

        private string GenerateRefreshToken(UserModel model)
        {
            var key=new byte[32];
            string token = string.Empty;
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
                token=Convert.ToBase64String(key);
            }
            return token;   
        }

        private int GetRefreshTokenCacheExpirationInMinutes()
        {
            return GlobalConstant.AccessTokenExpirationInMinutes + 1;
        }

    }
}
