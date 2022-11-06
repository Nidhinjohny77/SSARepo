

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthHandler handler;
        public AuthenticationController(IMapper mapper,IAuthHandler handler)
        {
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public  async Task<IActionResult> Login([FromBody] UserCredentialModel model)
        {
            var token=await this.handler.AuthenticateAsync(model);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModel token)
        {
            var refreshedToken=await this.handler.RefreshTokenAsync(token);
            if(refreshedToken == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(refreshedToken);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut([FromBody] TokenModel token)
        {
            var Isremoved = await this.handler.RemoveTokenAsync(token);
            if (Isremoved)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to log out.");
            }
        }
    }
}
