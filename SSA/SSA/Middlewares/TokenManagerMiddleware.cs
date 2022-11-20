using System.Security.Claims;

namespace SSA.Middlewares
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly IAuthHandler authHandler;
        public TokenManagerMiddleware(IAuthHandler authHandler)
        {
            this.authHandler=authHandler;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tokenStr = context.Request.Headers.Authorization.ToString();
            var token =tokenStr.Split(' ').Last();
            ClaimsPrincipal claims = null;
            if (string.IsNullOrEmpty(token) ||this.authHandler.IsTokenValid(token,out claims))
            {
                context.User = claims;
                await next(context);
                return;
            }
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}
