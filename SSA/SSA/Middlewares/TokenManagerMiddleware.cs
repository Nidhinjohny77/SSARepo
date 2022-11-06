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
            if (await this.authHandler.IsTokenValid(token))
            {
                await next(context);
                return;
            }
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}
